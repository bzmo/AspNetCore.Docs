# Generate Client SDKs
This document describes how to generate Client SDKs, modelled after the Swagger.json spec.

### Pre-requisite
In a separate Powershell process, start the server:
```
dotnet run --urls="https://localhost:44380" -p .\samples\3.0\TodoApi.Swashbuckle\MoviesWatched.csproj
```
##### Relevant Links upon Application Start:
- SwaggerUI: https://localhost:44380/swagger/index.html
- Swagger.json: https://localhost:44380/swagger/v1/swagger.json


### 1. OpenAPI Generator
```
./genOpenAPIGenClients.ps1 
```
The generated clients can be found in __./clients/openapi-clients/__.
	
### 2. Azure Autorest
```
./genAzureAutoRestClients.ps1
```

The generated clients can be found in __./clients/autorest-clients/__.

> see https://aka.ms/autorest
``` yaml
input-file: swagger.json
namespace: WatchedMovies.Rest
```