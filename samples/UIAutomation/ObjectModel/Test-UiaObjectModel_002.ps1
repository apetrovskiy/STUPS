ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
$btn = Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton 1;
# typing in 477
$btn.NavigateToPreviousSibling().Highlight().Click().NavigateToPreviousSibling().Click().Click().Highlight();
