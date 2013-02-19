@ECHO OFF

mkdir build\logs

%MSBuildRoot%\msbuild.exe "build\runner.msbuild" /t:Rebuild;Test /p:Configuration=Debug /l:FileLogger,Microsoft.Build.Engine;logfile=build\logs\runner.log;verbosity=detailed
if "%1" NEQ "noprompt" PAUSE
