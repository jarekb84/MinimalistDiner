@echo off
setlocal enabledelayedexpansion

set MSBuildPath="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\"
set MSBuildFound=true
set nUnitPath="packages\NUnit.Runners.2.6.3\tools\"
set nUnitFound=true
set testsDll="MinimalistDiner.Tests\bin\Debug\MinimalistDiner.Tests.dll"

if not exist !MSBuildPath! ( 	
	echo .NET 4.0 x64 version of MSBuild not found, checking for x32 version
	set MSBuildPath="C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
	
	if not exist !MSBuildPath! ( 
		echo .NET 4.0 version of MSBuild not found.		
		set /p MSBuildPath="Enter full path for .NET 4.0 MSBuild, include trailing backslash: "
		
		if not exist !MSBuildPath! ( 
			echo !MSBuildPath! not found
			set MSBuildFound=false;
		)
	)
) 

if not exist !nUnitPath! ( 	
	echo nUnit console runner not found, verify nuget installation of packages.
	set nUnitFound=false;
)

if !MSBuildFound!==true if !nUnitFound!==true (
	!MSBuildPath!\msbuild.exe "MinimalistDiner.sln" /p:configuration=debug
	
	if exist !testsDll! (
		!nUnitPath!\nunit-console !testsDll! /labels
	) else (
		echo MSBuild failed to compile solution, test run aborted!
	)
	
) else (	
	echo Dependencies not found, aborting compilation and test running.
)

pause