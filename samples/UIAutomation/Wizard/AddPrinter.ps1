[string]$TMXmodule = 'C:\tests\TMX.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\TMX.dll';
[string]$UIAmodule = 'C:\tests\UIAutomation.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\UIAutomation.dll';
#[string]$importFile = 'C:\tests\testdata.txt'; #'E:\G\Projects\PS\UIAutomation\samples\testdata.txt';

ipmo -Name $TMXmodule;
ipmo -Name $UIAmodule;
$VerbosePreference = [System.Management.Automation.ActionPreference]::Continue;

#region Creating a wizard
Write-Host "=======================================================================================";
Write-Host "Creating a wizard`r`n";
New-UIAWizard -Name wzd -StartAction {Get-UIAWindow -Title 'Maskinvara och ljud' | `
		Get-UIAPane -AutomationId 'CategoryPanel' -Title 'CPCategoryPanel' | `
		Get-UIAHyperlink -AutomationId 'tasklink' -Title 'Lägg till en skrivare';
			#InvokePattern
			#ValuePattern

		Get-UIATitleBar -AutomationId 'TitleBar' -Title 'Lägg till skrivare' | `
			Invoke-UIAHyperlinkClick;
				# no supported pattterns
		} | `
	Add-UIAWizardStep -Name step1 -Order 10 -WaitCriteria @{Name='aaa1';IsEnabled=$true} -StepAction {Write-Host "step 1";} | `
	Add-UIAWizardStep -Name step2 -Order 10 -WaitCriteria @{Name='aaa2';IsEnabled=$true} -StepAction {Write-Host "step 2";} | `
	Add-UIAWizardStep -Name step3 -Order 10 -WaitCriteria @{Name='aaa3';IsEnabled=$true},@{Name='aaa3';IsEnabled=$true} -StepAction {Write-Host "step 3";},{Write-Host "step 3";} | `
	Remove-UIAWizardStep -Name step2 | `
	Add-UIAWizardStep -Name step4 -Order 10 -WaitCriteria @{Name='aaa4';IsEnabled=$true} -StepAction {Write-Host "step 4";};
Invoke-UIAWizard -Name wzd | `
	Step-UIAWizard -Name step1 | `
	Step-UIAWizard -Name step3 | `
	Step-UIAWizard -Name step4 | `
	Step-UIAWizard -Name step3 -Forward:$false | `
	Step-UIAWizard -Name step4;
	

