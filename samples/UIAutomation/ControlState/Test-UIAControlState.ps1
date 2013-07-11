ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

Write-Host "should be found:";
Start-Process calc -PassThru | Get-UIAWindow | Test-UIAControlState -SearchCriteria @{controlType="button";name="1"};
Stop-Process -Name calc

Write-Host "should be found:";
Start-Process calc -PassThru | Get-UIAWindow | Test-UIAControlState -SearchCriteria @{controlType="button";name="1"},@{controlType="button";name="2"},@{controlType="button";name="3"};
Stop-Process -Name calc

Write-Host "could not be found:";
Start-Process calc -PassThru | Get-UIAWindow | Test-UIAControlState -SearchCriteria @{controlType="button";name="1"},@{controlType="button";name="2"},@{controlType="button";name="3"},@{controlType="button";name="10"}; # -Verbose;
Stop-Process -Name calc

