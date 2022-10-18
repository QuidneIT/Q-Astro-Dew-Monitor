/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of OLED Commands */

SSD1306AsciiAvrI2c display; 

#define OLED_RESET 4
#define OLED_I2C_ADDRESS 0x3C
#define PIN_SHOW 12

int val = 0;
unsigned long onTime;

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End OLED Definitions */

/* Start of OLED functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void InitOLEDLCD()
{ 
  // initialize and clear display
  #if OLED_RESET >= 0
    display.begin(&Adafruit128x64, OLED_I2C_ADDRESS, OLED_RESET);
  #else // RST_PIN >= 0
    display.begin(&Adafruit128x64, OLED_I2C_ADDRESS);
  #endif // RST_PIN >= 0
  pinMode(PIN_SHOW, INPUT);
  
  DisplayAlwaysOn = 0;
  ShowQAstro();
}

void ShowQAstro()
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

void CheckShowDataButton()
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

void switchonDisplay()
{
  ShowData=true;
  onTime = millis();  
}

void switchoffDisplay()
{
  ShowData=false;
  onTime = 0;
  display.clear();
}

void WriteLCD(double sTemp, int hum, double dPoint,int hHeater, double hTemp, int hPower)
{
    display.setFont(System5x7);
    display.clear();
    display.println("Collected Data");
    display.println("");
  
    display.print("Sky Temp:     ");
    display.print(sTemp);
    display.println("c");
  
    display.print("Humidity:     ");
    display.print(hum);
    display.println("%");
  
    display.print("Dew Point:    ");
    display.print(dPoint);
    display.println("c");
  
    display.print("Heater ");
    display.print(hHeater);
    display.print(" Tmp: ");
    if (hTemp != 99)
    {
      display.print(hTemp);
      display.println("c");
    }
    else
      display.println("NC");

    display.print("Heater ");
    display.print(hHeater);
    display.print(" Pwr: ");
    display.print(hPower);
    display.println("%");
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of OLED functions */
