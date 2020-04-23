$LANGS = @("csharp","typescript-angular")
$SWAGGER_FILE = "https://bzmo.github.io/AspNetCore.Docs/swagger.json"

foreach ($lang in $LANGS) {
    $cmd = "docker run -v ${PWD}:/local openapitools/openapi-generator-cli generate -i ${SWAGGER_FILE} -g ${lang} -o /local/clients/${lang}-client"
    iex $cmd
} 
