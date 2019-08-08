FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src/BookExchange.Api
COPY src/BookExchange.Api/BookExchange.Api.csproj BookExchange/
COPY . .
WORKDIR /src/BookExchange.Api
RUN dotnet build src/BookExchange.Api/BookExchange.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish src/BookExchange.Api/BookExchange.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","BookExchange.Api.dll"]