set ReSharperPluginDirectory="%LOCALAPPDATA%\JetBrains\ReSharper\v7.1\Plugins\JoarOyen"

if not exist %ReSharperPluginDirectory% md %ReSharperPluginDirectory%
copy /Y JoarOyen.ReSharperPlugIn\bin\Debug\JoarOyen.ReSharperPlugIn.* %ReSharperPluginDirectory%

pause
