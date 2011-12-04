set ReSharperPluginDirectory="%ProgramFiles(x86)%\JetBrains\ReSharper\v6.1\Bin\Plugins\JoarOyen"

if not exist %ReSharperPluginDirectory% md %ReSharperPluginDirectory%
copy /Y Macros\bin\Debug\JoarOyen.Tools.ReSharper.Macros.* %ReSharperPluginDirectory%

pause
