ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

# getting button 1
$button1inWindow1 = Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton 1;

# opening the About window
Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;

# clicking the button that is under a modal window
$button1inWindow1 | Invoke-UIAButtonClick;