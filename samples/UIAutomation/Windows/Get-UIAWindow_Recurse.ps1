ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn calc -Recurse | Read-UIAControlName;
Get-UIAWindow -n *about* -Recurse | Read-UIAControlName;
