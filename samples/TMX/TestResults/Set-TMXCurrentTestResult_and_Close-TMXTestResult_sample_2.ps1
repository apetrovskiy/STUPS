ipmo C:\Projects\ps\STUPS\TMX\TMX\bin\Release35\TMX.dll

Set-TMXCurrentTestResult "tr001" -Id 001
Set-TMXCurrentTestResult "tr002" -Id 002
Set-TMXCurrentTestResult "tr003" -Id 003

# one more test result with Id=004 and status = Failed
Add-TMXSimpleTestResult -TestResultName "tr004" -Id 004 -TestResultStatus Failed

# one more test result with Id=002 and status = Failed
Add-TMXSimpleTestResult -TestResultName "tr002" -Id 002 -TestResultStatus Failed


Close-TMXTestResult -Id 003 -TestResultStatus Passed


# we expect the following
# Id=001 TestResultStatus NotTested
# Id=002 TestResultStatus Failed
# Id=002 TestResultStatus NotTested
# Id=003 TestResultStatus Passed
# Id=004 TestResultStatus Failed
Search-TMXTestResult | FT Id,Name,Status


