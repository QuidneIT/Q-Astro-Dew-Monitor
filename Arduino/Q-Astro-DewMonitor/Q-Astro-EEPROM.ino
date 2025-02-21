/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of EEPROM Commands */

#define DEW_EEPROM_MEMORY 100

void EEPROMLoad() {
  EEPROM_readAnything(DEW_EEPROM_MEMORY, dewConfig);

  if (dewConfig.Saved != 111)
    EEPROMReset();    
 }

void EEPROMSave() 
{
  dewConfig.Saved = 111;  
  EEPROM_writeAnything(DEW_EEPROM_MEMORY, dewConfig);
}

void UpdateEEPROMData()
{
  EEPROMSave();
  EEPROMLoad();
}

void EEPROMReset()
{
    dewConfig.dewThreshold = DEWPOINT_DEF_THRESHOLD;
//   dewConfig.minDewBandTemp = DEWBAND_DEF_MINTEMP;
    dewConfig.tempDiffBeforeUpdate = TEMP_DEF_DIFF_BEFORE_UPDATE;
    dewConfig.powerUpdateInterval = POWER_DEF_UPDATE_INTERVAL;
    dewConfig.adjustPowerFixPercentage = ADJUST_DEF_POWER_FIXPERCENTAGE; 
    UpdateEEPROMData();
}


/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of EEPROM Commands */
