# this is deprecated since 0.8.0

ipmo $global:uiautomationModule;
ipmo $global:tmxModule;

[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation;
cls;

# here we are searching for all the element whose names start with 'a'
Start-Process calc -PassThru | Get-UIAWindow | Search-UIAControl -Name A* | `
	%{Write-Host "===========================================================";
	  Write-Host "@{Name='$($_.Current.Name)'; AutomaitonId='$($_.Current.AutomaitonId); ControlType='$($_.Current.ControlType.ProgrammaticName)'}"; $_ | Get-UIAControlAncestors | `
		%{Write-Host "@{Name='$($_.Current.Name)'; AutomaitonId='$($_.Current.AutomaitonId); ControlType='$($_.Current.ControlType.ProgrammaticName)'}";}};
