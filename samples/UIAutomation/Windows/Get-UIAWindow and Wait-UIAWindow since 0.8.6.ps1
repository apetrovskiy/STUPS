Start-Process calc;
sleep -Milliseconds 500;
Get-UIAWindow -Class Console* | Read-UIAControlName;
Get-UIAWindow -Class *frame* | Read-UIAControlName;


Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem -Name help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -Name *about* | Invoke-UIAMenuItemClick;
Get-UIAWindow -pn calc -Recurse | Read-UIAControlName;
Get-UIAWindow -pn calc -n *about* | Read-UIAControlName;


Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -n *about* | Invoke-UIAMenuItemClick;
# -Recurse = $false, though you can set it $true
Get-UIAWindow -pn calc;
Get-UIAWindow -pid (Get-Process calc).Id;
Get-UIAWindow -InputObject (Get-Process calc);
# -Recurse = $true
Get-UIAWindow -pn calc -Name *about*; # one window
Get-UIAWindow -pn calc -Name *calc*; # two windows
# earlier, we needed to issue somethink like:
Get-UIAWindow -pn calc | Get-UIAChildWindow -Name *about*; # one window


Start-Process calc -PassThru | Get-UIAWindow | Get-UIAMenuItem help | Invoke-UIAMenuItemExpand | Get-UIAMenuItem -n *about* | Invoke-UIAMenuItemClick;
Start-Process calc -PassThru;

# by process name
# $true
Wait-UIAWindow -pn calc;
# $true
Wait-UIAWindow -pn calc -n *about*;
# $true
Wait-UIAWindow -pn calc -c *32770*;
# $true
Wait-UIAWindow -pn calc -c *frame*;
# $false
Wait-UIAWindow -pn calc -c *aaa*;

# by process object
# $true
Wait-UIAWindow -InputObject (Get-Process calc);

# by process Id
# $true
Wait-UIAWindow -pid (Get-Process calc).Id;
# $true
Wait-UIAWindow -pid (Get-Process calc).Id -n *calc*;
# $true
Wait-UIAWindow -pid (Get-Process calc).Id -n *about*;
# $false
Wait-UIAWindow -pid (Get-Process calc).Id -n *asdf*;

# by window title (name)
# $false (there is no recursive sarch by default)
Wait-UIAWindow -n *about*
# $true
#Wait-UIAWindow -n *about* -Recurse




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






Get-UIAWindow -n *wizard*title* -Seconds 120 | Wait-UIAControlState -SearchCriteria @{controlType="text";name="*complete*"} -Seconds 300;





# start calc.exe and ensure that it's in the Standard mode
# run code:
Get-UIAWindow -pn calc -Seconds 60 -WithControl @{controltype="button";name="clear*all*"}
# change mode to Statistics: menu item View -> Statistics
# the Get-UIAWindow cmdlet immediately returns the window. The CAD button is the button that has name "Clear all..."


