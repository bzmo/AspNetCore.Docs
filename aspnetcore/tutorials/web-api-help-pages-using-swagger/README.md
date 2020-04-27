# Generate Client SDKs
This document describes how to generate Client SDKs, modelled after the Swagger.json spec.

### Pre-requisite
In a separate Powershell process, start the server from this directory:
```
cd {HOME_DIR}\AspNetCore.Docs\aspnetcore\tutorials\web-api-help-pages-using-swagger
dotnet run --urls="https://localhost:44380" -p .\samples\3.0\TodoApi.Swashbuckle\MoviesWatched.csproj
```
##### Relevant Links upon Application Start:
- SwaggerUI: https://localhost:44380/swagger/index.html
- Swagger.json: https://localhost:44380/swagger/v1/swagger.json

### 1. OpenAPI Generator
```
./genOpenAPIGenClients.ps1 
```
The generated clients can be found in __./clients/openapi-clients/__. See example apps in __./clients/openapi-app-examples__.
	
### 2. Azure Autorest
```
./genAzureAutoRestClients.ps1
```

The generated clients can be found in __./clients/autorest-clients/__. See example apps in __./clients/autorest-app-examples__.

> see https://aka.ms/autorest
``` yaml
input-file: swagger.json
namespace: WatchedMovies.Rest
typescript:
  output-folder: ./clients/autorest-clients/typescript-client
csharp:
  output-folder: ./clients/autorest-clients/csharp-client 
```
