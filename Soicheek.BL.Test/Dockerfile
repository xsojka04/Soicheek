FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Soicheek.DAL/Soicheek.DAL.csproj", "Soicheek.DAL/"]
COPY ["Soicheek.BL/Soicheek.BL.csproj", "Soicheek.BL/"]
COPY ["Soicheek.BL.Test/Soicheek.BL.Test.csproj", "Soicheek.BL.Test/"]
RUN dotnet restore "Soicheek.BL.Test/Soicheek.BL.Test.csproj"
COPY . .
WORKDIR "/src/Soicheek.BL.Test"
RUN dotnet test ./Soicheek.BL.Test.csproj