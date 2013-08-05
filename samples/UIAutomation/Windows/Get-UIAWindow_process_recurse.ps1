ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
#services.msc
sleep -Seconds 2;
Get-UIAWindow -InputObject (Get-Process mmc) -Recurse # fail
Get-UIAWindow -InputObject (Get-Process mmc)
Get-UIAWindow -pn mmc
Get-UIAWindow -pn mmc -Recurse
Get-UIAWindow -Process (Get-Process mmc)
Get-UIAWindow -Process (Get-Process mmc) -Recurse # fail



