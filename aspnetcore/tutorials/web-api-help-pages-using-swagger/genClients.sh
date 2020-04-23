#!/bin/bash

docker pull swaggerapi/swagger-codegen-cli

SWAGGER_FILE"./swagger.json"
CLIENTS_DIR"./clients"

docker run --rm -v  generate -i $SWAGGER_FILE -l typescript-angular -o "${CLIENTS_DIR}/client-ts"
swagger-codegen generate -i $SWAGGER_FILE -l csharp -o "${CLIENTS_DIR}/client-csharp"
