####################################################################################################
# Script name: start.ps1
# Description: initializes the necessary modules: UIAutomationl.dll and TMX.dll
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

$global:uiautomationModule = `
#	"..\..\UIAutomation\bin\Release35\UIAutomation.dll";
	"C:\Projects\PS\UIAutomation.Old\UIAutomation\bin\Release35\UIAutomation.dll";
$global:tmxModule = `
#	"..\..\UIAutomation\bin\Release35\TMX.dll";
	"C:\Projects\PS\UIAutomation.Old\UIAutomation\bin\Release35\TMX.dll";