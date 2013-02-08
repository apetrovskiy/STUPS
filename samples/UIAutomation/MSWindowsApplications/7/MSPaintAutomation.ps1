####################################################################################################
# Script name: MSPaintAutomation.ps1
# Description: demonstrates using of menu in mspaint (Windows 7)
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

# create a new picture
Get-UIAWindow -pn mspaint | Get-UIACustom -Name 'Application menu' | Invoke-UIACustomClick | Get-UIAMenuItem -Name 'New' | Invoke-UIAMenuItemClick;
try{
	Get-UIAWindow -Name 'Paint' -Seconds 3 | Get-UIAButton -Name "Don`'t Save" | Invoke-UIAButtonClick;
} catch {
	Write-Host "the previous picture was as clean as snow";
}