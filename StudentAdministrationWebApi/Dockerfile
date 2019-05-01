FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY StudentAdministrationWebApi/StudentAdministrationWebApi.csproj StudentAdministrationWebApi/
RUN dotnet restore StudentAdministrationWebApi/StudentAdministrationWebApi.csproj
COPY . .
WORKDIR /src/StudentAdministrationWebApi
RUN dotnet build StudentAdministrationWebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StudentAdministrationWebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "StudentAdministrationWebApi.dll"]
