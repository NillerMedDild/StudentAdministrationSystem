#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["StudentAdministrationTest/StudentAdministrationTest.csproj", "StudentAdministrationTest/"]
RUN dotnet restore "StudentAdministrationTest/StudentAdministrationTest.csproj"
COPY . .
WORKDIR "/src/StudentAdministrationTest"