@echo off

rem Define a constant for the local package folder
set LOCAL_PACKAGE_PATH=C:\NuGetLocalPackages

rem uninstall NDExt tool (if already installed)
dotnet tool uninstall --global NDExt

rem clean previous packages
del .\src\NDExt\bin\Release\*.nupkg

rem build and pack the project
cd src
dotnet build -c Release
dotnet pack -c Release

rem copy the generated .nupkg file to the local package source
mkdir %LOCAL_PACKAGE_PATH%
copy .\NDExt\bin\Release\*.nupkg %LOCAL_PACKAGE_PATH%

rem check if the local package source is already added
set sourceExists=false
for /f "tokens=*" %%i in ('dotnet nuget list source') do (
    echo %%i | findstr /c:"%LOCAL_PACKAGE_PATH%" >nul
    if not errorlevel 1 (
        set sourceExists=true
    )
)

if "%sourceExists%"=="false" (
    rem add the local package folder as a NuGet source if not found
    dotnet nuget add source %LOCAL_PACKAGE_PATH% --name LocalPackages
) else (
    echo LocalPackages source is already added.
)

rem install the tool from the local NuGet package source
dotnet tool install --global NDExt --add-source %LOCAL_PACKAGE_PATH%

pause
