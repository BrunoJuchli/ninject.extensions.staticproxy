SET Configuration=Release
SET Action=Build
SET UserTarget=Build

SET ResultDir=.\Results

SET BuildFile=ninject.extensions.staticproxy.sln
SET BuildLogFile=%BuildFile%

SET MSBuildPath=%ProgramFiles(x86)%\MSBuild\14.0\Bin\
SET MSBuildParameters=/maxcpucount /nodeReuse:false /nologo /detailedsummary /consoleloggerparameters:Summary;Verbosity=minimal
SET MSBuildFileLogParameters=/fl1 /flp1:Summary;Verbosity=normal;LogFile=%BuildLogFile%.log
SET MSBuildErrorFileLogParameters=/fl2 /flp2:NoSummary;ErrorsOnly;LogFile=%BuildLogFile%.errors.log
SET MSBuildWarningFileLogParameters=/fl3 /flp3:NoSummary;WarningsOnly;LogFile=%BuildLogFile%.warnings.log

nuget restore %BuildFile%
IF ERRORLEVEL 1 GOTO Failed

"%MSBuildPath%\MSBUILD.EXE" %BuildFile% /t:%UserTarget% %MSBuildParameters% %MSBuildFileLogParameters% %MSBuildErrorFileLogParameters% %MSBuildWarningFileLogParameters%
IF ERRORLEVEL 1 GOTO Failed

gitlink.exe . -f %BuildFile% -ignore Integration,Integration.Tests,Ninject.Extensions.StaticProxy.Tests
IF ERRORLEVEL 1 GOTO Failed

nuget pack ".\ninject.extensions.staticproxy\ninject.extensions.staticproxy.csproj" -Version "0.2.1.1"
IF ERRORLEVEL 1 GOTO Failed

CALL %PrintSuccessful%
GOTO End

:Failed
CALL %PrintFailed%

:End
CALL %PrintTime%

rem pause if double clicked only
if %0 == "%~0" pause