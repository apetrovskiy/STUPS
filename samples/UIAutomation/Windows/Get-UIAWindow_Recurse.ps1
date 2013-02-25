# run it with Administrator's privileges
ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;

services.msc
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;

Write-Host "process name";
Get-UIAWindow -pn calc | Read-UIAControlName;
Write-Host "process name + recurse";
Get-UIAWindow -pn calc -Recurse | Read-UIAControlName;

Write-Host "process name + name";
Get-UIAWindow -pn calc -n *about* | Read-UIAControlName;

Write-Host "name";
Get-UIAWindow -n *about* | Read-UIAControlName;
Write-Host "process name + recurse";
Get-UIAWindow -n *about* -Recurse | Read-UIAControlName;
Stop-Process -Name calc -Force;

Write-Host "======================";
Get-UIAWindow -pn mmc | Read-UIAControlName;
Write-Host "======================";

Get-UIAWindow -pn mmc | Get-UIAMenuItem File | Invoke-UIAMenuItemClick | Get-UIAMenuItem -Name "*Options*" | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn mmc | Get-UIAMenuItem help | Invoke-UIAMenuItemClick | Get-UIAMenuItem -Name "*about*" | Invoke-UIAMenuItemClick;
Get-UIAChildWindow Options | Get-UIAButton -Name *delete*;

Write-Host "process name + recurse";
Get-UIAWindow -pn mmc -Recurse | Read-UIAControlName;

Write-Host "process name + name";
Get-UIAWindow -pn mmc -n *options* | Read-UIAControlName;

Write-Host "process id + recurse";
Get-UIAWindow -pid (Get-Process mmc).Id -Recurse | Read-UIAControlName;

Write-Host "process object + recurse";
Get-UIAWindow -InputObject (Get-Process mmc) -Recurse | Read-UIAControlName;
Stop-Process -Name mmc -Force;
