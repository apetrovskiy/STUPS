ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;

services.msc
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn calc -Recurse | Read-UIAControlName;
Get-UIAWindow -n *about* -Recurse | Read-UIAControlName;
Stop-Process -Name calc -Force;

Write-Host "======================";
Get-UIAWindow -pn mmc | Read-UIAControlName;
Write-Host "======================";

#Get-UIAWindow -pn mmc | Get-UIAMenuItem File | Invoke-UIAMenuItemClick;
#Get-UIAMenuItem -Name "*Options*" | Invoke-UIAMenuItemClick;
#Get-UIAChildWindow Options | Get-UIAButton -Name *delete*;

Get-UIAWindow -pn mmc -Recurse | Read-UIAControlName;
Get-UIAWindow -pid (Get-Process mmc).Id -Recurse | Read-UIAControlName;
Get-UIAWindow -InputObject (Get-Process mmc) -Recurse | Read-UIAControlName;
Stop-Process -Name mmc -Force;
