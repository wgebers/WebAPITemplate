# WebAPITemplate
Dotnet Core Template Web API Project with unit tests
# Notes
Project will start in http mode at http://localhost:5112
OpenAPI Documentation at http://localhost:5112/openapi/v1.json
Run project with dotnet run --profile https --project ApiProject/ApiProject.csproj

Run tests with dotnet test

Two entra apps are registered

WebAPI-App - the actual api endpoint. 
WebAPI-TestClient - To use with postman or representing your external app calling the API using client credentials. 
