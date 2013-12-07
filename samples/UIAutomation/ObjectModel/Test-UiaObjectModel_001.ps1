ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
$btn = Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton 1;
# navigating to the 4 button, highlighting the button
# navigating to the 7 button, highlighting it and clicking
$btn.NavigateToPreviousSibling().Highlight().NavigateToPreviousSibling().HIghlight().Click();
