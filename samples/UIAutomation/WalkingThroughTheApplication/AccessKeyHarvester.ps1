cls
ipmo $global:uiautomationModule;

function Out-ElementDetail
{
	param(
		  [System.Windows.Automation.AutomationElement]$element,
		  [int]$level,
		  [string]$parentAccessKey
		 )

	[string]$accessKey = $element.Current.AccessKey;
	if ($accessKey.Length -eq 0) {
		$accessKey = "None";
	} else {
		if ($parentAccessKey.Length -gt 0) {
			$accessKey = `
				$parentAccessKey + "=>" + $accessKey;
		}
	}
	Write-Host "$($level)`t" `
		"$($element.Current.ControlType.ProgrammaticName)`t" `
		"$($element.Current.Name)`t" `
		"$($element.Current.AutomationId)`t" `
		"$($element.Current.AcceleratorKey)`t" `
		"$($accessKey)";
	try {
		$global:dict.Add($accessKey, $element.Current.Name);
	}
	catch {
		Write-Host "Error: $($element.Current.Name)`t$($accessKey)";
	}
}

function Enum-Children
{
	param(
		  [System.Windows.Automation.AutomationElement]$windowElement,
		  [int]$level
		 )

	try {
		$apppid = $windowElement.Current.ProcessId;
		$elements = $null;
		if ($level -eq 0) {
			Out-ElementDetail $windowElement 0;
			try {
				$null = $windowElement | Invoke-UIAMenuItemClick;
				$elements = `
					Get-UIAWindow -ProcessId $apppid | `
					Get-UIAControlDescendants -ControlType MenuItem,SplitButton,Custom,ListItem;
			}
			catch {
				$elements = $windowElement | Invoke-UIAMenuItemExpand | Get-UIAControlDescendants -ControlType MenuItem,SplitButton,Custom; #,ListItem;
			}
		}
		if ($elements -ne $null -and $elements.Count -gt 0) {
			foreach ($element in $elements) {
				Out-ElementDetail $element ($level + 1) ($windowElement.Current.AccessKey);
				[void]($element | Move-UIACursor -X 5 -Y 5);
				try {
					Enum-Children $element ($level + 1);
				}
				catch {}
			} 
		}
		if ($level -eq 0) {
			try{ 
				$null = $windowElement | Invoke-UIAMenuItemClick; 
			} 
			catch {
				$null = $windowElement | Invoke-UIAMenuItemCollapse; 
			}
		}
	}
	catch {}
}

function Report-AccessKeys
{
	param(
		  [string]$startName,
		  [string]$stopName
		 )
	
	if ($stopName.Length -eq 0) {
		$stopName = $startName;
	}
	
	[UIAutomation.Preferences]::OnSuccessDelay = 300;
	Write-Host "Access Key report for $($startName)";
	Write-Host "Level`tControlType`tName`tAutomationId`tAcceleratorKey`tAccessKey";
	[System.Collections.Generic.Dictionary``2[System.String,System.String]]$global:dict = `
		New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]";
	$topLevelMenuItems = Start-Process $startName -PassThru | `
		Get-UIAWindow | `
		Get-UIAControlDescendants -ControlType ToolBar,MenuBar | `
		Get-UIAControlDescendants -ControlType MenuItem,SplitButton,Custom,ListItem;
	
	foreach ($element in $topLevelMenuItems) {
		Enum-Children $element 0;
	}
	
	Stop-Process -Name $stopName;
}

Report-AccessKeys services.msc mmc;
Report-AccessKeys compmgmt.msc mmc;
Report-AccessKeys devmgmt.msc mmc;
Report-AccessKeys calc;
Report-AccessKeys notepad;
Report-AccessKeys mspaint;