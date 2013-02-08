ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll

Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem View | Invoke-UIAMenuItemExpand | Get-UIAMenuItem Worksheets | Move-UIACursor -X 3 -Y 3;
Get-UIAMenuItem Mortgage | Invoke-UIAMenuItemClick;
Get-UIAEdit *purchase*price* -Win32 | Set-UIAEditText "123";
Get-UIAEdit *purchase*price* -Win32 | Clear-UIAControlText;

