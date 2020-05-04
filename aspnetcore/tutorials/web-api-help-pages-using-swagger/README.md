# Generate Client SDKs using Azure AutoRest
This document describes how to generate Client SDKs using Azure AutoRest, modelled after the Swagger.json spec.

### Pre-requisites

- See the versioned API controllers created [here](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/3.0/TodoApi.Swashbuckle/Controllers).

- Helpful to read the [Microsoft REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md).
	
### Azure Autorest
```
./init.ps1
./genAzureAutoRestClientsV2.ps1
```
See example apps in [__./clients/autorest-app-examples__](https://github.com/bzmo/AspNetCore.Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/clients/autorest-app-examples).

##### Relevant Links upon Application Start-Up:
- SwaggerUI: https://localhost:44380/swagger/index.html
- Swagger.json: https://localhost:44380/swagger/v1/swagger.json
- Swagger.json: https://localhost:44380/swagger/v2/swagger.json
