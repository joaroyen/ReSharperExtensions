ReSharperExtensions
===================
This solution contains Live Templates and macros for [JetBrains ReSharper](http://www.jetbrains.com/resharper/). You can check out an example template for MSTest in the ReSharper settings for this solution. The tm template allows you to write test method names as sentences with spaces, and the macro will replace the spaces with underscores as you type. It also allows you to select an MSTest category and assigns the current user as the owner of the test in a format compatible with TFS.

See [http://www.joaroyen.com/2010/08/resharpers-live-templates-can-do.html](http://www.joaroyen.com/2010/08/resharpers-live-templates-can-do.html) for more information.

## Comments ##

* Master is updated to support ReSharper 7, and requires .NET 4.0 or newer. The macros can therefore only be used in VS2010 and VS2012.
* Macros that works with previous versions of ReSharper and Visual Studio are available in separate branches for each version of ReSharper.
* The code in this version is built with the ReSharper SDK, and the namespace for the macros has been changed to reflect the new name of the assembly.
* The test project is using NUnit from ReSharper SDK, but uses NuGet for NSubstitute (this dependency should be downloaded automatically).
* The Deploy.bat file must be run with administrative privilegies the first time to b

