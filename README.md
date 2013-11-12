ReSharperExtensions
===================
This solution contains Live Templates and macros for [JetBrains ReSharper](http://www.jetbrains.com/resharper/). The following macros are available:

* **ValidIdentifierMacro**: Replaces invalid identifier characters with underscores as you type
* **CapitalizedWordsIdentifierMacro**: Same as ValidIdentifierMacro but capitalizes the first letter in each word 
* **DomainAndUsernameMacro**: Returns your domain and username in the form of Domain\Username

The Live Template contains one template with the **mstm** shortcut (MicroSoft Test Method).It allows
you to write test method names as sentences with spaces, and the macro will replace the spaces with underscores as you
type. It also allows you to select an MSTest category and assigns the current user as the owner of the test in a format
compatible with TFS.

See [http://www.joaroyen.com/2010/08/resharpers-live-templates-can-do.html](http://www.joaroyen.com/2010/08/resharpers-live-templates-can-do.html) for more information.

Installation instructions
-------------------------

Alternative 1 is recommended if you have ReSharper 8.0 or later and just want the bits. Alternative 2 is best if you want to tinker with and debug the macros yourself, while alternative 3 if you just want to use the macros in your own templates with ReSharper 7.1 or earlier.

### Alternative 1: Install using ReSharper Extension Manager ###

* Open ReSharper -> Extension manager
* Search for JoarOyen
	* Select "JoarOyen.ReSharperExtensions.Macros" if you just wan to use the macros in your own Live Templates
	* Select "JoarOyen.ReSharperExtensions.LiveTemplates" if you want both macros and a LiveTemplate with a template for writing MSTest methods. This package depends on the macro package.

### Alternative 2: Build from sources and install Debug build ###

* Download and install [ReSharper 8.0 SDK](http://www.jetbrains.com/resharper/download/index.html). Dependencies on ReSharper SDK for version 8.1 and later are handled by NuGet.
* Open Visual Studio 2012 or 2013 and build the solution in Debug configuration
* Close all instances of Visual Studio
* Run "Deploy.bat" from an elevated command prompt to copy dll and pdb to the ReSharper 8.1 plugins folder for the current user

### Alternative 3: From precompiled package with Release build ###

* Download the latest package for your ReSharper version from my [SkyDrive folder](http://sdrv.ms/XBPFYA).
* Unzip the package to an empty directory.
* Copy JoarOyen.ReSharperPlugIn.dll to the ReSharper N.N plugins folder. This will typically be something like "C:\Users\&lt;USERNAME&gt;\AppData\Local\JetBrains\ReSharper\vN.N\Plugins\JoarOyen\".
* Open the "ReSharperExtensions.sln.DotSettings" file using "ReSharper -> Manage Options..." to inspect the example template

Remarks
-------

* Master is updated to support ReSharper 8.0 and ReSharper 8.1, and requires .NET 4.0 or newer. The macros can therefore only be used in VS2010, VS2012 and VS2013.
* Master will continue to support all versions of ReSharper 8.0 and later as long as it is possible to build every version from one solution.
* Macros that works with previous versions of ReSharper and Visual Studio are available in separate branches for each version of ReSharper.
* The code in this version is built with the ReSharper SDK, and the namespace for the macros has been changed to reflect the new name of the assembly.
* The test project is using NUnit from ReSharper SDK, but uses NuGet for NSubstitute (this dependency should be downloaded automatically).
* The Deploy.bat file must be run with administrative privileges if UAC is enabled
