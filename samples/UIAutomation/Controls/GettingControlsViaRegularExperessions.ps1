ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton 5 | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n 5 | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -a 135 | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n 5 -Win32 | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n 5 -Regex | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n [5] -Regex | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n [\d] -Regex | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n [\w] -Regex | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n "store|equal|entr" -Regex | Invoke-UiaButtonClick;
Start-Process calc -PassThru | Get-UiaWindow | Get-UiaButton -n "store|equal|entr|spac" -Regex | Invoke-UiaButtonClick;

