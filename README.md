# Q-Astro-Dew-Monitor
Q- Astro Dew Monitor for a max of 2 dew heaters

You can find details about this Dew Monitor on my website: https://www.q-astro.com/#/ascom-auto-dew-monitor/

For a version history you can have a look at the VersionHistory.txt file.

You can communicate directly with the Arduino on the board (e.g. using puTTY) and the following commands are available to you:
* i# - This return what it is and its version number.
* z# - This return all available data in a single string. This is what the ASCOM driver uses.
    - a = Altitude
    -	d = Dew Point (in Celsius)
    -	ex = x either 1 or 2, gives you the temp of either Dew Band 1 or 2 (in Celsius)
    -	h = Humidity (%)
    -	i = last update time
    -	m = What is the mode of the Dew Monitor (0 = Auto, 1 = Manual)
    -	p = Pressure
    -	ox = The power supplied to either Dew Band 1 or 2 (x=1 or 2) in %
    -	t = Observatory temp
*	m# - This gives you the status if the Dew Heater is in Auto or Manual mode (0 = Auto & 1 = Manual).
*	mx# - Where x can be 0 or 1, this sets the Dew Heater to either Manual (1) or Auto (0)
*	oxyyy# - Where x can be 1 or 2, for the dew band selected and yyy is the power percentage you want to apply to the dew band (0 – 100%). This only works when the Dew Monitor is in manual mode (m=1).
*	ox# - Where x can be 1 or 2 and will return the current power (in %) applied to the requested dew band.
