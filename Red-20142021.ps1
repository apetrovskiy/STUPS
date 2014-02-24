ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Get-UiaWindow -pn UIAutomationTestForms -Verbose | Get-UiaControl Button222 -Win32 -timeout 2000 -Verbose | Read-UiaControlName -Verbose

