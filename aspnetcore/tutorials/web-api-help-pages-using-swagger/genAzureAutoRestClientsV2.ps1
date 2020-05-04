$VERSIONS = @("1", "2")
$NAMESPACE_PREFIX = "WatchedMovies.Rest."

$PATH_TO_PROJ_ROOT = ".\samples\3.0\TodoApi.Swashbuckle"
$PATH_TO_ASSEMBLY = "{0}\bin\Debug\netcoreapp3.0\MoviesWatched.dll" -f $PATH_TO_PROJ_ROOT
$PATH_TO_CLIENTS = ".\clients\autorest-app-examples"
$PATH_TO_CSPROJ = "{0}\MoviesWatched.csproj" -f $PATH_TO_PROJ_ROOT;

# Build assemblies
dotnet build $PATH_TO_CSPROJ

# Retrieve swagger.json files from project assembly
foreach ($version in $VERSIONS) {
    $version_name = "v{0}" -f $version
    $swagger_dst = "{0}\swagger\{1}" -f ".", $version_name
    $path_to_swagger = "{0}\{1}" -f $swagger_dst, "swagger.json"

    # Create new directory since Swashbuckle CLI requires it
    New-Item -ItemType Directory -Force -Path $swagger_dst

    dotnet swagger tofile --output $path_to_swagger $PATH_TO_ASSEMBLY $version_name

    $csharp_dst = "{0}\ExampleApp-CSharp\csharp\{1}" -f $PATH_TO_CLIENTS, $version_name
    $ts_dst = "{0}\ExampleApp-TypeScript\typescript\{1}" -f $PATH_TO_CLIENTS, $version_name

    # Generate clients
    .\node_modules\.bin\autorest-beta --v3 --csharp --input-file=$path_to_swagger --namespace=$NAMESPACE_PREFIX$version_name --output-folder=$csharp_dst
    .\node_modules\.bin\autorest-beta --v3 --typescript --input-file=$path_to_swagger --namespace=$NAMESPACE_PREFIX$version_name --output-folder=$ts_dst
}

dotnet run --urls="https://localhost:44380" -p $PATH_TO_CSPROJ




