/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of ObservingConditions Commands */
/*
  Data wire is plugged into pin 24 on the Arduino Mega 
  This uses the oneWire instance to communicate with any OneWire devices (not just Maxim/Dallas temperature ICs) 

  !!!!!!!!!  If Arduino has updated Lib Adafruit_BME280.h, make sure to change the address in that file to 76.
*/

#define PIN_TEMP_SENSOR1  4 //Use 2 on board v1.5
#define PIN_DEW_CHANNEL1  3 //Use 6 on board v1.5

#define PIN_TEMP_SENSOR2  2 //Use 3 on board v1.5
#define PIN_DEW_CHANNEL2  5 // Not changed between boards

#define TEMP_UPDATE_INTERVAL  10      // in seconds
#define DISP_UPDATE_INTERVAL 5        // in seconds
#define SEA_LEVEL_PRESSURE_HPA (1013.25)
#define DEWPOINT_THRESHOLD 5
#define MIN_DEVICE_TEMP 10			  // This is the min temp that needs the device to be kept at. 
#define MAX_DEWPOWER 254

#define MAX_DEWHEATERS 2
#define hEEPROMStart 100

double ObsTemp;
double Altitude;
double DewPoint;
int Humidity;
int Pressure;

int DewHeatersInUse = MAX_DEWHEATERS;

double DewTemp1;
double DewPower1;  //In Percentage

double DewTemp2;
double DewPower2;  //In Percentage

int TempTimer; 
int DispHeater;

Timer updateTimer;

bool BME280Error = false;
bool DataAvailable = false;

QAstro_BME280 bme; // I2C

OneWire tSensor1(PIN_TEMP_SENSOR1);
OneWire tSensor2(PIN_TEMP_SENSOR2);

DallasTemperature sensor1(&tSensor1);
DallasTemperature sensor2(&tSensor2);

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End ObservingConditions Definitions */

