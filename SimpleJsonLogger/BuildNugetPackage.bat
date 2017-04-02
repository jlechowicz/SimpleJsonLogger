@echo off
title Nuget package command line batch builder
echo Building local nuget package...
nuget pack SimpleJsonLogger.nuspec -properties Configuration=Release
echo Nuget package built. Deploying to folder.
move *.nupkg C:\nuget-local
echo Package deployed.
pause