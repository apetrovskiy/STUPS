####################################################################################################
# Script name: MenuOpenedEventAutomation03.ps1
# Description: demonstrates how to wait for an event being raised
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
(Wait-UIAEventRaised -Name View).Cached;