/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of OLED Commands */

SSD1306AsciiAvrI2c display; 

#define OLED_RESET 4
#define OLED_I2C_ADDRESS 0x3C
#define PIN_SHOW 12

int val = 0;
unsigned long onTime;

bool LCDPresent = true;    //Change this to 0 if you do not use the LCD display.

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End OLED Definitions */

/* Start of OLED functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void InitOLEDLCD()
{ 
  Serial.println("Init OLED...");

  CheckOLEDConnected();

  if (LCDPresent)
  {
    Serial.println("OLED Present");
    // initialize and clear display    
    display.begin(&Adafruit128x64, OLED_I2C_ADDRESS, OLED_RESET);
    pinMode(PIN_SHOW, INPUT);
  
    DisplayAlwaysOn = 0;
    ShowQAstro();
  }
  else
    Serial.println("OLED not Present!!");

  Serial.println("OLED Init Completed");
}

void CheckOLEDConnected()
{
  Wire.beginTransmission(OLED_I2C_ADDRESS);
  if (Wire.endTransmission() != 0)
    LCDPresent = false;
}

void ShowQAstro()
{
  if (LCDPresent)
  {
    switchonDisplay();
    display.setFont(System5x7);
    display.clear();
    display.println(DEVICE_RESPONSE);
    display.println(VERSION);
    display.println("");
    display.println("by");
    display.println("Quidne IT Ltd.");
    display.println("");
    display.println("Loading...");
  }
}

void CheckShowDataButton()
{
  if (LCDPresent)
  {  
    val = digitalRead(PIN_SHOW);  // read input value
    if (val == HIGH)
    { 
      switchonDisplay();
      DisplayAlwaysOn = 0;
    }

    if (DisplayAlwaysOn == 0)
    {
      if ((onTime > 0) && ((millis() - onTime) > 20000))
        switchoffDisplay();
    }
  }
}

void switchonDisplay()
{
  if (LCDPresent)
  {
    ShowData=true;
    onTime = millis();  
  }
}

void switchoffDisplay()
{
  if (LCDPresent)
  {
    ShowData=false;
    onTime = 0;
    display.clear();
  }
}

void WriteLCD(double sTemp, int hum, double dPoint,int hHeater, double hTemp, int hPower, int hManual)
{
  if (LCDPresent)
  {
    display.setFont(System5x7);
    display.clear();
    display.println("Collected Data");
    display.println("");
  
    display.print("Sky Temp     : ");
    display.print(sTemp);
    display.println("c");
  
    display.print("Humidity     : ");
    display.print(hum);
    display.println("%");
  
    display.print("Dew Point    : ");
    display.print(dPoint);
    display.println("c");
  
    display.print("Heater ");
    display.print(hHeater);
    display.print(" Tmp : ");
    if (hTemp != -127)
    {
      display.print(hTemp);
      display.println("c");
    }
    else
      display.println("NC");

    display.print("Heater ");
    display.print(hHeater);
    display.print(" Pwr : ");
    display.print(hPower);
    display.println("%");

    display.print("Mode         : ");
    if (hManual == 0)
      display.println("Auto");
    else 
      display.println("Manual");
  }
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of OLED functions */
