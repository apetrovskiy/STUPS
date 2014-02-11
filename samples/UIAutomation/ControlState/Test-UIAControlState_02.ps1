ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
$wnd = Start-Process calc -PassThru | Get-UiaWindow
Test-UiaControlState -SearchCriteria @{controltype="radiobutton"} # -Verbose
Test-UiaControlState -SearchCriteria @{controltype="radiobutton";name="gold"} # -Verbose
Test-UiaControlState -SearchCriteria @{controltype="button";name="3"} # -Verbose
