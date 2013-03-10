#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("UIAutomation")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Alexander Petrovskiy")]
[assembly: AssemblyProduct("UIAutomation Cmdlets")]
[assembly: AssemblyCopyright("Copyright 2011-2013")]
[assembly: AssemblyTrademark("SoftwareTestingUsingPowerShell.com")]
[assembly: AssemblyCulture("")]

//[assembly: CLSCompliant(true)]

// This sets the default COM visibility of types in the assembly to invisible.
// If you need to expose a type to COM, use [ComVisible(true)] on that type.
[assembly: ComVisible(false)]

[assembly: InternalsVisibleTo("UIAutomationUnitTests")]
[assembly: InternalsVisibleTo("IRAddinUnitTests")]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all the values or you can use the default the Revision and 
// Build Numbers by using the '*' as shown below:
[assembly: AssemblyVersion("0.8.6.*")]
