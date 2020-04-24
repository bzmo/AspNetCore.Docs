
npm install

# Fetch the swagger.json file
iwr https://localhost:44380/swagger/v1/swagger.json -o swagger.json

# Generate clients
.\node_modules\.bin\autorest-beta --v3 --csharp --csharp.output-folder=./clients/autorest-clients/csharp-client 
.\node_modules\.bin\autorest-beta --v3 --typescript --typescript.output-folder=./clients/autorest-clients/typescript-client
