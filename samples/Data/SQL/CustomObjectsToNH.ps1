$myObj = New-Object PSObject;
$myObj | `
	Add-Member -MemberType NoteProperty -Name m1 -Value "text" -PassThru | `
	Add-Member -MemberType NoteProperty -Name m2 -Value 0.01 -PassThru | `
	Add-Member -MemberType ScriptProperty -Name m3 -Value { return 3; };


ipmo C:\Projects\PS\STUPS\Data\Data\bin\Release35\Data.dll;

$myObj | Get-DtSomething



