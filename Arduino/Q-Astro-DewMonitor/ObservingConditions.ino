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

#define TEMP_UPDATE_INTERVAL 10      // in seconds
#define DISP_UPDATE_INTERVAL 5        // in seconds

#define DEWPOINT_THRESHOLD 5
#define MIN_DEVICE_TEMP 5			  // This is the min temp that needs the device to be kept at. 
#define MAX_DEWPOWER 254
#define TEMP_PRECISION 9

#define SHT31_I2C_Address (0x44)

#define DEWMONITOR_MODE 1     //Determine default Dew Monitor Mode. 0 = Automatic, 1 = Manual

double ObsTemp;
double DewPoint;

double prevObsTemp = 0;
double prevDewPoint = 0;
#define TEMP_DIFF_BEFORE_UPDATE 2
#define DEW_DIFF_BEFORE_UPDATE 2

double Humidity;

double DewBandTmp1;
double DewBandPwr1 = 0;  //Value between 0 - 254
int DewBandPwrPct1 = 0; //In Percentage

double DewBandTmp2;
double DewBandPwr2 = 0;  //Value between 0 - 254
int DewBandPwrPct2 = 0; //In Percentage

int DispTimer;
int UpdTimer; 
int DispHeater;

Timer updateTimer;
int powerTimer = 0;
#define POWERUPDATEINTERVAL 60

bool SHT31Error = false;

bool DataAvailable = false;

int DewMonitorMode = DEWMONITOR_MODE;          // On Startup the Dew Monitor will always run in Automatic Mode.

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
  InitSHT();

  InitDewChannel1();

  InitDewChannel2();

  DispTimer = millis() / 1000;  // start time interval for display updates
  DispHeater = 2;             // Which heater to show first on the dispay

  delay(5000);

  updateTimer.every((TEMP_UPDATE_INTERVAL * 1000), Timer_Function_UpdateObservingConditionsData);
 
  Serial.println("Init Dew Mon Completed");
  
  Serial.println("Switching to Auto Mode!");
  DewMonitorMode = 0;
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
  int CurrentTime = millis() / 1000;
  updateTimer.update();

  if (ShowData && DataAvailable && (LCDPresent==1))
  {
    if (((CurrentTime - DispTimer) > DISP_UPDATE_INTERVAL) || (CurrentTime < DispTimer))
    {
      DispTimer = CurrentTime;     // update the timestamp
            
      DetermineDewHeatertoDisplay();

      if (DispHeater == 1)
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewBandTmp1, DewBandPwr1, DewMonitorMode);
      else
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewBandTmp2, DewBandPwr2, DewMonitorMode);
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

double GetSensorTemp(int sensor)
{
  double dTemp;

  if (sensor == 1)
      dTemp = sensor1.getTempCByIndex(0);
  else
      dTemp = sensor2.getTempCByIndex(0);

  if (dTemp == DEVICE_DISCONNECTED_C)
    return 99;
  else 
    return dTemp;
}

bool CollectData()
{
  bool DataAvailable = false;
  bool SHT31Error = GetSHTData();

  if (!SHT31Error)  // If there is BME data and in Dew Monitor in Automatic Mode
  {
    sensor1.requestTemperatures(); // Send the command to get temperature readings
    sensor2.requestTemperatures(); // Send the command to get temperature readings

    DewBandTmp1 = GetSensorTemp(1);
    DewBandTmp2 = GetSensorTemp(2);

    DataAvailable = true;
  }
  return DataAvailable;
}

int calcDewHeaterPowerSetting(double SensorTemp, double minTemp)
{
  double tempDiff = 0;                                              // set output duty cycle on temp diff between Rain Sensor Temp and ambient dew point 
  int requiredSensorPower = 0;
  int sensorPower = 0;

  tempDiff = (minTemp + DEWPOINT_THRESHOLD) - SensorTemp;           // Heater ON if  temp Diff  >  SensorTemp - (Dew Point(C) + Threshold(C))
  tempDiff = constrain(tempDiff, 0.0, DEWPOINT_THRESHOLD);       // restrict between 0 & threshold
  sensorPower = MAX_DEWPOWER * (tempDiff / DEWPOINT_THRESHOLD);   // PWM 0 - 100% duty cycle EQUIV TO analog 0 - 254

  return sensorPower;
}

