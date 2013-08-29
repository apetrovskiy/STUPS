$testResults = New-Object System.Collections.SortedList;
$testResults.Add("001", @());
$testResults.Add("002", @());
$testResults.Add("003", @());
$testResults['001'] += "OK|good";
$testResults['002'] += "OK|good";
$testResults['002'] += "FAIL|bad";
Write-Host "test results are now:";
$testResults

$testResults['003'] += "FAIL|too many failures";
$testResults['003'] += "FAIL|aaa";
$testResults['003'] += "FAIL|bbbb";
$testResults['003'] += "FAIL|cccc";
Write-Host "test results are now:";
$testResults

Write-Host "test results number are:";
$testResults.Keys

ipmo C:\Projects\PS\STUPS\TMX\TMX\bin\Release35\TMX.dll


    foreach ($testResultNumber in $testResults.Keys) {
        Set-TMXCurrentTestResult "test result name from a list" -Id $testResultNumber;
        $testResultData = $testResults[$testResultNumber];
        if ($null -ne $testResultData -and 0 -lt $testResultData.Count) {
            foreach ($detail in $testResultData) {
		try {
        	        if ($detail.Contains("OK")) {
	                    $detail -match "(?<=OK\|).*"
                	    Add-TMXTestResultDetail ($Matches[0]) -TestResultStatus Passed;
        	        }
	                if ($detail.Contains("FAIL")) {
                	    $detail -match "(?<=FAIL\|).*"
        	            Add-TMXTestResultDetail ($Matches[0]) -TestResultStatus Failed;
	                }
		}
		catch {}
            }
        }
    }

Add-TMXTestResultDetail "finished" -TestResultStatus Passed -Finished;
Search-TMXTestResult | fl id,name,details;

