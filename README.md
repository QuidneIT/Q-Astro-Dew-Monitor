# Q-Astro-Dew-Monitor
Q- Astro Dew Monitor for a max of 2 dew heaters

Version 4.3.0 is released. For this release you need to update the Arduino code as well.
The big change between 4.2.0 and 4.3.0 is the move from a BME280 to a SHT31. The SHT31 is more reliable but does not provide Pressure & ALtitude data.

You can find details about this Dew Monitor on my website: https://www.q-astro.com/#/ascom-auto-dew-monitor/
For a version history you can have a look at the VersionHistory.txt file.

When using the Monitor App in Manual mode, be aware that updates can take a few update cycles to filter back to the Monitor App.
Also switching back from Manual to Automatic mode will take a few update cycles to reflect the change.

You can communicate directly with the Arduino on the board (e.g. using puTTY) and the following commands are available to you:
* i#   - This return what it is and its version number.
* od#  - Returns Dew Point in Celsius.
* oex# - Returns the Dew Band temperature in celcius, where x is either 1 or 2 for the specific Dew Band.
* oi#  - Returns in sec the last time the Sensor data was read from the Dew Monitor.
* om# - This gives you the status if the Dew Heater is in Auto or Manual mode (0 = Auto & 1 = Manual).
* omx# - Where x can be 0 or 1, this sets the Dew Heater to either Manual (1) or Auto (0)
* opxyyy# - Where x can be 1 or 2, for the dew band selected and yyy is the power percentage you want to apply to the dew band (0 – 100%). This only works when the Dew Monitor is in manual mode (m=1).
* opx# - Where x can be 1 or 2 and will return the current power (in %) applied to the requested dew band.
* or#  - Force an update of the sensor data.
* oz# - This return all available data in a single string. This is what the ASCOM driver uses.
    - ex = x either 1 or 2, gives you the temp of either Dew Band 1 or 2 (in Celsius)
    - h = Humidity (%)
    - i = last update time
    - m = What is the mode of the Dew Monitor (0 = Auto, 1 = Manual)
    - b = Pressure
    - px = The power supplied to either Dew Band 1 or 2 (x=1 or 2) in %
    - t = Observatory temp
