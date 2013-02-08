#[string]$TMXmodule = 'C:\tests\TMX.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\TMX.dll';
#[string]$UIAmodule = 'C:\tests\UIAutomation.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\UIAutomation.dll';
#[string]$importFile = 'C:\tests\testdata.txt'; #'E:\G\Projects\PS\UIAutomation\samples\testdata.txt';

#ipmo -Name $TMXmodule;
#ipmo -Name $UIAmodule;
$VerbosePreference = [System.Management.Automation.ActionPreference]::Continue;

#region Creating a wizard
Write-Host "=======================================================================================";
Write-Host "Creating a wizard`r`n";
New-UIAWizard -Name wzd -StartAction {Write-Host "starting the wizard code";} | `
	Add-UIAWizardStep -Name step1 -Order 10 -WaitCriteria @{Name='welcomePane';IsEnabled=$true} -StepForwardAction {Write-Host "step forward 1 code";} | `
	Add-UIAWizardStep -Name step2 -Order 20 -WaitCriteria @{Name='I accept';IsEnabled=$false} -StepForwardAction {Write-Host "step forward 2 code";} | `
	Add-UIAWizardStep -Name step3 -Order 30 -WaitCriteria @{Name='User name';IsEnabled=$true},@{Name='Organization';IsEnabled=$true} -StepForwardAction {Write-Host "step forward 3 code 1";},{Write-Host "step forward 3 code 2";} -StepBackwardAction {Write-Host "step backward 3 code 3"} | `
	Remove-UIAWizardStep -Name step2 | `
	Add-UIAWizardStep -Name step4 -Order 40 -WaitCriteria @{ControlType=Tree} -StepForwardAction {Write-Host "step forward 4 code";};
#endregion Creating a wizard

#region Running the wizard
Write-Host "=======================================================================================";
Write-Host "Running the wizard`r`n";
Invoke-UIAWizard -Name wzd | `
	Step-UIAWizard -Name step1 | `
	Step-UIAWizard -Name step3 | `
	Step-UIAWizard -Name step4 | `
	Step-UIAWizard -Name step3 -Forward:$false | `
	Step-UIAWizard -Name step4;
#endregion Running the wizard	

#region How to access and/or modify the variables
Write-Host "steps";
[UIAutomation.WizardCollection]::Wizards[0].Steps
Write-Host "start action";
$wzd.StartAction
Write-Host "steps";
$wzd = Get-UIAWizard -Name "wzd";
$wzd.Steps
Write-Host "step actions";
$wzd.Steps[0].StepForwardAction
$wzd.Steps[1].StepForwardAction
$wzd.Steps[1].StepBackwardAction
$wzd.Steps[2].StepForwardAction
Write-Host "fail - one step was removed in the example";
$wzd.Steps[3].StepForwardAction
#endregion How to access and/or modify the variables