
npm install

$VERSIONS = @("1", "2")
$NAMESPACE = "WatchedMovies.Rest.v"

# Fetch the swagger.json file
foreach ($version in $VERSIONS) {

    $src = "https://localhost:44380/swagger/v{0}/swagger.json" -f $version
    $dst = "./swaggerSpec/v{0}/" -f $version
    $swagger_loc = "$dst{0}" -f "swagger.json"

    # Create new directory since iwr requires it
    New-Item -ItemType Directory -Force -Path $dst

    # Fetch JSON
    iwr -uri $src -o $swagger_loc

    $csharp_dst = "./clients/autorest-clients/csharp/v{0}" -f $version
    $ts_dst = "./clients/autorest-clients/typescript/v{0}" -f $version

    # Generate clients
    .\node_modules\.bin\autorest-beta --v3 --typescript --input-file=$swagger_loc --namespace=$NAMESPACE$version --output-folder=$ts_dst

    .\node_modules\.bin\autorest-beta --v3 --csharp --input-file=$swagger_loc --namespace=$NAMESPACE$version --output-folder=$csharp_dst
}
