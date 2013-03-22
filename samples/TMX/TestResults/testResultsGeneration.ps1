param(
	[int]$suites,
	[int]$scenarios,
	[int]$testResults
      )

Measure-Command -Expression {
1..$suites | `
	%{ $null = New-TMXTestSuite -Name $_.ToString();
		for ($i = 1; $i -le $scenarios; $i++) {
			$null = Add-TMXTestScenario -Name "sdrfsdfg";
			for ($j = 1; $j -le $testResults; $j++) {
				$null = Close-TMXTestResult -Name "sdf" -TestPassed;
			}
		}
	}
}
Measure-Command -Expression {
	Export-TMXTestResults -As HTML -Path C:\1\1\test_report.htm;
}