ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$wnd = Start-Process calc -PassThru | Get-UiaWindow
$wnd
$wnd.Children.Panes
$wnd.Descendants.Buttons
"==============================================================================="
$wnd.Descendants.Buttons[0]
"==============================================================================="
$wnd.Descendants.Buttons[3..5]
"==============================================================================="
$wnd.Descendants.Buttons['13*']




