$ErrorPreference = 'Stop'

$vsTestConsole = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\Extensions\TestPlatform\vstest.console.exe"
$openCoverConsole = "..\Packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"
$reportGenerator = "..\Packages\ReportGenerator.4.0.0\tools\net47\ReportGenerator.exe"
$msbuild = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe"

$solutionFilePath = "..\Source\DefensiveProgrammingFramework.sln";
$unitTestDll = "..\Test\DefensiveProgrammingFramework.Test\bin\Debug\DefensiveProgrammingFramework.Test.dll"
$outputDirectory = ".\GeneratedReports"
$testResultDirectory = ".\TestResults"
$openCoverReport = "$outputDirectory\openCoverReport.xml"
$codeCoverageReport = "$outputDirectory\CodeCoverageReport\index.htm"

Write-Output "------------------------------------------------------- removing old reports -------------------------------------------------------"

if (Test-Path "$outputDirectory")
{
	Remove-Item -Path "$outputDirectory" -Recurse -Force
}

if (Test-Path "$testResultDirectory")
{
	Remove-Item -Path "$testResultDirectory" -Recurse -Force
}

if (Test-Path "$openCoverReport")
{
	Remove-Item -Path "$openCoverReport"
}

New-Item -ItemType Directory "$outputDirectory"

Write-Output "`n`n"
Write-Output "------------------------------------------------------- compiling solution -------------------------------------------------------"
Write-Output "`n"

& "$msbuild"  "$solutionFilePath" /property:Configuration=Release

Write-Output "------------------------------------------------------- running unit tests -------------------------------------------------------"
Write-Output "`n"

& "$openCoverConsole" -register:user -target:$vsTestConsole -targetargs:"$unitTestDll /Logger:trx" -filter:"+[*]* -[*.Test]*" -mergebyhash -skipautoprops -output:"$openCoverReport"

Write-Output "`n`n"
Write-Output "------------------------------------------------------- generating  code coverage report -------------------------------------------------------"
Write-Output "`n"

& "$reportGenerator" -reports:"$openCoverReport" -targetdir:"$([System.IO.Path]::GetDirectoryName("$codeCoverageReport"))"

& "$codeCoverageReport"

Write-Output "`n`n"
Write-Output "------------------------------------------------------- cleaning up -------------------------------------------------------"
Write-Output "`n"

Remove-Item -Path "$testResultDirectory" -Recurse -Force
Remove-Item -Path "$openCoverReport"