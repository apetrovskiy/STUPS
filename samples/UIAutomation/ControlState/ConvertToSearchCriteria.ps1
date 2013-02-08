####################################################################################################
# Script name: start.ps1
# Description: initializes the necessary modules: UIAutomationl.dll and TMX.dll
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name Vi* | ConvertTo-UIASearchCriteria
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name Vi* | ConvertTo-UIASearchCriteria -Full
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name Vi* | ConvertTo-UIASearchCriteria -Include controltype,class
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name Vi* | ConvertTo-UIASearchCriteria -exclude controltype,class
