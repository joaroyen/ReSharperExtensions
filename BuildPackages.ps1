msbuild .\ReSharperExtensions.sln /p:Configuration=Release

pushd Deploy

nuget pack JoarOyen.ReSharperExtensions.Macros.8.0.0.0.nuspec
nuget pack JoarOyen.ReSharperExtensions.Livetemplates.8.0.0.0.nuspec

popd