ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -n *about* | Invoke-UIAMenuItemClick;

# the good old way to get a window by process name
Get-UIAWindow -pn calc;

# all windows the process exposes
Get-UIAWindow -pn calc -Recurse;

# the About Calculator window
Get-UIAWindow -pn calc -Name *about*;

# both windows, "Calculator" and "AboutCalculator"
Get-UIAWindow -pn calc -Name *calc*;

# the main window (ClassName -eq 'CalcFrame')
Get-UIAWindow -pn calc -Class *frame*;

# the About window (ClassName -eq '#32770')
Get-UIAWindow -pn calc -Class *327* | Read-UIAControlClass;
Get-UIAWindow -pn calc -Class "#32770";

