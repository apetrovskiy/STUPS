#region Using directives

//using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#endregion

// [assembly:CLSCompliant(true)]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Tmx")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Alexander Petrovskiy")]
[assembly: AssemblyProduct("TMX")]
[assembly: AssemblyCopyright("Copyright 2012-2015")]
[assembly: AssemblyTrademark("SoftwareTestingUsingPowerShell.com")]
[assembly: AssemblyCulture("")]

// This sets the default COM visibility of types in the assembly to invisible.
// If you need to expose a type to COM, use [ComVisible(true)] on that type.
[assembly: ComVisible(false)]

[assembly: InternalsVisibleTo("TmxUnitTests")]
[assembly: InternalsVisibleTo("Tmx")]
[assembly: InternalsVisibleTo("Tmx.Core")]
[assembly: InternalsVisibleTo("Tmx.Server.Library")]
[assembly: InternalsVisibleTo("Tmx.Server.Logic")]
[assembly: InternalsVisibleTo("Tmx.Server.Tests")]
[assembly: InternalsVisibleTo("Tmx.Client.Library")]
[assembly: InternalsVisibleTo("Tmx.Client.Tests")]
[assembly: InternalsVisibleTo("TlAddinUnitTests")]
[assembly: InternalsVisibleTo("TFAddinUnitTests")]
[assembly: InternalsVisibleTo("BddAddinUnitTests")]
[assembly: InternalsVisibleTo("BzAddinUnitTests")]
[assembly: InternalsVisibleTo("RmAddinUnitTests")]
[assembly: InternalsVisibleTo("RallyUnitTests")]

// 20130111
//[assembly: InternalsVisibleTo("testninject")]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all the values or you can use the default the Revision and 
// Build Numbers by using the '*' as shown below:
[assembly: AssemblyVersion("0.8.7.*")]
