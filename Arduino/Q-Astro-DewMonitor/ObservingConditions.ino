/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of ObservingConditions Commands */
/*

  This uses the oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs)
  OneWire can monitor multiple devices via one connection, for the Dew Monitor this will not work as we will not know
  which temp sensor is associated with which Dew Band.
  In our case we need to have 2 individual OneWire instances to enable us to diffirentiate between the 2 Dew bands and temp senssors.

*/

#define PIN_TEMP_SENSOR1  4 
#define PIN_DEW_CHANNEL1  3 

#define PIN_TEMP_SENSOR2  2 
#define PIN_DEW_CHANNEL2  5 

#define TEMP_UPDATE_INTERVAL 10      // in seconds
#define DISP_UPDATE_INTERVAL 5        // in seconds
#define SEA_LEVEL_PRESSURE_HPA (1013.25)
#define DEWPOINT_THRESHOLD 5
#define MIN_DEVICE_TEMP 10			  // This is the min temp that needs the device to be kept at. 
#define MAX_DEWPOWER 254
#define TEMP_PRECISION 9

#define MAX_DEWHEATERS 2

#define BME280_I2C_Address (0x76)

#define DEWMONITOR_MODE 0     //Determine default Dew Monitor Mode. 0 = Automatic, 1 = Manual

double ObsTemp;
double Altitude;
double DewPoint;

double Humidity;
double Pressure;

double DewTemp1;
int DewPower1;  //In Percentage

double DewTemp2;
int DewPower2;  //In Percentage

int DispTimer;
int UpdTimer; 
int DispHeater;

Timer updateTimer;

bool BME280Error = false;
bool DataAvailable = false;

int DewMonitorMode = DEWMONITOR_MODE;          // On Startup the Dew Monitor will always run in Automatic Mode.

Adafruit_BME280 bme; // I2C

OneWire tSensor1(PIN_TEMP_SENSOR1);
OneWire tSensor2(PIN_TEMP_SENSOR2);

DallasTemperature sensor1(&tSensor1);
DallasTemperature sensor2(&tSensor2);

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End ObservingConditions Definitions */

