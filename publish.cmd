echo off
echo #--------------------------------------
echo # Publish to nuget.org
echo #--------------------------------------

rem [Remarks] Please Set NUGET_APIKEY env varible on your computer

rem clean packages
del .\src\NDExt\bin\Release\*.nupkg

rem build & pack
cd src
dotnet build -c Release 
dotnet pack -c Release 

rem push
cd NDExt\bin\Release
dotnet nuget push "*.nupkg" --source https://api.nuget.org/v3/index.json --skip-duplicate --api-key %NUGET_APIKEY%
