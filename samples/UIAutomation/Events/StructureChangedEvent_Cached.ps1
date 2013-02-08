####################################################################################################
# Script name: StructureChangedEvent.ps1
# Description: demonstrates how to work with StructureChangedEvent
# Copyright:   http://SoftwareTestingUsingPowerShell.com, 2012
####################################################################################################

Set-StrictMode -Version Latest;
ipmo $global:uiautomationModule;

#$global:statusBar = $null;

# start the process and atach event handlers to the window
Start-Process notepad -PassThru | `
	Get-UIAWindow | `
	Register-UIAStructureChangedEvent -ChildAdded `
		-EventAction `
		{ # write to a file
			param($src, $e) 
			# report everything
			"'$($src.Cached.Name)' has gotten a child" >> "$env:Temp\sample_report.txt"; 
			if ($src.Cached.Name.Length -eq 0) {
				"===================================" >> "$env:Temp\sample_report.txt";
				"Oh, this is what we are waiting for!" >> "$env:Temp\sample_report.txt";
				"AutomaitonId = $($src.Cached.AutomaitonId)" >> "$env:Temp\sample_report.txt";
				"ControlType = $($src.Cached.ControlType.ProgrammaticName)" >> "$env:Temp\sample_report.txt";
				"ClassName = $($src.Cached.ClassName)" >> "$env:Temp\sample_report.txt";
				"-----------------------------------" >> "$env:Temp\sample_report.txt";
			}
		},
		{ # display a message box
			param($src, $e)
			# report only what happened under the menu item hierarchy
			if ($src.Cached.ControlType.ProgrammaticName -eq 'ControlType.StatusBar') {
				[System.Windows.Forms.MessageBox]::Show($src.Cached.Name + "`t" + `
				$src.Cached.AutomationId + "`r`n" + `
				$e + "`r`n" + `
				$src.Cached.ControlType.ProgrammaticName);
			}
		};

# depending on was or wasn't the Status Bar shown on
# the status bar will or won't be shown
# and the event handlers we linked to the window will fire
Get-UIAMenuItem -Name View | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name 'Status Bar' | Invoke-UIAMenuItemClick;
Get-UIAMenuItem -Name View | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name 'Status Bar' | Invoke-UIAMenuItemClick;
Get-UIAMenuItem -Name View | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name 'Status Bar' | Invoke-UIAMenuItemClick;
Get-UIAMenuItem -Name View | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name 'Status Bar' | Invoke-UIAMenuItemClick;