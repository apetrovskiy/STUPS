ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
[UIAutomation.AutomationFactory]::GetLogger("c:\1\new_log.txt")
$btn1 = Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton 1 | Invoke-UiaButtonClick | Invoke-UiaButtonClick;
$btn1.Control.Click();
$btn1.Invoke();
$btn1.Keyboard.TypeText("333");
Get-UiaButton -n 10;
Get-UiaButton -n 2;



