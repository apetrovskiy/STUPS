# ipmo UIAutomation;

# variant 1
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1 | Invoke-UIAButtonClick;
# variant 2
$button1 = Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1;
$button1 | Invoke-UIAButtonClick;
# variant 3
$button1 = Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1;
Invoke-UIAButtonClick -InputObject $button1;
# variant 4
Invoke-UIAButtonClick -InputObject (Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -Name 1);


