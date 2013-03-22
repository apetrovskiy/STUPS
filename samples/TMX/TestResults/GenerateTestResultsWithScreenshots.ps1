param(
	[int]$suites,
	[int]$scenarios,
	[int]$testResults
      )

$testResultCounter = 0;
1..$suites | `
	%{ $null = New-TMXTestSuite -Name "suite_$($_.ToString())";
		for ($i = 1; $i -le $scenarios; $i++) {
			$null = Add-TMXTestScenario -Name "scenario_$($i)";
			for ($j = 1; $j -le $testResults; $j++) {
				$testResultCounter++;
				try { Get-UIAWindow -n "no window" -Timeout 100 -OnErrorScreenshot; } catch { Write-Host "$($testResultCounter/$testResults/$scenarios/$suites*100)%";}
				$null = Close-TMXTestResult -Name "test result $($i)" -TestPassed:$false -OnErrorScreenShot;
			}
		}
	}

Write-Host "Suites:" (Search-TMXTestSuite).Count;
Write-Host "Scenarios:" (Search-TMXTestScenario).Count;
Write-Host "Test results:" (Search-TMXTestResult).Count;