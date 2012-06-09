Web.Version
================================

What is Web.Version?
--------------------------------
Web.Version is a HTTP module that runs within an ASP.NET website and reports the assembly version number of the HttpApplication.


Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install Web.Version from the package manager console:

    PM> Install-Package Web.Version


Visit the [package page](https://nuget.org/packages/Web.Version) on NuGet for more download options.


### Creating a package from the Source

Alternatively build the package using the [MSBuild Command Line](http://msdn.microsoft.com/en-us/library/ms164311.aspx) by invoking:

	msbuild Package.build.xml


This will create compile and build the NuGet package which will be placed in the _Build\buildartifacts\Package\_ directory.