@ECHO OFF

mkdir build\logs

%MSBuildRoot%\msbuild.exe "build/runner.msbuild" /t:Rebuild;Analyze /p:Configuration=Debug  /l:FileLogger,Microsoft.Build.Engine;logfile=build/logs/runner.log
if "%1" NEQ "noprompt" PAUSE
