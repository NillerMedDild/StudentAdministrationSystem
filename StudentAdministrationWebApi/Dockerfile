FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 443
EXPOSE 80

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

ARG CERT_PATH_DEST=/app/cert/localhost-dev.pfx
ENV CertPath=$CERT_PATH_DEST
RUN echo "Env CertPath value is: $CertPath"
COPY cert/localhost-dev.pfx $CertPath

ENTRYPOINT ["dotnet", "StudentAdministrationWebApi.dll"]
