FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["StudentAdministrationWebRazer/StudentAdministrationWebRazer.csproj", "StudentAdministrationWebRazer/"]
RUN dotnet restore "StudentAdministrationWebRazer/StudentAdministrationWebRazer.csproj"
COPY . .
WORKDIR "/src/StudentAdministrationWebRazer"
RUN dotnet build "StudentAdministrationWebRazer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StudentAdministrationWebRazer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentAdministrationWebRazer.dll"]