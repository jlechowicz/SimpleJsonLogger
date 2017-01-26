@echo off
title Nuget package command line batch builder
echo Building local nuget package...
nuget pack SimpleJsonLogger.nuspec -properties Configuration=Release
pause