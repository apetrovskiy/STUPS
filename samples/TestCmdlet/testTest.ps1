ipmo C:\tests\UIAutomation.dll;
Write-Host "assuming the the services.msc snap-in is running and the Properties window is open";
Stop-Process -Name mmc;
Start-Process -FilePath $env:SystemRoot\System32\mmc.exe -ArgumentList services.msc
Get-UIAWindow -p mmc | Get-UIADataItem -Name BranchCache | Invoke-UIAControlContextMenu | Get-UIAMenuItem -Name Properties | Invoke-UIAMenuItemClick

Write-Host "checking the OK button (right)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK'} -ver

Write-Host "checking the Cancel button (right)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='Cancel'} #-ver

Write-Host "checking IsEnabled (wrong IsEnabled)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='Apply';IsEnabled=$true} #-ver

Write-Host "checking the OK and Cancel buttons (right)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK'},@{Name='Cancel';IsEnabled=$true;IsOffscreen=$false} #-ver

Write-Host "checking the OK and Cancel buttons (wrong IsOffscreen)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK'},@{Name='Cancel';IsEnabled=$false;IsOffscreen=$false} #-ver

Write-Host "checking the OK and Cancel buttons (wrong AutomationId)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK';AutomationId='uuu'},@{Name='Cancel';IsEnabled=$true;IsOffscreen=$false} -ver

Write-Host "checking the OK and Cancel buttons (wrong parameter name, Exception will be raised)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK'},@{Name='Cancel';IsEnabled=$true;IsOffscreen=$false;LocalizedConrolName='sss'} -ver

Write-Host "checking the OK and Cancel buttons (wrong LocalizedControlType)";
Get-UIAWindow -p mmc | Test-UIAControlState -SearchCriteria @{Name='OK'},@{Name='Cancel';IsEnabled=$true;IsOffscreen=$false;LocalizedControlType='sss'} -ver