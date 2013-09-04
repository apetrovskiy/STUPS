ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

# getting button 1 from the first instance
$button1inWindow1 = Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton 1;

# getting button 2 from the second instance
$button2inWindow2 = Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton 2;

# clicking buttons from both instances
$button1inWindow1 | Invoke-UIAButtonClick; $button2inWindow2 | Invoke-UIAButtonClick;