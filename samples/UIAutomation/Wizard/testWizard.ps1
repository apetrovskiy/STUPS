[string]$TMXmodule = 'C:\tests\TMX.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\TMX.dll';
[string]$UIAmodule = 'C:\tests\UIAutomation.dll'; #'E:\G\Projects\PS\UIAutomation\UIAutomation\bin\Release\UIAutomation.dll';
#[string]$importFile = 'C:\tests\testdata.txt'; #'E:\G\Projects\PS\UIAutomation\samples\testdata.txt';

ipmo -Name $TMXmodule;
ipmo -Name $UIAmodule;
$VerbosePreference = [System.Management.Automation.ActionPreference]::Continue;

#region Creating a wizard
Write-Host "=======================================================================================";
Write-Host "Creating a wizard`r`n";
Write-Host "expecting success";
New-UIAWizard -Name wizard1 -StartAction {}
Write-Host "expecting fail";
New-UIAWizard -Name wizard1 -StartAction {}
Write-Host "expecting success";
New-UIAWizard -Name wizard2 -StartAction {}
Write-Host "expecting success";
New-UIAWizard -Name 'wizard 3' -StartAction {},{},{}
#endregion Creating a wizard

#region Getting a wizard
Write-Host "`r`n`r`n=======================================================================================";
Write-Host "Getting a wizard`r`n";
Write-Host "expecting success";
Get-UIAWizard -name wizard1
Write-Host "expecting fail";
Get-UIAWizard -name wizard4
Write-Host "expecting success";
Get-UIAWizard -name 'wizard 3'
#endregion Getting a wizard

#region Adding steps to a wizard
Write-Host "`r`n`r`n=======================================================================================";
Write-Host "Adding steps to a wizard`r`n";
Write-Host "expecting success";
(Get-UIAWizard -name wizard1).GetType().Name;
(Get-UIAWizard -name wizard1 | Add-UIAWizardStep -Name step0 -Order 5 -WaitCriteria @{Name='aaa';AutomationId='bbb'} -StepAction {$a = 1;}).GetType().Name;
Get-UIAWizard -name wizard1 | Add-UIAWizardStep -Name step0 -Order 5 -WaitCriteria @{Name='aaa';AutomationId='bbb'} -StepAction {$a = 1;}
Get-UIAWizard -name wizard1 | Add-UIAWizardStep -Name step1 -Order 10 -WaitCriteria @{},@{},@{} -StepAction {},{},{} | Add-UIAWizardStep -Name step2 -Order 20 -WaitCriteria @{} -StepAction {}
Write-Host "expecting fail";
Get-UIAWizard -name wizard2 | Add-UIAWizardStep -Name stepWelcome -Order 0 -WaitCriteria @{},@{},@{} -StepAction {},{},{} -PassThru:$false | Add-UIAWizardStep -Name stepFinish -Order 1000 -WaitCriteria @{} -StepAction {}
Write-Host "expecting success";
Get-UIAWizard -name wizard1 | Add-UIAWizardStep -Name step5 -Order 30 -WaitCriteria @{Name='Next >';IsEnabled=$true} -StepAction {Write-Host "1";},{Write-Host "2";},{Write-Host "3";} | Add-UIAWizardStep -Name step3 -Order 25 -WaitCriteria @{} -StepAction {}
#endregion Adding steps to a wizard


[uiautomation.wizardcollection]::Wizards
[uiautomation.wizardcollection]::Wizards[0].Steps
[uiautomation.wizardcollection]::Wizards[1].Steps
[uiautomation.wizardcollection]::Wizards[2].Steps
[uiautomation.wizardcollection]::Wizards[0].Steps[0]
[uiautomation.wizardcollection]::Wizards[0].Steps[1]
[uiautomation.wizardcollection]::Wizards[0].Steps[2]
[uiautomation.wizardcollection]::Wizards[0].Steps[3]
[uiautomation.wizardcollection]::Wizards[0].Steps[4]
[uiautomation.wizardcollection]::Wizards[0].Steps[5]
[uiautomation.wizardcollection]::Wizards[1].Steps[0]

#region Adding steps to a wizard
Write-Host "`r`n`r`n=======================================================================================";
Write-Host "Adding steps to a wizard`r`n";
Write-Host "expecting success";
[uiautomation.wizardcollection]::Wizards[2].Steps.Count
Get-UIAWizard -Name 'wizard 3' | Add-UIAWizardStep -Name 'step 100' -Order 100 -WaitCriteria @{},@{} -StepAction {$i = 3;},{$j = 4;};
[uiautomation.wizardcollection]::Wizards[2].Steps[0]
[uiautomation.wizardcollection]::Wizards[2].Steps.Count
Get-UIAWizard -Name 'wizard 3' | Remove-UIAWizardStep -Name 'step 100';
[uiautomation.wizardcollection]::Wizards[2].Steps[0]
[uiautomation.wizardcollection]::Wizards[2].Steps.Count
