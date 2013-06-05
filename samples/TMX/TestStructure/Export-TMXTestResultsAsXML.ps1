ipmo C:\Projects\PS\STUPS\UIA\UIAutomation\bin\Release35\UIAutomation.dll;
ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll;
New-TMXTestSuite "s 01" | Add-TMXTestScenario "sc 001";
Add-TMXTestScenario "sc 002";
Close-TMXTestResult "tr 001";
Close-TMXTestResult "tr 002" -TestPassed;
Close-TMXTestResult "tr 003" -KnownIssue;
Close-TMXTestResult "tr 004" -TestResultStatus Passed;
Add-TMXTestScenario "sc 003";
New-TMXTestSuite "s 02" | Add-TMXTestScenario "sc 00001";
Set-TMXCurrentTestResult  "tr 0001"; # -TestResultStatus Passed;
Set-TMXCurrentTestResult  "tr 0002";
Set-TMXCurrentTestResult  "tr 0003"; # -TestPassed;
Set-TMXCurrentTestResult  "tr 0004"; # -KnownIssue;
Set-TMXCurrentTestResult  "tr 0005" -Id 11111;
Set-TMXCurrentTestResult  "tr 0006";
Add-TMXTestResultDetail "detail detail detail";
Set-TMXCurrentTestResult  "tr 0007";
Add-TMXTestResultDetail "detail 01" -TestResultStatus Passed;
Add-TMXTestResultDetail "detail 02" -TestResultStatus Failed;
Add-TMXSimpleTestResult "tr 0008" -TestResultStatus Passed;
Add-TMXTestResultDetail "detail 03" -TestResultStatus Passed -Finished;
Export-TMXTestResults -As xml -Path c:\1\new_xml.xml
Search-TMXTestResult > c:\1\new_xml.txt




