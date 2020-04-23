### Steps to Generate Clients
1. Run the _MoviesWatched_ project located in __./samples/3.0/TodoApi.Swashbuckle/__ to generate the following:
    - SwaggerUI: https://localhost:44380/swagger/index.html
    - Swagger.json: https://localhost:44380/swagger/v1/swagger.json
    
    
    ```
    dotnet run --urls="https://localhost:44380" -p .\samples\3.0\TodoApi.Swashbuckle\MoviesWatched.csproj
    ```
    For convenience, the _swagger.json_ file is already hosted at https://bzmo.github.io/AspNetCore.Docs/swagger.json.
2. Generate the clients:
    ```
    ./genClients.ps1
    ```
    The generated clients can be found in __./clients/__.
