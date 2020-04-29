﻿
npm install

$VERSIONS = @("1", "2")

# Fetch the swagger.json file
foreach ($version in $VERSIONS) {
    $src = "https://localhost:44380/swagger/v{0}/swagger.json" -f $version
    $dst = "./swaggerSpec/v{0}/" -f $version
    $swagger_loc = "$dst{0}" -f "swagger.json"

    # Create new directory since iwr requires it
    New-Item -ItemType Directory -Force -Path $dst

    # Fetch JSON
    iwr -uri $src -o $swagger_loc

    $ts_dst = "./clients/autorest-clients/typescript/v{0}" -f $version
    $csharp_dst = "./clients/autorest-clients/csharp/v{0}" -f $version

    # Generate clients
    .\node_modules\.bin\autorest-beta --v3 --csharp --typescript --input-file=$swagger_loc --namespace="WatchedMovies.Rest.v"$version `
        --csharp.output-folder=$csharp_dst --typescript.output-folder=$ts_dst
}
