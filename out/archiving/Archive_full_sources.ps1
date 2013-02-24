param(
	[string]$releaseFolder
	)

[string]$baseFolder = 
	$MyInvocation.MyCommand.Path.Substring(0, $MyInvocation.MyCommand.Path.LastIndexOf("\"));
$baseFolder = $baseFolder.Substring(0, $baseFolder.LastIndexOf("\"));
$projectFolder = 
	"C:\Projects\PS\STUPS\";

Write-Host $baseFolder;

New-Item -Path "$($baseFolder)\$($releaseFolder)" -Type directory
Copy-Item -Path "$($projectFolder)\bin*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\C*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\ESXi*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\PS*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\Se*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\te*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\TMX*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*
Copy-Item -Path "$($projectFolder)\UI*" -Destination "$($projectFolder)\out\$($releaseFolder)" -Recurse -Filter *.cs*

[System.Reflection.Assembly]::LoadFrom("$($baseFolder)\binaries\Ionic\zip-v1.9\Release\Ionic.Zip.dll");

    $directoryToZip = "$($baseDirectory)\\$($releaseFolder)"
    $zipfile = new-object Ionic.Zip.ZipFile
    $e = $zipfile.AddDirectory($directoryToZip, "$($baseFolder)\\")
    $zipfile.Save("ZipFiles.ps1.out.zip")
    $zipfile.Dispose()
