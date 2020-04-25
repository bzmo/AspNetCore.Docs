
npm install

# Fetch the swagger.json file
iwr https://localhost:44380/swagger/v1/swagger.json -o swagger.json

# Generate clients with settings in README.md
.\node_modules\.bin\autorest-beta --v3 --csharp --typescript
