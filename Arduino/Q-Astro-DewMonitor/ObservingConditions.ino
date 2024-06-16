/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of ObservingConditions Commands */
/*

  This uses the oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs)
  OneWire can monitor multiple devices via one connection, for the Dew Monitor this will not work as we will not know
  which temp sensor is associated with which Dew Band.
  In our case we need to have 2 individual OneWire instances to enable us to diffirentiate between the 2 Dew bands and temp senssors.

*/

#define PIN_TEMP_SENSOR1  2 
#define PIN_DEW_CHANNEL1  5 

#define PIN_TEMP_SENSOR2  4 
#define PIN_DEW_CHANNEL2  3 

#define TEMP_SENSOR_DISCONNECTED -127   // This is the return value when a dew band temp sensor is not working.

#define TEMP_UPDATE_INTERVAL 10      // in seconds
#define DISP_UPDATE_INTERVAL 5        // in seconds

#define TEMP_PRECISION 9
#define SHT31_I2C_Address (0x44)

#define POWERSET1 0
#define POWERSET2 64
#define POWERSET3 127
#define POWERSET4 192
#define POWERSET5 254

#define MAX_DEWPOWER 254

#define DEWMONITOR_AUTO_MODE 0  //Determine default Dew Monitor Mode. 0 = Automatic, 1 = Manual
#define DEWMONITOR_MANUAL_MODE 1     //Determine default Dew Monitor Mode. 0 = Automatic, 1 = Manual
int dewMonitorMode = DEWMONITOR_AUTO_MODE;

#define DEWPOINT_DEF_THRESHOLD 5    // Threshold of min temp of the dewbands. Calculated Dewpoint + This Threshold is the minimum temp for a dewband.
#define DEWBAND_DEF_MINTEMP 7       // Minimum temp of a dewband. This values needs to be equal or above the DEWPOINT_DEF_THRESHOLD.

#define TEMP_DEF_DIFF_BEFORE_UPDATE 2   //Default Temp Difference before a power update will be applied.
#define POWER_DEF_UPDATE_INTERVAL 30    //Default Time interval (sec) before a power update will be applied.
#define ADJUST_DEF_POWER_FIXPERCENTAGE 1  //Determine default power adjustment method. Default is in fixed percentage (POWERSET1 - POWERSET5)

// Dew variables that can be changed and will be stored in EEPROM Memory. They have a default value as defined above.
struct dew_config {
  int dewThreshold;
  int minDewBandTemp;
  int tempDiffBeforeUpdate;
  int powerUpdateInterval; 
  int adjustPowerFixPercentage;   
  byte Saved;
} dewConfig;

double ObsTemp = 0;
double DewPoint = 0;

double prevObsTemp = 0;
double prevDewPoint = 0;

double Humidity = 0;

double DewBandTmp1 = 0;
double DewBandPwr1 = 0;  //Value between 0 - 254
int DewBandPwrPct1 = 0; //In Percentage

double DewBandTmp2 = 0;
double DewBandPwr2 = 0;  //Value between 0 - 254
int DewBandPwrPct2 = 0; //In Percentage

unsigned long DispTimer;
unsigned long UpdTimer; 
int DispHeater = 0;

Timer updateTimer;
int powerTimer = 0;

bool SHT31Error = false;

bool DataAvailable = false;

//int dewMonitorMode = DEWMONITOR_DEF_MODE;          // On Startup the Dew Monitor will always run in Automatic Mode.

Adafruit_SHT31 sht; //I2C

OneWire tSensor1(PIN_TEMP_SENSOR1);
OneWire tSensor2(PIN_TEMP_SENSOR2);

DallasTemperature sensor1(&tSensor1);
DallasTemperature sensor2(&tSensor2);

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End ObservingConditions Definitions */

/* Start of ObservingConditions functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

/* Init Section */

