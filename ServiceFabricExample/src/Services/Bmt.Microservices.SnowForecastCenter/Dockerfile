FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src

# Copy available csproj files

# For linux
#COPY src/Services/Bmt.Microservices.SnowForecastCenter/*.csproj /src/csproj-files/

# For windows
COPY ["src/Services/Bmt.Microservices.SnowForecastCenter/Bmt.Microservices.SnowForecastCenter.csproj", "src/csproj-files/"]


# Restore

# For linux
#RUN dotnet restore /src/csproj-files/*.csproj

# For windows
RUN dotnet restore "src/csproj-files/Bmt.Microservices.SnowForecastCenter.csproj" -p:RestoreUseSkipNonexistentTargets=false -nowarn:msb3202,nu1503

COPY . .

# Publish
WORKDIR /src/src/Services/Bmt.Microservices.SnowForecastCenter
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Bmt.Microservices.SnowForecastCenter.dll"]