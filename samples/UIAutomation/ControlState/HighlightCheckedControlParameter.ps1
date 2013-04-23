ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

Start-Process calc -PassThru | Get-UIAWindow | Test-UIAControlState -SearchCriteria @{controlType="button";name="3"}
Stop-Process -Name calc

Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem Help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn calc -WithControl @{controlType="button";name="9"}
Get-UIAWindow -pn calc -WithControl @{controlType="button";name="OK"}
Stop-Process -Name calc

