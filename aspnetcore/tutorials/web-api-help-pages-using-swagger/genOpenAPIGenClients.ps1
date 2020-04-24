$LANGS = @("csharp","typescript-angular")

# For convenience, the swagger.json file is already hosted: https://bzmo.github.io/AspNetCore.Docs/swagger.json.
$SWAGGER_FILE = "https://bzmo.github.io/AspNetCore.Docs/swagger.json"

foreach ($lang in $LANGS) {
    $cmd = "docker run -v ${PWD}:/local openapitools/openapi-generator-cli generate -i ${SWAGGER_FILE} -g ${lang} -o /local/clients/openapi-clients/${lang}-client"
    iex $cmd
} 
