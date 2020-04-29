# Generate Client SDKs
This document describes how to generate Client SDKs, modelled after the Swagger.json spec.

### Pre-requisites

See the versioned API controllers created [here](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/3.0/TodoApi.Swashbuckle/Controllers).

In a separate Powershell process, start the server from this directory:
```
cd {HOME_DIR}\AspNetCore.Docs\aspnetcore\tutorials\web-api-help-pages-using-swagger
dotnet run --urls="https://localhost:44380" -p .\samples\3.0\TodoApi.Swashbuckle\MoviesWatched.csproj
```
##### Relevant Links upon Application Start-Up:
- SwaggerUI: https://localhost:44380/swagger/index.html
- Swagger.json: https://localhost:44380/swagger/v1/swagger.json
- Swagger.json: https://localhost:44380/swagger/v2/swagger.json
	
### 1. Azure Autorest (Selected for Development)
```
./genAzureAutoRestClients.ps1
```

The generated clients can be found in [__./clients/autorest-clients/__](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/clients/autorest-clients). See example apps in [__./clients/autorest-app-examples__](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/clients/autorest-app-examples).

### 2. OpenAPI Generator
```
./genOpenAPIGenClients.ps1 
```
The generated clients can be found in [__./clients/openapi-clients/__](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/clients/openapi-clients). See example apps in [__./clients/openapi-app-examples__](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/clients/openapi-app-examples).
