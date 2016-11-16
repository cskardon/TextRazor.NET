REM MyGet Build Commands

@echo On
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%BuildCounter%" == "" (
   set version=--version-suffix ci-%BuildCounter%
)

REM (optional) build.bat is in the root of our repo, cd to the correct folder where sources/projects are
cd src

REM Restore
call dotnet restore
if not "%errorlevel%"=="0" goto failure

REM Build
REM - Option 1: Run dotnet build for every source folder in the project
REM   e.g. call dotnet build <path> --configuration %config%
REM - Option 2: Let msbuild handle things and build the solution
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" ..\TextRazor.Net.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
REM call dotnet build --configuration %config%
if not "%errorlevel%"=="0" goto failure

REM Unit tests
cd TextRazor.Net.Tests
call dotnet test --configuration %config%
if not "%errorlevel%"=="0" goto failure

REM Package
cd..
mkdir %cd%\Artifacts
call dotnet pack ..\src\TextRazor.Net --configuration %config% %version% --output Artifacts
if not "%errorlevel%"=="0" goto failure


:success
exit 0

:failure
exit -1