/*
 * Q-Astro Dew Monitor
 *
 * Q-Astro Dew Monitor Code.
 * Version: 3.0.0
 * 
 * Copyright (c)2020 Quidne IT Ltd.
 * 
 */

#include <Arduino.h>
#include <DallasTemperature.h>
#include "SSD1306Ascii.h"
#include "SSD1306AsciiAvrI2c.h"
#include <Adafruit_Sensor.h>
#include "QAstro_BME280.h"
#include "Timer.h"
#include <EEPROM.h>

#define DEVICE_RESPONSE "Q-Astro Dew Monitor ver 3.0.0"

#define qastroId 'i'
#define observingconditionsId 'o'

String ASCOMcmd;
bool ASCOMcmdComplete;

bool ShowData = false;
int DisplayAlwaysOn = 0;

void setup() 
{
  InitSerial();
//  InitOLEDLCD();
  InitObservingConditions();
}

void loop() {

  if (ASCOMcmdComplete) {

    switch((char)ASCOMcmd[0]) {
      case qastroId:
          SendSerialCommand(DEVICE_RESPONSE);
        break;

      case observingconditionsId: //Case fhe function is for the Environmentals
        DoObservingConditionsAction(ASCOMcmd.substring(1)); //Remove first char from string as this is the function type.
      break;
    }
    
    ASCOMcmdComplete = false;
    ASCOMcmd = "";
  }

  CheckShowDataButton();

  UpdateData();
}
