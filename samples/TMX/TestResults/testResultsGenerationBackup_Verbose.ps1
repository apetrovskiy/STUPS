param(
	[int]$suites,
	[int]$scenarios,
	[int]$testResults
      )

del 3.db3
ipmo C:\Projects\PS\STUPS\TMX\bin\Release35\TMX.dll;
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
New-TMXTestDB -FileName 3.db3 -Name 3 -Verbose
Measure-Command -Expression {
	Backup-TMXTestResults -Verbose;
}

Close-TMXTestDB -Name 3 -Verbose