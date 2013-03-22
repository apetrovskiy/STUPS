param(
	[int]$suites,
	[int]$scenarios,
	[int]$testResults
      )

1..$suites | `
	%{ $null = New-TMXTestSuite -Name "suite_$($_.ToString())";
		for ($i = 1; $i -le $scenarios; $i++) {
			$null = Add-TMXTestScenario -Name "scenario_$($i)";
			for ($j = 1; $j -le $testResults; $j++) {
				$null = Close-TMXTestResult -Name "test result $($i)" -TestPassed;
			}
		}
	}

Write-Host "Suites:" (Search-TMXTestSuite).Count;
Write-Host "Scenarios:" (Search-TMXTestScenario).Count;
Write-Host "Test results:" (Search-TMXTestResult).Count;