ipmo C:\Projects\PS\STUPS\TMX\bin\Release35\TMX.dll
ipmo C:\Projects\PS\STUPS\UIAutomation\bin\Release35\UIAutomation.dll

C:\Projects\PS\STUPS\samples\samples\TMX\testTMX.ps1
[System.Xml.Linq.XElement]$xel1 = Get-TestResultsFromSearch -Verbose
[System.Xml.Linq.XDocument]$doc1 = New-Object System.Xml.Linq.XDocument
$doc1.Add($xel1)
$doc1.Save("c:\1\test01.xml")

[TMX.TestData]::ResetData();

C:\Projects\PS\STUPS\samples\samples\TMX\TMXshort.ps1
[System.Xml.Linq.XElement]$xel2 = Get-TestResultsFromSearch -Verbose
[System.Xml.Linq.XDocument]$doc2 = New-Object System.Xml.Linq.XDocument
$doc2.Add($xel2)
$doc2.Save("c:\1\test02.xml")