void CalculateData()
{
  double calcDewPoint = DewPoint;
  
  if (DewBandTmp1 != -99)
  {
    calcDewPoint = DewPoint;
      
    if (DewBandTmp1 <= MIN_DEVICE_TEMP)
      calcDewPoint = MIN_DEVICE_TEMP;
      
    DewBandPwr1 = calcDewHeaterPowerSetting(DewBandTmp1, calcDewPoint);
    DewBandPwrPct1 = (DewBandPwr1 / MAX_DEWPOWER) * 100;
  }

  if (DewBandTmp2 != -99)
  {
    calcDewPoint = DewPoint;
      
    if (DewBandTmp2 <= MIN_DEVICE_TEMP)
       calcDewPoint = MIN_DEVICE_TEMP;
      
    DewBandPwr2 = calcDewHeaterPowerSetting(DewBandTmp2, calcDewPoint);
    DewBandPwrPct2 = (DewBandPwr2 / MAX_DEWPOWER) * 100;
  }
}

/* End Get & Calculate Data */

// This function is called every 10 seconds 
void Timer_Function_UpdateObservingConditionsData()
{
  bool performUpdate = false;
  
  if (CollectData())
  {

    if (DewMonitorMode == 0)  //If Dew Monitor in Auto mode, calculate power data.
    {
      CalculateData();

      powerTimer = powerTimer + TEMP_UPDATE_INTERVAL;

      int tempDiff = abs(ObsTemp - prevObsTemp);
      int dewDiff = abs(DewPoint - prevDewPoint);

      if (((tempDiff >= TEMP_DIFF_BEFORE_UPDATE) || (dewDiff >= DEW_DIFF_BEFORE_UPDATE)) && (powerTimer >= POWERUPDATEINTERVAL))
      {
        performUpdate = true;
        powerTimer = 0;      
      }    
    }
    else
      performUpdate = true;

    if (performUpdate)
    {
      UpdateDewPower(1);
      UpdateDewPower(2);
    }
    
    UpdTimer = millis() / 1000;
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
    case 'd': //Get the current Dew Point
      SendSerialCommand(observingconditionsId, String(DewPoint));
      break;

    case 'e': //Get DewHeater Temp
      GetDewHeaterTemp(ASCOMcmd);
      break;
    
    case 'h': //Get the current Humidity
      SendSerialCommand(observingconditionsId, String(Humidity));
      break;

    case 'i': //Get Time since last Sensor update (in Sec)
      SendSerialCommand(observingconditionsId, String(((millis() / 1000) - UpdTimer)));
      break;

    case 'm': //Get or Set Dew Monitor Mode (Manual or Auto)
      GetSetDewMonitorMode(ASCOMcmd);
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
      DewMonitorMode = 1;
    else    
      DewMonitorMode = 0;
  }
  SendSerialCommand(observingconditionsId, String(DewMonitorMode));
}

void returnAllData()
{
  String returnData = "";
  returnData += "d" + String(DewPoint) + "_";
  returnData += "e1" + String(DewBandTmp1) + "_";
  returnData += "e2" + String(DewBandTmp2) + "_";
  returnData += "h" + String(Humidity) + "_";
  returnData += "i" + String(((millis() / 1000) - UpdTimer)) + "_";
  returnData += "m" + String(DewMonitorMode) + "_";
  returnData += "p1" + String(DewBandPwrPct1) + "_";
  returnData += "p2" + String(DewBandPwrPct2) + "_";
  returnData += "t" + String(ObsTemp);

  SendSerialCommand(observingconditionsId, returnData);
}

/* End of ASCOM Interaction Section */

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of ObservingConditions functions */
