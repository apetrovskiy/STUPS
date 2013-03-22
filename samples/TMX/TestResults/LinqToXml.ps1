param(
	[int]$suites,
	[int]$scenarios,
	[int]$testResults
      )

C:\Projects\PS\STUPS\samples\samples\TMX\testResultsGenerationBackup.ps1 $suites $scenarios $testResults;

Write-Host "exporting to XML";
Measure-Command -Expression {
	[System.Xml.Linq.XElement]$xel = Get-TestResultsFromSearch
}
[System.Xml.Linq.XDocument]$doc = New-Object System.Xml.Linq.XDocument
$doc.Add($xel)
$doc.Save("c:\1\xel.xml")
notepad c:\1\xel.xml


