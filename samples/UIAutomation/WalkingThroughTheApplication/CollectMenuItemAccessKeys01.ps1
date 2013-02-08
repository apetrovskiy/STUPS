cls
ipmo $global:uiautomationModule;

$topLevelMenuItems = Start-Process services.msc -PassThru | `
	Get-UIAWindow | `
	Get-UIAControlDescendants -ControlType ToolBar,MenuBar | `
	Get-UIAControlDescendants -ControlType MenuItem; #,Button;
	$apppid = $topLevelMenuItems[0].Current.ProcessId;
	foreach ($menuItemLevel1 in $topLevelMenuItems) {
		Write-Host "1`t$($menuItemLevel1.Current.ControlType.ProgrammaticName)`t$($menuItemLevel1.Current.Name)" `
			"`t$($menuItemLevel1.Current.AutomationId)`t$($menuItemLevel1.Current.AccessKey)";
		try{ 
			$null = $menuItemLevel1 | Invoke-UIAMenuItemClick; 
			$secondLevelMenuItems = Get-UIAWindow -ProcessId $apppid | Get-UIAControlChildren -ControlType MenuItem;
			foreach ($menuItemLevel2 in $secondLevelMenuItems) {
				Write-Host "2`t$($menuItemLevel2.Current.ControlType.ProgrammaticName)`t$($menuItemLevel2.Current.Name)" `
					"`t$($menuItemLevel2.Current.AutomationId)`t$($menuItemLevel1.Current.AccessKey)=>$($menuItemLevel2.Current.AccessKey)";
			}
			try{ $null = $menuItemLevel1 | Invoke-UIAMenuItemClick; } catch {}
		} 
		catch {}
	}
Stop-Process -Name mmc