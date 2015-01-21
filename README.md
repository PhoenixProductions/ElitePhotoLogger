# ElitePhotoLogger

This is a .NET programe that will watch your Elite Dangerous Pictures directory for new screenshots

Each time a screenshot is taken it will stash it as a PNG. Then when you finish your session you can use the "Write Log" option to review the screenshots taken and write a log.

## Inputs & Outputs

At the moment the location of your Elite: Dangerous screenshots and the location that your log is kept at can be configured via the PhotoLogger.exe.config file.

The default locations are (respectively):
* %HOMEPATH%\Pictures\Frontier Developments\Elite Dangerous
* %HOMEPATH%\Documents\FlightLog
** A text file is recorded for each day in the \log directory
** PNG versions of the screenshot are stored in the \input directory

# Using ElitePhotoLogger

This is how _I_ use it.

# Capturing where I've been - by capturing the screen on jump in / out I can review where I went and what happened
# Capturing incidents - Been interdicted? Hit F10 to capture the event so you can write up abot how the encounter went.
# Travel times - You can see the timestamp for each screen shot so it's really easy to then work out how long it took to get between two places
# Recording Trades - Grab a screenshot at the purchase and sale ends to look at later to work out your profits