/* Start of ObservingConditions functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void InitObservingConditions()
{
  InitDewChannel1();

  InitDewChannel2();

  DispTimer = millis() / 1000;  // start time interval for display updates
  DispHeater = 2;             // Which heater to show first on the dispay

  bme.begin(BME280_I2C_Address);

  updateTimer.every((TEMP_UPDATE_INTERVAL * 1000), UpdateObservingConditionsData);
}

void InitDewChannel1()
{
  pinMode(PIN_DEW_CHANNEL1, OUTPUT);            // pwm outputs for dew straps
  sensor1.begin();
  sensor1.setResolution(TEMP_PRECISION);
  sensor1.requestTemperatures();                // Send the command to get temperature readings
  delay(1000);
}

void InitDewChannel2()
{
  pinMode(PIN_DEW_CHANNEL2, OUTPUT);            // pwm outputs for dew straps  
  sensor2.begin();
  sensor2.setResolution(TEMP_PRECISION);
  sensor2.requestTemperatures();                // Send the command to get temperature readings
  delay(1000);
}

void UpdateData()
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
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewTemp1, DewPower1, DewMonitorMode);
      else
        WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewTemp2, DewPower2, DewMonitorMode);
    }
  }
}

void UpdateObservingConditionsData()
{
  DataAvailable = true;

  BME280Error = GetBMEData();

  if (DewMonitorMode == 1)      // If Dew Monitor in Manual Mode
  {
    sensor1.requestTemperatures(); // Send the command to get temperature readings
    UpdateManualDewPower(1);
      
    sensor2.requestTemperatures(); // Send the command to get temperature readings
    UpdateManualDewPower(2);
  }
  else
  {   
    if (BME280Error == false)  // If there is BME data and in Dew Monitor in Automatic Mode
    {
      sensor1.requestTemperatures(); // Send the command to get temperature readings
      UpdateAutoDewPower(1);

      sensor2.requestTemperatures(); // Send the command to get temperature readings
      UpdateAutoDewPower(2);
    }
    else
      DataAvailable = false;
  }
  if (DataAvailable)      // If Data Available then update the update last timer to 0
    UpdTimer = millis() / 1000;
}

void DetermineDewHeatertoDisplay()
{
  if (DispHeater == 1)
    DispHeater = 2;
  else
    DispHeater = 1;
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

void UpdateAutoDewPower(int DewChannel)
{
  double Temp = GetSensorTemp(DewChannel);
  int DewPower = 0;

  if (Temp != 99)
  {
    if (Temp > MIN_DEVICE_TEMP)
        DewPower = calcDewHeaterPowerSetting(Temp, DewPoint);
    else
        DewPower = calcDewHeaterPowerSetting(Temp, MIN_DEVICE_TEMP);
  }

  switch (DewChannel)
  {
    case 1:
      DewTemp1 = Temp;
      DewPower1 = (DewPower / MAX_DEWPOWER) * 100;  // Return Power in value of % for GUI.
      analogWrite(PIN_DEW_CHANNEL1, DewPower);  // set the PWM value to be 0-254    
        
      break;
    case 2:
      DewTemp2 = Temp;
      DewPower2 = (DewPower / MAX_DEWPOWER) * 100;   // Return Power in value of % for GUI.
      analogWrite(PIN_DEW_CHANNEL2, DewPower);   // set the PWM value to be 0-254    
        
      break;
  }
}

void UpdateManualDewPower(int DewChannel)   // DewPower is in percentage
{
  double Temp = GetSensorTemp(DewChannel);
  int DewPower = 0;

  switch (DewChannel)
  {
    case 1:
      DewTemp1 = Temp;
      DewPower = round(MAX_DEWPOWER * (DewPower1 / 100));
      analogWrite(PIN_DEW_CHANNEL1, DewPower);   // set the PWM value to be 0-254    
      break;

    case 2:
      DewTemp2 = Temp;
      DewPower = round(MAX_DEWPOWER * (DewPower2 / 100));
      analogWrite(PIN_DEW_CHANNEL2, DewPower);   // set the PWM value to be 0-254    
      break;
  }
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

boolean GetBMEData()
{
  float logEx;
  boolean anError;

  // Read temperature as Celsius (the default)
  ObsTemp = bme.readTemperature();

  Pressure = round((bme.readPressure() / 100.0F));

  Humidity = bme.readHumidity();
  // Read temperature as Celsius (the default)

  Altitude = bme.readAltitude(SEA_LEVEL_PRESSURE_HPA);
  Pressure = round((bme.readPressure() / 100.0F));

  // Check if Temp or Humidity data from BME280 has an error
  if (isnan(ObsTemp) || isnan(Humidity))
  {
    // if error reading BME280 set all to 0
    ObsTemp = 0;
    Humidity = 0;
    DewPoint = 0;
    Pressure = 0;
    Altitude = 0;
    anError = true;
  }
  else 
  {
    // if no error reading DHT22 calc dew point
    // more complex dew point calculation
    logEx = 0.66077 + 7.5 * ObsTemp / (237.3 + ObsTemp) + (log10(Humidity) - 2);
    DewPoint = (logEx - 0.66077) * 237.3 / (0.66077 + 7.5 - logEx);
    anError = false;
  }

  if (isnan(DewPoint))
    DewPoint = 0;

  return anError;
}

void DoObservingConditionsAction(String ASCOMcmd)
{  
  switch ((char)ASCOMcmd[0])
  {
    case 'a': //Get the current Altitude 
      SendSerialCommand(observingconditionsId, String(Altitude));
      break;

    case 'b': //Get the current Pressure
      SendSerialCommand(observingconditionsId, String(Pressure));
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

    case 'i': //Get Time since last Sensor update (in Sec)
      SendSerialCommand(observingconditionsId, String(((millis() / 1000) - UpdTimer)));
      break;

    case 'm': //Set Dew Monitor Mode (Manual or Auto)
      SetDewMonitorMode(ASCOMcmd);
      break;

    case 'n': //Get Dew Monitor Mode (Manual or Auto)
      SendSerialCommand(observingconditionsId, String(DewMonitorMode));
      break;

    case 'o': //Set Power on Channel when running in Manual Mode
      GetSetDewHeaterPower(ASCOMcmd);
      break;

    case 'p': //Get Dew Heater Power    
      GetSetDewHeaterPower(ASCOMcmd);
      break;
 
    case 't': //Get the temp of a Temp Sensor
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
    SendSerialCommand(observingconditionsId, String(DewTemp1));
  else
    SendSerialCommand(observingconditionsId, String(DewTemp2));
}

void GetSetDewHeaterPower(String cmd)
{
  if (cmd.length() > 2)
    SetDewHeaterPower(cmd);
  else
    GetDewHeaterPower(cmd);
}

void GetDewHeaterPower(String cmd)
{
  if (cmd[1] == '1')
    SendSerialCommand(observingconditionsId, String(DewPower1));
  else
    SendSerialCommand(observingconditionsId, String(DewPower2));
}

void SetDewHeaterPower(String cmd)
{
  int DewPower = cmd.substring(2).toInt();
  if (cmd[1] == '1')
  {
    DewPower1 = DewPower;
    SendSerialCommand(observingconditionsId, String(DewPower1));
  }
  else
  {
    DewPower2 = DewPower;
    SendSerialCommand(observingconditionsId, String(DewPower2));
  }
}

void SetDewMonitorMode(String cmd)
{
  if (cmd[1] == '1')    // Set Dew Monitor to Manual
    DewMonitorMode = 1;
  else    
    DewMonitorMode = 0;

  SendSerialCommand(observingconditionsId, String(DewMonitorMode));
}

void returnAllData()
{
  String returnData = "";
  returnData += "a" + String(Altitude) + "_";
  returnData += "d" + String(DewPoint) + "_";
  returnData += "e1" + String(DewTemp1) + "_";
  returnData += "e2" + String(DewTemp2) + "_";
  returnData += "h" + String(Humidity) + "_";
  returnData += "i" + String(((millis() / 1000) - UpdTimer)) + "_";
  returnData += "m" + String(DewMonitorMode) + "_";
  returnData += "o1" + String(DewPower1) + "_";
  returnData += "o2" + String(DewPower2) + "_";
  returnData += "p" + String(Pressure) + "_";
  returnData += "t" + String(ObsTemp);

  SendSerialCommand(observingconditionsId, returnData);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of ObservingConditions functions */
