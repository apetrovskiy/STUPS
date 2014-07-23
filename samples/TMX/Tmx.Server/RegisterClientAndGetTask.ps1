ipmo C:\Projects\PS\STUPS\TMX\TMX40\bin\Release35\TMX.dll
Start-TmxServer
$task = New-Object TMX.Interfaces.Types.Remoting.TestTask
$task.Id = 3
$task.Name = "4444444"
$task.On = $true
[Tmx.Server.TaskPool]::Tasks.Add($task);
[Tmx.Server.TaskPool]::Tasks
Register-TmxSystemUnderTest -ServerUrl http://localhost:12340
Receive-TmxTestTask
[Tmx.Server.TaskPool]::Tasks


