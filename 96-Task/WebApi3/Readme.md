dotnet publish -c Release
dotnet .\bin\Release\netcoreapp3.0\WebApi3.dll
wrk -t12 -c400 -d30s --latency http://localhost:5000/math/sync
wrk -t12 -c400 -d30s --latency http://localhost:5000/math/async