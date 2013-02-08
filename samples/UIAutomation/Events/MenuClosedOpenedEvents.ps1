####################################################################################################
# Script name: MenuClosedOpenedEvents.ps1
# Description: demonstrates how to work with MenuOpenedEvent and MenuClosedEvent
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

[string]$appName = "calc";
Start-Process $appName -PassThru | `
	Get-UIAWindow | `
	Register-UIAMenuClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"calc menu closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"calc menu opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "notepad";
Start-Process $appName -PassThru | `
	Get-UIAWindow | `
	Register-UIAMenuClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"notepad menu closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"notepad menu opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "SharpDevelop";
Get-UIAWindow -pn $appName | `
	Register-UIAMenuClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"SharpDevelop menu closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"SharpDevelop menu opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "TEMP";
Start-Process explorer -ArgumentList $Env:TEMP | `
	Get-UIAWindow | `
	Register-UIAMenuClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"TEMP menu closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAMenuOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"TEMP menu opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

