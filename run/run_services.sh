#!/bin/bash
#Thanks Camilo Martinez for his article https://dev.to/equiman/run-a-command-in-external-terminal-with-net-core-d4l
parent="$(dirname $PWD)"
osascript <<EOF
tell application "Terminal" to do script  "dotnet run --project ${parent}/BaseService/BaseService.Host"
tell application "Terminal" to do script  "dotnet run --project ${parent}/AuthServer/IdentityServer/AuthServer.Host"
tell application "Terminal" to do script  "dotnet run --project ${parent}/MicroServices/Business/Business.Host"
tell application "Terminal" to do script  "dotnet run --project ${parent}/MicroServices/FileStorage/FileStorage.Host"
tell application "Terminal" to do script  "dotnet run --project ${parent}/Gateways/WebAppGateway/WebAppGateway.Host"
EOF
exit 0