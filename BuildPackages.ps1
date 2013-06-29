#$sourcePath = "ReSharper80Extensions"
#$destinationPackage = $sourcePath + "_" + (get-date -Format "yyyy-MM-dd") + ".zip" 

msbuild .\ReSharperExtensions.sln /p:Configuration=Release

#if (Test-Path $sourcePath) { Remove-Item -Force -Recurse $sourcePath }
#New-Item  -ItemType Directory $sourcePath

#Copy-Item JoarOyen.ReSharperPlugIn\bin\Release\JoarOyen.ReSharperPlugIn.dll $sourcePath
#Copy-Item ReSharperExtensions.sln.DotSettings $sourcePath
#Copy-Item README.md $sourcePath

#Write-Zip $sourcePath\*.* $destinationPackage

pushd Deploy

nuget pack JoarOyen.ReSharperExtensions.Macros.8.0.0.0.nuspec
nuget pack JoarOyen.ReSharperExtensions.Livetemplates.8.0.0.0.nuspec

popd