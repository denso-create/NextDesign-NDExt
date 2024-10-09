@echo off

rem uninstall NDExt tool (if already installed)
dotnet tool uninstall --global NDExt

rem clean previous packages
del .\src\NDExt\bin\Release\*.nupkg

rem build and pack the project
cd src
dotnet build -c Release
dotnet pack -c Release

rem copy the generated .nupkg file to a local package source
mkdir C:\NuGetLocalPackages
copy .\NDExt\bin\Release\*.nupkg C:\NuGetLocalPackages

rem add the local package folder as a NuGet source
dotnet nuget add source C:\NuGetLocalPackages --name LocalPackages

rem install the tool from the local NuGet package source
dotnet tool install --global NDExt --add-source C:\NuGetLocalPackages

pause