void InitObservingConditions()
{
  Serial.println("Init EEPROM data..");
  EEPROMLoad();
  
  InitSHT();

  InitDewChannel1();

  InitDewChannel2();

  DispTimer = millis() / 1000;  // start time interval for display updates
  DispHeater = 2;             // Which heater to show first on the dispay

  delay(5000);

  updateTimer.every((TEMP_UPDATE_INTERVAL * 1000), Timer_Function_UpdateObservingConditionsData);
 
  Serial.println("Init Dew Mon Completed");

  CollectData();
  prevObsTemp = ObsTemp;
  prevDewPoint = DewPoint;

  Serial.println("Switching to Auto Mode!");
  dewMonitorMode = DEWMONITOR_AUTO_MODE;
}

void InitSHT()
{
  Serial.println("Init SHT31");
  SHT31Error = !sht.begin(SHT31_I2C_Address);
  delay(1000);
  if (!SHT31Error)
    SHT31Error = GetSHTData();

  if (SHT31Error)
    Serial.println("SHT31 Init Failed");
}

void InitDewChannel1()
{
  Serial.println("Init Dew Channel 1");
  pinMode(PIN_DEW_CHANNEL1, OUTPUT);            // pwm outputs for dew straps
  sensor1.begin();
  sensor1.setResolution(TEMP_PRECISION);
  sensor1.requestTemperatures();                // Send the command to get temperature readings
  delay(1000);
}

void InitDewChannel2()
{
  Serial.println("Init Dew Channel 2");
  pinMode(PIN_DEW_CHANNEL2, OUTPUT);            // pwm outputs for dew straps  
  sensor2.begin();
  sensor2.setResolution(TEMP_PRECISION);
  sensor2.requestTemperatures();                // Send the command to get temperature readings
  delay(1000);
}

/* End Init Section */

/* Update Display */

void UpdateDisplayData()
{
  unsigned long CurrentTime = millis() / 1000;
  updateTimer.update();

  if (ShowData && (LCDPresent==1))
  {
    if (((CurrentTime - DispTimer) > DISP_UPDATE_INTERVAL) || (CurrentTime < DispTimer))
    {
      DispTimer = CurrentTime;     // update the timestamp
            
      DetermineDewHeatertoDisplay();

      if (DispHeater == 1)
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewBandTmp1, DewBandPwrPct1, dewMonitorMode);
      else
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewBandTmp2, DewBandPwrPct2, dewMonitorMode);
    }
  }
}

void DetermineDewHeatertoDisplay()
{
  if (DispHeater == 1)
    DispHeater = 2;
  else
    DispHeater = 1;
}

/* End Update Display Data */

/* Get & Calculate Data */

boolean GetSHTData()
{
  float logEx;
  boolean anError;

  // Read temperature as Celsius (the default)
  ObsTemp = sht.readTemperature();

  Humidity = sht.readHumidity();
  // Read temperature as Celsius (the default)

  // Check if Temp or Humidity data from SHT31 has an error
  if (isnan(ObsTemp) || isnan(Humidity))
  {
    // if error reading SHT31 set all to 0
    ObsTemp = 0;
    Humidity = 0;
    DewPoint = 0;
    anError = true;
  }
  else 
  {
    DewPoint = calcDewPointSlow(ObsTemp,Humidity);
    anError = false;
  }

  if (isnan(DewPoint))
    DewPoint = 0;

  return anError;
}

//Dew point calculation as per: https://gist.github.com/Mausy5043/4179a715d616e6ad8a4eababee7e0281
double calcDewPointSlow(double celsius, double humidity)
{
        double RATIO = 373.15 / (273.15 + celsius);  // RATIO was originally named A0, possibly confusing in Arduino context
        double SUM = -7.90298 * (RATIO - 1);
        SUM += 5.02808 * log10(RATIO);
        SUM += -1.3816e-7 * (pow(10, (11.344 * (1 - 1/RATIO ))) - 1) ;
        SUM += 8.1328e-3 * (pow(10, (-3.49149 * (RATIO - 1))) - 1) ;
        SUM += log10(1013.246);
        double VP = pow(10, SUM - 3) * humidity;
        double T = log(VP/0.61078);   // temp var
        return (241.88 * T) / (17.558 - T);
}

// delta max = 0.6544 wrt dewPoint()
// 5x faster than dewPoint()
// reference: http://en.wikipedia.org/wiki/Dew_point
double calcDewPointFast(double celsius, double humidity)
{
        double a = 17.271;
        double b = 237.7;
        double temp = (a * celsius) / (b + celsius) + log(humidity*0.01);
        double Td = (b * temp) / (a - temp);
        return Td;
}

