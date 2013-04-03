ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll

Set-TMXCurrentTestResult "test result 01" -id 001
Set-TMXCurrentTestResult "test result 02" -id 002
Add-TMXTestResultDetail "tr 02 detail 01"
Add-TMXTestResultDetail "tr 02 detail 02"
Add-TMXTestResultDetail "tr 02 detail 03"
Add-TMXTestResultDetail "tr 02 detail 02" -TestResultStatus Failed
Set-TMXCurrentTestResult "test result 03" -id 003
Add-TMXTestResultDetail "tr 03 detail 01" -TestResultStatus Passed
Set-TMXCurrentTestResult "test result 04" -id 004
Add-TMXTestResultDetail "tr 04 detail 01" -TestResultStatus KnownIssue
Set-TMXCurrentTestResult "test result 05" -id 005
Add-TMXTestResultDetail "tr 05 detail 01" -TestResultStatus KnownIssue -Finished
Add-TMXTestResultDetail "tr 05 detail 02" -TestResultStatus Passed -Finished

Get-TMXTestResultDetails
Get-TMXTestResultStatus
Get-TMXTestResultDetails -Id 001
Get-TMXTestResultStatus -Id 001
Get-TMXTestResultDetails -Id 001 -Verbose
Get-TMXTestResultDetails -Id 002
Get-TMXTestResultStatus -Id 002

Get-TMXTestResultDetails -Id 003
Get-TMXTestResultStatus -Id 003
Get-TMXTestResultDetails -Id 004
Get-TMXTestResultStatus -Id 004
Get-TMXTestResultDetails -Id 005
Get-TMXTestResultStatus -Id 005

