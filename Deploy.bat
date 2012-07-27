set ReSharperPluginDirectory="%ProgramFiles(x86)%\JetBrains\ReSharper\v7.0\Bin\Plugins\JoarOyen"

if not exist %ReSharperPluginDirectory% md %ReSharperPluginDirectory%
copy /Y JoarOyen.ReSharperPlugIn\bin\Debug\JoarOyen.ReSharperPlugIn.* %ReSharperPluginDirectory%

pause
