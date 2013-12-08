ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
#Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton 1;
Get-UiaWindow -n *calc* | Get-UiaEdit -Value 22* -Sec 1;



