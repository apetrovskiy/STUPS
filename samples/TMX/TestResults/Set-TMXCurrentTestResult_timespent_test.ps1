ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll
Set-TMXCurrentTestResult "tr01" -Description "tr0001" -Id 001;
sleep -Seconds 5;
Set-TMXCurrentTestResult "tr02" -Description "tr0002" -Id 002;
sleep -Seconds 10;
Set-TMXCurrentTestResult "tr03" -Description "tr0003" -Id 003;
sleep -Seconds 3;
Add-TMXTestResultDetail "tr003 detail 01";
sleep -Seconds 3;
Add-TMXTestResultDetail "tr003 detail 02" -TestResultStatus Passed;
sleep -Seconds 3;
Set-TMXCurrentTestResult "tr04" -Description "tr0004" -Id 004;
Set-TMXCurrentTestResult "tr05" -Description "tr0005" -Id 005;
[Hashtable]$results = @{};
Search-TMXTestResult | %{ try { $results += @{"$($_.Id)"="$($_.Timespent)"}; } catch {} }

if ((6 -lt $results['001']) -or (5 -gt $results['001'])) {
	Write-Host "Error in 001";
}

if ((11 -lt $results['002']) -or (10 -gt $results['002'])) {
	Write-Host "Error in 002";
}

if ((10 -lt $results['003']) -or (9 -gt $results['003'])) {
	Write-Host "Error in 003";
}

if (1 -lt $results['004']) {
	Write-Host "Error in 004";
}

$results