bool CollectData()
{
  bool DataAvailable = false;
  bool SHT31Error = GetSHTData();

  if (!SHT31Error)  // If there is BME data and in Dew Monitor in Automatic Mode
  {
    sensor1.requestTemperatures(); // Send the command to get temperature readings
    sensor2.requestTemperatures(); // Send the command to get temperature readings

    DewBandTmp1 = sensor1.getTempCByIndex(0);
    DewBandTmp2 = sensor2.getTempCByIndex(0);

    DataAvailable = true;
  }
  return DataAvailable;
}

int calcDewHeaterPowerSetting(double dewBandTemp)
{
  double tempDiff = 0;                                              // set output duty cycle on temp diff between Rain Sensor Temp and ambient dew point 
  int sensorPower = 0;
  double baselineTemp = DewPoint;                                   // Set Dewpoint as the baselineTemp for Dew Heater Power Calculation.

  if (dewBandTemp <= dewConfig.minDewBandTemp)                      // If the Dewband Temp = < than the Predefined Minimum Dewband Temp
      baselineTemp = dewConfig.minDewBandTemp;                      // then set the baselineTemp as the Predefineid Minimum Dewband Temp. 

  tempDiff = (((baselineTemp) + (dewConfig.dewThreshold)) - (dewBandTemp));   // Heater ON if  temp Diff  >  SensorTemp - (Baseline Temp(C) + Threshold(C))
  tempDiff = constrain(tempDiff, 0.0, dewConfig.dewThreshold);       // restrict between 0 & threshold
  sensorPower = MAX_DEWPOWER * (tempDiff / dewConfig.dewThreshold);   // PWM 0 - 100% duty cycle EQUIV TO analog 0 - 254

  if (dewConfig.adjustPowerFixPercentage == 1)
    sensorPower = calcAdjustedPower(sensorPower);
  
  return sensorPower;
}

// This function determines 1 of 5 preset power settings (0%, 25%, 50%, 75%, 100%) - see #define POWERSET1 - 5
// This is done by calculating the difference between sensorPower and the POWERSETx values. Which value is the lowest will determine the POWERSETx used.  
int calcAdjustedPower(int sensorPwr)
{
  int initPwr = abs(POWERSET1 - sensorPwr);
  int adjustedPwr = POWERSET1;

  if ((abs(POWERSET2 - sensorPwr)) < initPwr)
    adjustedPwr = POWERSET2;
  
  if ((abs(POWERSET3 - sensorPwr)) < adjustedPwr)
    adjustedPwr = POWERSET3;

  if ((abs(POWERSET4 - sensorPwr)) < adjustedPwr)
    adjustedPwr = POWERSET4;

  if ((abs(POWERSET5 - sensorPwr)) < adjustedPwr)
    adjustedPwr = POWERSET5;

  return adjustedPwr;
}

void CalculateData()
{
  if (DewBandTmp1 != TEMP_SENSOR_DISCONNECTED)
  {
    DewBandPwr1 = calcDewHeaterPowerSetting(DewBandTmp1);
    DewBandPwrPct1 = (DewBandPwr1 / MAX_DEWPOWER) * 100;
  }

  if (DewBandTmp2 != TEMP_SENSOR_DISCONNECTED)
  {      
    DewBandPwr2 = calcDewHeaterPowerSetting(DewBandTmp2);
    DewBandPwrPct2 = (DewBandPwr2 / MAX_DEWPOWER) * 100;
  }
}

/* End Get & Calculate Data */

