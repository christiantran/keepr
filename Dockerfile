FROM microsoft/dotnet:2.1.300-sdk

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet keepr.dll