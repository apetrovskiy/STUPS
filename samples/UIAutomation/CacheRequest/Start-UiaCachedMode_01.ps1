ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Start-UiaCachedMode -Verbose;
# Start-UiaCachedMode -Property Name,AutomationId,ClassName,ControlType,Value -Pattern InvokePattern,ValuePattern -Scope Descendants -Filter Raw -Verbose;
# Start-UiaCachedMode -Property Name,AutomationId,ClassName,ControlType,Value,ProcessId -Pattern InvokePattern,ValuePattern -Verbose;
# Get-UiaWindow -n *powershell* # -Verbose
$wnd = Start-Process calc -PassThru | Get-UiaWindow
$btn1 = Get-UiaButton 1;
# $btn2 = Get-UiaButton 2;
# $btn3 = Get-UiaButton 3;
# Get-UiaButton;
$btn1 = Get-UiaButton -n 1;
