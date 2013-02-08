####################################################################################################
# Script name: start.ps1
# Description: initializes the necessary modules: UIAutomationl.dll and TMX.dll
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

$global:uiautomationModule = `
#	"..\..\UIAutomation\bin\Release35\UIAutomation.dll";
	"C:\Projects\PS\UIAutomation.Old\certificate\0.7.11\3.5\UIAutomation.dll";
$global:tmxModule = `
#	"..\..\UIAutomation\bin\Release35\TMX.dll";
	"C:\Projects\PS\UIAutomation.Old\certificate\0.7.11\3.5\TMX.dll";