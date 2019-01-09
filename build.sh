clear

TOKEN=$(<sonar.token)
if [ -z "$1"  ] 
    then
        SLN="ElGuerre.Taskin.Api.sln"
else
    SLN="$1"
fi

# dotnet tool install --global dotnet-sonarscanner
# dotnet tool install --global dotnet-reportgenerator-globaltool

#dotnet sonarScanner begin /k:'Taskin' /d:sonar.organization='juanluelguerre-github' /d:sonar.host.url='https://sonarcloud.io' /d:sonar.login="$TOKEN" /d:sonar.language='cs' /d:sonar.exclusions='**/bin/**/*,**/obj/**/*' /d:sonar.coverage.exclusions='test/**' /d:sonar.cs.opencover.reportsPaths="$(pwd)\lcov.opencover.xml"
#dotnet restore $SLN
# dotnet build $SLN # It doesn't woks on MAC for msbuild 16. Issue: https://github.com/SonarSource/sonar-scanner-msbuild/issues/649
# Neither force for: dotnet msbuild /toolsversion:15 ElGuerre.Taskin.Api.sln
# msbuild $SLN # It works 

# dotnet test './test/ElGuerre.Taskin.Api.Tests/ElGuerre.Taskin.Api.Tests.csproj' /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutputFormat=lcov /p:CoverletOutput='../lcov'
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=OpenCover /p:CoverletOutput=./TestResults/ ./test/ElGuerre.Taskin.Api.Tests/ElGuerre.Taskin.Api.Tests.csproj
reportgenerator -reports:$(pwd)/TestResults/coverage.opencover.xml -targetdir ./TestResults/Reports/ -reportTypes:"HTMLInline;Cobertura"


# dotnet sonarScanner end /d:sonar.login="$TOKEN"