/* Start of ObservingConditions functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void DoObservingConditionsAction(String ASCOMcmd)
{  
    switch ((char)ASCOMcmd[0])
    {
        //Get the temp of a Temp Sensor
    case 't':
        SendSerialCommand(observingconditionsId, String(ObsTemp));
        break;

    case 'h':
        SendSerialCommand(observingconditionsId, String(Humidity));
        break;

    case 'd':
        SendSerialCommand(observingconditionsId, String(DewPoint));
        break;

    case 'a':
        SendSerialCommand(observingconditionsId, String(Altitude));
        break;

    case 'b':
        SendSerialCommand(observingconditionsId, String(Pressure));
        break;

    case 'w': //Get DewHeater Temp

        GetDewHeaterTemp(ASCOMcmd);
        break;

    case 'p': //Get Dew Heater Power
    
        GetDewHeaterPower(ASCOMcmd);
        break;
 
    case 'i': //Get Time since last Sensor update (in Sec)
        SendSerialCommand(observingconditionsId, String(((millis() / 1000) - TempTimer)));
        break;

    case 'z':   //return all data in a single string
        returnAllData();
        break;

    case 's':   //Set Number of Dew Heaters in Use (Max is 2)
        EEPROMWriteInt(hEEPROMStart, ASCOMcmd.substring(1,1).toInt());
        DewHeatersInUse = EEPROMReadInt(hEEPROMStart);
        break;
    }
}

void InitObservingConditions()
{
    pinMode(PIN_DEW_CHANNEL1, OUTPUT);            // pwm outputs for dew straps
    pinMode(PIN_DEW_CHANNEL2, OUTPUT);            // pwm outputs for dew straps

    int memNrOfDewHeaters = EEPROMReadInt(hEEPROMStart);
    if ((memNrOfDewHeaters == 1) || (memNrOfDewHeaters == 2))
        DewHeatersInUse = memNrOfDewHeaters;

    TempTimer = millis() / 1000;  // start time interval for display updates
    DispHeater = 2;             // Which heater to show first on the dispay

    bme.begin();

    updateTimer.every((TEMP_UPDATE_INTERVAL * 1000), UpdateObservingConditionsData, 0);
}

void GetDewHeaterTemp(String cmd)
{
    if (cmd[1] == '1')
        SendSerialCommand(observingconditionsId, String(DewTemp1));
    else if (DewHeatersInUse > 1)
        SendSerialCommand(observingconditionsId, String(DewTemp2));
}

void GetDewHeaterPower(String cmd)
{
    if (cmd[1] == '1')
        SendSerialCommand(observingconditionsId, String(DewPower1));
    else if (DewHeatersInUse > 1)
        SendSerialCommand(observingconditionsId, String(DewPower2));
}

void UpdateData()
{
    int CurrentTime = millis() / 1000;
    updateTimer.update();

    if (ShowData && DataAvailable)
    {
        if (((CurrentTime - TempTimer) > DISP_UPDATE_INTERVAL) || (CurrentTime < TempTimer))
        {
            TempTimer = CurrentTime;     // update the timestamp
            
            if (DewHeatersInUse == 2)
              DetermineDewHeatertoDisplay();
            else
              DispHeater == 1;

            if (DispHeater == 1)
                WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewTemp1, DewPower1);
            else
                WriteLCD(ObsTemp, Humidity, DewPoint, DispHeater, DewTemp2, DewPower2);
        }
    }
}

void UpdateObservingConditionsData()
{
    BME280Error = GetBMEData();
    if (BME280Error == false)
    {
        sensor1.requestTemperatures(); // Send the command to get temperature readings
        UpdateDewPower(1);

        if (DewHeatersInUse == 2)
        {
            sensor2.requestTemperatures(); // Send the command to get temperature readings
            UpdateDewPower(2);
        }
        DataAvailable = true;
    }
    else
      DataAvailable = false;
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

//    if (dTemp == -127.00)   //If Sensor not connected, return value will be -127. If the case then the dew manager should not do anything.
//        return 99;

    if ((dTemp != -127.00) && (dTemp != 85.00))
        return dTemp;
    else
        return 99;
}

void UpdateDewPower(int DewChannel)
{
    double Temp = GetSensorTemp(DewChannel);
    double DewPower = 0;
    Temp=18.00;

    if (Temp != 999)
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

int calcDewHeaterPowerSetting(double SensorTemp, double minTemp)
{
    double tempDiff = 0;                                              // set output duty cycle on temp diff between Rain Sensor Temp and ambient dew point 
    double requiredSensorPower = 0;
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

    Humidity = bme.readHumidity();
    // Read temperature as Celsius (the default)
    ObsTemp = bme.readTemperature();
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
    else {
        // if no error reading DHT22 calc dew point
        // more complex dew point calculation
        logEx = 0.66077 + 7.5 * ObsTemp / (237.3 + ObsTemp) + (log10(Humidity) - 2);
        DewPoint = (logEx - 0.66077) * 237.3 / (0.66077 + 7.5 - logEx);
        anError = false;
    }

    if (isnan(DewPoint))
    {
        DewPoint = 0;
    }
    return anError;
}

void returnAllData()
{
    String returnData = "";
    returnData += "t" + String(ObsTemp) + "_";
    returnData += "a" + String(Altitude) + "_";
    returnData += "d" + String(DewPoint) + "_";
    returnData += "h" + String(Humidity) + "_";
    returnData += "p" + String(Pressure) + "_";
    returnData += "v" + String(DewTemp1) + "_";
    returnData += "w" + String(DewTemp2) + "_";
    returnData += "x" + String(DewPower1) + "_";
    returnData += "y" + String(DewPower2) + "_";
    returnData += "i" + String(((millis() / 1000) - TempTimer));

    SendSerialCommand(observingconditionsId, returnData);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of ObservingConditions functions */
