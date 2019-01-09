@echo off

REM dotnet build-server shutdown
REM del .\.sonarqube /S /Q

setlocal

set /p TOKEN=<sonar.token
IF [%1]==[] SET SLN="./ElGuerre.Taskin.Api.sln"
IF NOT [%1]==[] SET SLN=%1

REM dotnet tool install --global dotnet-sonarscanner
REM dotnet tool install --global dotnet-reportgenerator-globaltool

dotnet sonarScanner begin /k:"Taskin" /d:sonar.organization="juanluelguerre-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%TOKEN%" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*" /d:sonar.coverage.exclusions="test/**" /d:sonar.cs.opencover.reportsPaths="%cd%\lcov.opencover.xml"
dotnet restore %SLN%
dotnet build %SLN%
dotnet test test/ElGuerre.Taskin.Api.Tests/ElGuerre.Taskin.Api.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=\"opencover,lcov\" /p:CoverletOutput=../lcov
dotnet sonarscanner end /d:sonar.login="%TOKEN%"