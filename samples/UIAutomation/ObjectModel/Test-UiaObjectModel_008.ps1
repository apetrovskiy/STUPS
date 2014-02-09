ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$wnd = Start-Process calc -PassThru | Get-UiaWindow
$wnd
$wnd.Children
$wnd.Descendants