// This function is called every 10 seconds 
void Timer_Function_UpdateObservingConditionsData()
{
  bool performPwrAdjust = false;
  
  if (CollectData())		//If collections of SHT31 the data & Dew Heaters temps is successful.
  {
    if (dewMonitorMode == DEWMONITOR_AUTO_MODE)  //If Dew Monitor in Auto mode, calculate power data.
    {
      powerTimer = powerTimer + TEMP_UPDATE_INTERVAL;	 //Increase PowerTimer by update interval.

      int tempDiff = abs(ObsTemp - prevObsTemp);	//Calculate Observatory temp diff from previous ObsTemp.
      int dewDiff = abs(DewPoint - prevDewPoint);	//Calculate Dewpoint diff from previous dewpoint.

	  // If Obs Temp diff bigger than preset or the PowerTimer update interval has been reached..
      if ((tempDiff >= dewConfig.tempDiffBeforeUpdate) || (powerTimer >= dewConfig.powerUpdateInterval))
      {
        CalculateData();			//Calculate Dewband power settings based on latest Observatory Temp and DewPoint.
        
        prevObsTemp = ObsTemp;		//Set Previous Observatory Temp variable.
        prevDewPoint = DewPoint;	//Set Previous DewPoint variable.
        performPwrAdjust = true;	
        powerTimer = 0;      		//Reset PowerTimer interval.
      }    
    }
    else
      performPwrAdjust = true;  //If Dew Monitor in manual mode always Adjust the Dew Power Settings according to the manual settings given.

    if (performPwrAdjust)		//If Power Adjustment is needed.
    {
      UpdateDewPower(1);		//Update Dew Power on Dewband 1.
      UpdateDewPower(2);		//Update Dew POwer on Dewband 2.
    }
    
    UpdTimer = millis() / 1000;  //Update Function Trigger timer.
  }
}

void UpdateDewPower(int DewChannel)
{
  int channelPin = PIN_DEW_CHANNEL2;
  double tmpDewPower = DewBandPwr2;

  if (DewChannel == 1)
  {
    channelPin = PIN_DEW_CHANNEL1;
    tmpDewPower = DewBandPwr1;
  }

  analogWrite(channelPin, tmpDewPower);   // set the PWM value to be 0-254    
}

/* ASCOM Interaction Section */

void DoObservingConditionsAction(String ASCOMcmd)
{  
  switch ((char)ASCOMcmd[0])
  {
    case 'c':                   // Dew Monitor Configuration Settings
      switch((char)ASCOMcmd[1])
      {
        case 'n':
          GetSetMinDewBandTemp(ASCOMcmd.substring(1));
          break;

        case 'q': //Get Set Dew Power in fixed Percentages
          GetSetPowerFixPercentageMode(ASCOMcmd.substring(1));
          break;    
      
        case 'p':
          GetSetPowerUpdateInterval(ASCOMcmd.substring(1));
          break;

        case 'd':
          GetSetDewThresholdUpdate(ASCOMcmd.substring(1));
          break;
    
        case 't':
          GetSetTempDiffBeforeUpdate(ASCOMcmd.substring(1));
          break;
      }
      break;

    case 'd': //Get the current Dew Point
      SendSerialCommand(observingconditionsId, String(DewPoint));
      break;

    case 'e': //Get DewHeater Temp
      GetDewHeaterTemp(ASCOMcmd);
      break;
    
    case 'h': //Get the current Humidity
      SendSerialCommand(observingconditionsId, String(Humidity));
      break;

    case 'm': //Get or Set Dew Monitor Mode (Manual or Auto)
      GetSetDewMonitorMode(ASCOMcmd);
      break;

    case 'i': //Get Time since last Sensor update (in Sec)
      SendSerialCommand(observingconditionsId, String(((millis() / 1000) - UpdTimer)));
      break;

    case 'p': //Get Set Dew Heater Power    
      GetSetDewHeaterPower(ASCOMcmd);
      break;
    
    case 'r':   //Refresh Sensor data manually
      Timer_Function_UpdateObservingConditionsData();
      break;

    case 't': //Get the temp of a Observatory Temp Sensor
      SendSerialCommand(observingconditionsId, String(ObsTemp));
      break;
       
    case 'z': //Return all data in a single string
      returnAllData();
      break;
  }
}

void GetDewHeaterTemp(String cmd)
{
  if (cmd[1] == '1')
    SendSerialCommand(observingconditionsId, String(DewBandTmp1));
  else
    SendSerialCommand(observingconditionsId, String(DewBandTmp2));
}

void GetSetDewHeaterPower(String cmd)
{
  if (cmd.length() > 3)
    SetDewHeaterPower(cmd);
  else
    GetDewHeaterPower(cmd);
}

