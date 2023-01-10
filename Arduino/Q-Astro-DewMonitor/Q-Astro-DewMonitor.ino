/*
 * Q-Astro Dew Monitor
 * 
 * Copyright (c)2023 Quidne IT Ltd.
 * 
 */

#define DEVICE_RESPONSE "Q-Astro Dew Monitor"
#define VERSION "v4.3.1"

#include <Arduino.h>
#include <OneWire.h>

#include <DallasTemperature.h>

#include <SSD1306Ascii.h>
#include <SSD1306AsciiAvrI2c.h>
#include <Wire.h>

#include <Adafruit_Sensor.h>
//#include <Adafruit_BME280.h>
#include <Adafruit_SHT31.h>

#include "Timer.h"

#define qastroId 'i'
#define observingconditionsId 'o'

String ASCOMcmd;
bool ASCOMcmdComplete;

bool ShowData = false;
int DisplayAlwaysOn = 0;

void setup() 
{
  InitSerial();
  InitOLEDLCD();
  InitObservingConditions();
  Serial.println("Ready..");
}

void loop() {

  if (ASCOMcmdComplete) 
  {
    switch((char)ASCOMcmd[0]) 
    {
      case qastroId:
          SendSerialCommand(observingconditionsId + String(DEVICE_RESPONSE) + " " + String(VERSION));
        break;

      case observingconditionsId: //Case fhe function is for the Environmentals
        DoObservingConditionsAction(ASCOMcmd.substring(1)); //Remove first char from string as this is the function type.
      break;
    }
    
    ASCOMcmdComplete = false;
    ASCOMcmd = "";
  }

  CheckShowDataButton();

  //UpdateObservingConditionsData();
  UpdateData();
}
