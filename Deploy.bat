set ReSharperPluginDirectory="%LOCALAPPDATA%\JetBrains\ReSharper\v8.1\Plugins\JoarOyen"

if not exist %ReSharperPluginDirectory% md %ReSharperPluginDirectory%
copy /Y JoarOyen.ReSharperPlugIn\bin\Debug\JoarOyen.ReSharperPlugIn.8.1.* %ReSharperPluginDirectory%

pause
