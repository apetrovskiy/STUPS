ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
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
Wait-UIAWindow -n *about* -Recurse