msbuild .\ReSharperExtensions.sln /p:Configuration=Release

pushd Deploy

nuget pack JoarOyen.ReSharperExtensions.Macros.nuspec
nuget pack JoarOyen.ReSharperExtensions.Livetemplates.nuspec

popd
