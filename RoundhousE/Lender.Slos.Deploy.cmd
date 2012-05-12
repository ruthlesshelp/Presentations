@ECHO OFF

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "database.deploy.msbuild" /p:DBServer=(local)\SQLExpress;DBName=Lender.Slos;RoundhouseSilent=False

if "%1" NEQ "noprompt" PAUSE