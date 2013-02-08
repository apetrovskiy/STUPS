[int]$global:clickCount = 0;
[string]$global:lastClickedButton;
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton -n [1-9] | Register-UIAInvokedEvent -EventAction { $global:clickCount++; },{ param($src, $e) $global:lastClickedButton = $src.Current.Name; }; 
sleep -Seconds 1;
Get-UIAButton -Name [1-9] | Invoke-UIAButtonClick;
sleep -Seconds 1;
$global:clickCount
$global:lastClickedButton

# use the Get-UIAControlDescendants cmdlet to collect all the visible buttons
# use the Register-UIAInvokedEvent cmdlet to assign an event action to each button
Start-Process calc -PassThru | `
Get-UIAWindow | `
Get-UIAControlDescendants -ControlType Button | `
Register-UIAInvokedEvent -EventAction {param($src) "$($src.Current.Name) clicked" >> $env:TEMP\calc.log;}



