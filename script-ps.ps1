Write-Host "Script started... "

If (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
{   
$arguments = "& '" + $myinvocation.mycommand.definition + "'"
Start-Process powershell -Verb runAs -ArgumentList $arguments
Break
}

#whoami /groups /fo csv | convertfrom-csv | where-object { $_.SID -eq "S-1-5-32-544" }

#$elevated = ([Security.Principal.WindowsPrincipal] `
# [Security.Principal.WindowsIdentity]::GetCurrent()
#).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
#write-host $elevated


#$output = whoami /all
#$IsAdministrator = $false
#foreach($line in $output) {
#  if ($line -like "*BUILTIN\Administrators*") {
#      $IsAdministrator = $true
#      break;
#   } 
#} 
#if ($IsAdministrator)
#{
#    Write-Host "The Computer contains Adminstrator priveledges" -ForegroundColor Black -BackgroundColor Green
#} else {
#    Write-Host "The Computer does not have Adminstrator priveledges" -ForegroundColor -BackgroundColor Red
#}


#start-service filebeat
#Write-Host "Finished!"