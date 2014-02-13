ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll
ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Measure-Command -Expression { $wnd = Start-Process calc -PassThru | Get-UiaWindow }
$Logger = [UIAutomation.AutomationFactory]::GetLogger("c:\1\20140213_0001.txt");
Measure-Command -Expression { Get-UiaButton 1 }
Measure-Command -Expression { Get-UiaButton -SearchCriteria @{controlType="button";automationId="13*"} }


