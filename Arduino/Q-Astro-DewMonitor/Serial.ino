/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of Serial Commands */

#define SERIALSPEED 9600

void InitSerial()
{
  Serial.flush();
  Serial.begin(SERIALSPEED);  // Baud rate, make sure this is the same as ASCOM driver
  ASCOMcmd = "";
  ASCOMcmdComplete = false; 

  Serial.println("Serial Init Completed"); 
}

void serialEvent() 
{
  while (Serial.available() > 0) 
  {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the ASCOMcmd:
    ASCOMcmd += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '#') {
      ASCOMcmdComplete = true;
    }
  }
}

void SendSerialCommand(String sendCmd)
{
  Serial.print(sendCmd); 
  Serial.println("#");  // Similarly, so ASCOM knows
}

void SendSerialCommand(char function, String sendCmd)
{
  Serial.print(function);
  Serial.print(sendCmd); 
  Serial.println("#");  // Similarly, so ASCOM knows
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of Serial Commands */


