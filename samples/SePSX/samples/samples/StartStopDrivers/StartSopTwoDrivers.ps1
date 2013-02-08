Start-SeChrome | Enter-SeURL -URL "http://google.com"; Start-SeChrome -InstanceName "ch" | Enter-SeURL -URL "http://google.com"
Stop-SeChrome -InstanceName $([sepsx.currentdata]::Drivers.Keys)