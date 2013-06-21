set ReSharperPluginDirectory="%LOCALAPPDATA%\JetBrains\ReSharper\v8.0\Plugins\JoarOyen"

if not exist %ReSharperPluginDirectory% md %ReSharperPluginDirectory%
copy /Y JoarOyen.ReSharperPlugIn\bin\Debug\JoarOyen.ReSharperPlugIn.* %ReSharperPluginDirectory%

pause
