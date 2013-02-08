#
# This sample demonstrates how not to use Search- cmdlets (that were gone from the module)
# to achieve the same results.
#
Set-StrictMode -Version Latest;

ipmo [path]\UIAutomation.dll;

# here we are searching for all the element whose names start with 'a'

Start-Process calc -PassThru | Get-UIAWindow | Get-UIAControl -Name A* | `
 
	%{Write-Host "===========================================================";
 
	Write-Host "@{Name='$($_.Current.Name)'; 
	AutomationId='$($_.Current.AutomationId)'; 
	ControlType='$($_.Current.ControlType.ProgrammaticName)'}"; 
	$_ | Get-UIAControlAncestors | `
 
	%{Write-Host "@{Name='$($_.Current.Name)'; 
	AutomationId='$($_.Current.AutomationId)'; 
	ControlType='$($_.Current.ControlType.ProgrammaticName)'}";}};
