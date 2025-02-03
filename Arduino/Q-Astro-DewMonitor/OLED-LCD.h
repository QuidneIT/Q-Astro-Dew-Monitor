/* ----------------------------------------------------------------------------------------------------------------------------*/ 
/*  Start of OLED Definitions */

SSD1306AsciiAvrI2c display; 

#define OLED_RESET 4
#define OLED_I2C_ADDRESS 0x3C
#define PIN_SHOW 12

int val = 0;
unsigned long onTime;

bool LCDPresent = true;    //Change this to 0 if you do not use the LCD display.

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End OLED Definitions */