void GetDewHeaterPower(String cmd)
{
  if (cmd[1] == '1')
    SendSerialCommand(observingconditionsId, String(DewBandPwrPct1));
  else
    SendSerialCommand(observingconditionsId, String(DewBandPwrPct2));
}

void SetDewHeaterPower(String cmd)
{
  int DewPower = cmd.substring(2).toInt();

  if (cmd[1] == '1')
  {
    DewBandPwrPct1 = DewPower;
    DewBandPwr1 = round(MAX_DEWPOWER * (DewBandPwrPct1 * 0.01));
    SendSerialCommand(observingconditionsId, String(DewBandPwrPct1));
  }
  else
  {
    DewBandPwrPct2 = DewPower;
    DewBandPwr2 = round(MAX_DEWPOWER * (DewBandPwrPct2 * 0.01));
    SendSerialCommand(observingconditionsId, String(DewBandPwrPct2));
  }
}

void GetSetDewMonitorMode(String cmd)
{
  if (cmd.length() > 1)
  {
    if (cmd[1] == '1')    // Set Dew Monitor to Manual
      dewMonitorMode = DEWMONITOR_MANUAL_MODE;
    else    
      dewMonitorMode = DEWMONITOR_AUTO_MODE;
  }
  SendSerialCommand(observingconditionsId, String(dewMonitorMode));
}

void GetSetPowerFixPercentageMode(String cmd)
{
  if (cmd.length() > 2)
  {
    if (cmd[1] == '1')    // Set Dew Monitor to Manual
      dewConfig.adjustPowerFixPercentage = 1;
    else    
      dewConfig.adjustPowerFixPercentage = 0;
    
    EEPROMSave();
  }
  SendSerialCommand(observingconditionsId, String(dewConfig.adjustPowerFixPercentage));
}

void GetSetPowerUpdateInterval(String cmd)
{
  if (cmd.length() > 2)
  {
    dewConfig.powerUpdateInterval = cmd.substring(1).toInt();
    EEPROMSave();
  }
  SendSerialCommand(observingconditionsId, String(dewConfig.powerUpdateInterval));
}

void GetSetDewThresholdUpdate(String cmd)
{
  if (cmd.length() > 2)
  {
    dewConfig.dewThreshold = cmd.substring(1).toInt();
    EEPROMSave();
  }
  SendSerialCommand(observingconditionsId, String(dewConfig.dewThreshold));
}

void GetSetMinDewBandTemp(String cmd)
{
  if (cmd.length() > 2)
  {
    dewConfig.minDewBandTemp = cmd.substring(1).toInt();
    EEPROMSave();
  }
  SendSerialCommand(observingconditionsId, String(dewConfig.minDewBandTemp));
}

void GetSetTempDiffBeforeUpdate(String cmd)
{
  if (cmd.length() > 2)
  {
    dewConfig.tempDiffBeforeUpdate = cmd.substring(1).toInt();
    EEPROMSave();
  }
  SendSerialCommand(observingconditionsId, String(dewConfig.tempDiffBeforeUpdate));
}

void returnAllData()
{
  String returnData = "";
  returnData += "d" + String(DewPoint) + "_";
  returnData += "e1" + String(DewBandTmp1) + "_";
  returnData += "e2" + String(DewBandTmp2) + "_";
  returnData += "h" + String(Humidity) + "_";
  returnData += "i" + String(((millis() / 1000) - UpdTimer)) + "_";
  returnData += "p1" + String(DewBandPwrPct1) + "_";
  returnData += "p2" + String(DewBandPwrPct2) + "_";
  returnData += "t" + String(ObsTemp) + "_";
  returnData += "m" + String(dewMonitorMode) + "_";
  returnData += "cn" + String((dewConfig.minDewBandTemp)) + "_";
  returnData += "cq" + String(dewConfig.adjustPowerFixPercentage) + "_";
  returnData += "cp" + String(dewConfig.powerUpdateInterval) + "_";
  returnData += "cw" + String(dewConfig.dewThreshold) + "_";
  returnData += "ct" + String(dewConfig.tempDiffBeforeUpdate);

  SendSerialCommand(observingconditionsId, returnData);
}

/* End of ASCOM Interaction Section */

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of ObservingConditions functions */
