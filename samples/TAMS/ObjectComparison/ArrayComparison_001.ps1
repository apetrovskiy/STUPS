[string]$array01 = "abcd;efgh';ijkl"
[string]$array02 = "abcd;efgh';ijkl"
[string]$array03 = "abcd;ijkl"
[string]$array04 = "efgh';ijkl"

Compare-Object $array01 $array02
Compare-Object $array01 $array03
Compare-Object $array01 $array04
Compare-Object $array03 $array04

ipmo C:\Projects\PS\STUPS\TAMS\TAMS\bin\Release35\TAMS.dll
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject $array01 -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject $array02 -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject $array03 -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject $array04 -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject $null -Verbose

[string[]]$array01 = "abcd;efgh';ijkl".Split(";");
[string[]]$array02 = "abcd;efgh';ijkl".Split(";");
[string[]]$array03 = "abcd;ijkl".Split(";");
[string[]]$array04 = "efgh';ijkl".Split(";");

$array01
$array02
$array03
$array04

Compare-Object $array01 $array02
Compare-Object $array01 $array03
Compare-Object $array01 $array04
Compare-Object $array03 $array04

Compare-TamsObject -ReferenceObject $array01 -DifferenceObject @(,$array01) -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject @(,$array02) -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject @(,$array03) -Verbose
Compare-TamsObject -ReferenceObject $array01 -DifferenceObject @(,$array04) -Verbose

$array01 | %{ $_; Compare-TamsObject -ReferenceObject $_ -DifferenceObject $array01 -Verbose}


