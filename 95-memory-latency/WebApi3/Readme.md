dotnet publish -c Release
dotnet .\bin\Release\netcoreapp3.0\WebApi3.dll
wget http://localhost:5000/memory/report
wrk -t12 -c400 -d30s --latency http://localhost:5000/memory/classes
wrk -t12 -c400 -d30s --latency http://localhost:5000/memory/structs
wget http://localhost:5000/memory/report
