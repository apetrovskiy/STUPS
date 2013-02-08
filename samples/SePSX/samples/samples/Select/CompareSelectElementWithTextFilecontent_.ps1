ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll
$htmlSelect = Start-SeChrome | Enter-SeURL "C:\Projects\PS\STUPS\TestData\select.htm" | Get-SeWebElement -TagName select | Get-SeSelection -All | Read-SeWebElementText
[string[]]$textSelect = Get-Content -Path "C:\Projects\PS\STUPS\TestData\select.txt"
Compare-Object -ReferenceObject $htmlSelect -DifferenceObject $textSelect
[string[]]$textSelect2 = Get-Content -Path "C:\Projects\PS\STUPS\TestData\select2.txt"
Compare-Object -ReferenceObject $htmlSelect -DifferenceObject $textSelect2