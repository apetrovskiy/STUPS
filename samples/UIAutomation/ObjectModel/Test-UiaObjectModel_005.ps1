ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$btn = Get-UiaWindow -n *calc* | Get-UiaButton 1
$btn.GetType()
$btn.NavigateToParent().gettype()
$btn.NavigateToParent().getsupportedpatterns()

