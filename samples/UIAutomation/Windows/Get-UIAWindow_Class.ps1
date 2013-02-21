ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Start-Process calc;
sleep -Milliseconds 500;
Get-UIAWindow -Class Console* | Read-UIAControlName;
Get-UIAWindow -Class *frame* | Read-UIAControlName;



