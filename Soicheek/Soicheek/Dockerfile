FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Soicheek/Soicheek/Soicheek.csproj", "Soicheek/Soicheek/"]
COPY ["Soicheek/Soicheek.Client/Soicheek.Client.csproj", "Soicheek/Soicheek.Client/"]
RUN dotnet restore "./Soicheek/Soicheek/./Soicheek.csproj"
COPY . .
WORKDIR "/src/Soicheek/Soicheek"
RUN dotnet build "./Soicheek.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Soicheek.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soicheek.dll"]