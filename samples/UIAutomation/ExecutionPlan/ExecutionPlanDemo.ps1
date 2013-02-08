ipmo C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll;
# ipmo [path]\UIAutomation.dll

Show-UIAExecutionPlan -Max 100;
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAButton; Get-UIAMenuItem;