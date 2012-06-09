
A lightweight means of displaying the assemby version number of an ASP.NET website.

Overview
--------------------------------
Web.Version adds a HTTP module to a website that injects version number information into the response stream of ASP.NET web pages.


Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install Web.Version from the package manager console:

    PM> Install-Package Web.Version


Visit the [package page](https://nuget.org/packages/Web.Version) on NuGet for more download options.


### Creating a package from the Source

Alternatively build the package using the [MSBuild Command Line](http://msdn.microsoft.com/en-us/library/ms164311.aspx) by invoking:

	msbuild Package.build.xml


This will create compile and build the NuGet package which will be placed in the _Build\buildartifacts\Package_ directory.



Configuration Options
--------------------------------

The package installs with a minimum set of configuration contained within a custom configuration section in the web.config

	<configuration>
		<configSections>
			<section name="web.version" type="Web.Version.Configuration.WebVersionConfiguration" />
		</configSections>
		...
	</configuration>


### Optional Settings

Listed below are other optional configuration attributes to configure web.version:

	enabled="true"                : defaults to false. Controls whether web version information is added to the HTTP response stream
      
	responseHeaderEnabled="true"  : defaults to false. if specified a X-Web-Version header will be added to the HTTP response containing the web version
	   
	reportVersion="1.0.0"         : defaults to "", so uses version information taken from the web site assembly. If this setting is specified the value provided will be used to override assembly version reporting

	autoHideInSeconds="5"         : if greater than 0 will set a javascript timer to automatically remove the version div from the top left of the page's HTML. 
                                    Valid values are 0 to 60

	htmlDivEnabled="true"         : defaults to true. If set to false the version div will not be added to the page's HTML.




Release History
--------------------------------

-	**1.1**		: Configuration section added to allow customisation of behaviour.
-	**1.0.1**	: Minor update to support .NET Framework v2 and above
- 	**1.0**		: Initial release. Supports ASP.NET web forms under .NET Framework v4.


