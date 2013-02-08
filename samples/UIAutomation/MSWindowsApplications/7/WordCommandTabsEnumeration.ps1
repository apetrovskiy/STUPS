[UIAutomation.Preferences]::OnSuccessDelay = 0;

Get-UIAWindow -pn winword | `
	Get-UIAControlDescendants -ControlType TabItem | `
		%{ 
			# set initial state before access each tab item
			Get-UIATabItem -Name Home | `
			Invoke-UIATabItemSelectItem -ItemName Home; 
			[void](Get-UIAButton -Name File*Tab | `
				Invoke-UIAButtonClick);
			# select a tab item
			$_ | `
				Invoke-UIATabItemSelectItem -ItemName $_.Current.Name;
			# stop to see where we are
			sleep -Seconds 2;
			
			# print out the name of the current tab item
			Write-Host "$($_.Current.Name)`t" `
				"$($_.Current.AutomationId)`t" `
				"$($_.Current.ClassName)";
		}