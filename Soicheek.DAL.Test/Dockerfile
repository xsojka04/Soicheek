FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Soicheek.DAL/Soicheek.DAL.csproj", "Soicheek.DAL/"]
COPY ["Soicheek.DAL.Test/Soicheek.DAL.Test.csproj", "Soicheek.DAL.Test/"]
RUN dotnet restore "Soicheek.DAL.Test/Soicheek.DAL.Test.csproj"
COPY . .
WORKDIR "/src/Soicheek.DAL.Test"
RUN dotnet test ./Soicheek.DAL.Test.csproj