$sourcePath = "ReSharper70Extensions"
$destinationPackage = $sourcePath + "_" + (get-date -Format "yyyy-MM-dd") + ".zip" 

msbuild .\ReSharperExtensions.sln /p:Configuration=Release

if (Test-Path $sourcePath) { Remove-Item -Force -Recurse $sourcePath }
New-Item  -ItemType Directory $sourcePath

Copy-Item JoarOyen.ReSharperPlugIn\bin\Release\JoarOyen.ReSharperPlugIn.dll $sourcePath
Copy-Item ReSharperExtensions.sln.DotSettings $sourcePath
Copy-Item README.md $sourcePath

Write-Zip $sourcePath\*.* $destinationPackage
