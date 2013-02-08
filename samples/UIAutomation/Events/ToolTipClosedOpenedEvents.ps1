####################################################################################################
# Script name: ToolTipClosedOpenedEvents.ps1
# Description: demonstrates how to work with ToolTipOpenedEvent and ToolTipClosedEvent
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

[string]$appName = "calc";
Start-Process $appName -PassThru | `
	Get-UIAWindow | `
	Register-UIAToolTipClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"calc ToolTip closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAToolTipOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"calc ToolTip opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "notepad";
Start-Process $appName -PassThru | `
	Get-UIAWindow | `
	Register-UIAToolTipClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"notepad ToolTip closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAToolTipOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"notepad ToolTip opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "SharpDevelop";
Get-UIAWindow -pn $appName | `
	Register-UIAToolTipClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"SharpDevelop ToolTip closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAToolTipOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"SharpDevelop ToolTip opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

$appName = "TEMP";
Start-Process explorer -ArgumentList $Env:TEMP | `
	Get-UIAWindow | `
	Register-UIAToolTipClosedEvent `
		-EventAction { param($src, $e) 
			[System.Windows.Forms.MessageBox]::Show( `
				"TEMP ToolTip closed: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}; 
[UIAutomation.CurrentData]::CurrentWindow | `
	Register-UIAToolTipOpenedEvent `
		-EventAction { param($src, $e)
			[System.Windows.Forms.MessageBox]::Show( `
				"TEMP ToolTip opened: Current:" + `
				$src.Current.Name + " " + `
				$src.Current.AutomationId + " Cached:" + `
				$src.Cached.Name + " " + `
				$src.Cached.AutomationId + " " + `
				$e.EventId);}

