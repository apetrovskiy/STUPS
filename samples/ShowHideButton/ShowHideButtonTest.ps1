ipmo .\UIAutomation.dll
[bool]$global:buttonVisible1 = $true;
[bool]$global:buttonVisible2 = $true;
[bool]$global:buttonAddedAgain = $false;
Get-UIAWindow -n ShowHideButton | Get-UIAButton -n Button | Register-UIAStructureChangedEvent -ChildRemoved -EventAction {"01" >> c:\report.txt; $global:buttonVisible1=$false; "1" >> c:\report.txt;} -Verbose
Get-UIAWindow -n ShowHideButton | Get-UIAButton -n Button | Register-UIAStructureChangedEvent -ChildRemoved -EventAction {"02" >> c:\report.txt; $global:buttonVisible2=$false; "2" >> c:\report.txt;} -Verbose
Get-UIAWindow -n ShowHideButton | Register-UIAStructureChangedEvent -ChildAdded -EventAction {$global:buttonAddedAgain=$true; "3" >> c:\report.txt;} -Verbose
#sleep -Seconds 5
#Write-Host "1" $global:buttonVisible1
#Write-Host "2" $global:buttonVisible2
#Write-Host "3" $global:buttonAddedAgain

while ($global:buttonVisible1 -eq $true -and $global:buttonVisible2 -eq $true){
	sleep -Seconds 1;
	Write-Host "1" $global:buttonVisible1
	Write-Host "2" $global:buttonVisible2
	Write-Host "waiting...";
}
Write-Host "completed";
Write-Host "1" $global:buttonVisible1
Write-Host "2" $global:buttonVisible2
Write-Host "3" $global:buttonAddedAgain