####################################################################################################
# Script name: MenuOpenedEventAutomation02.ps1
# Description: demonstrates how to be informed that a menu is opened and the name of a sender
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

Start-Process calc -PassThru | `
	Get-UIAWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction { `
			param($src, $e)
			[System.Windows.Forms.MessageBox]::Show("menu opened: Name='" + $src.Cached.Name + "'; AutomationId='" + $src.Cached.AutomatioId + "'");}; 
Get-UIAMenuItem -Name Vi* | Invoke-UIAMenuItemExpand;