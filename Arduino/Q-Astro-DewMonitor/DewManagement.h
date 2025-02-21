/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of ObservingConditions Definition */
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
//#define DEWBAND_DEF_MINTEMP 7       // Minimum temp of a dewband. This values needs to be equal or above the DEWPOINT_DEF_THRESHOLD.

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
