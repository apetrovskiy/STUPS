####################################################################################################
# Script name: MenuOpenedEventAutomation01.ps1
# Description: demonstrates how to be informed that a menu is opened
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

Start-Process calc -PassThru | `
	Get-UIAWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction {[System.Windows.Forms.MessageBox]::Show("menu opened");}; 
Get-UIAMenuItem -Name Vi* | Invoke-UIAMenuItemExpand;