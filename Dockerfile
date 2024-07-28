FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Stage 1: Build the app

## Install and update system packages
RUN apt-get update &&  \
    apt-get upgrade &&  \
    apt-get install -y --no-install-recommends apt-utils \
    
RUN dotnet --version
RUN dotnet dev-certs https --trust

COPY . .
WORKDIR /src/VolunteerVision.Api
RUN dotnet restore "VolunteerVision.Api.csproj"
RUN dotnet build "VolunteerVision.Api.csproj" -c Release -o /app/build

# Stage 2: Publish the app
FROM build AS publish
RUN dotnet publish "VolunteerVision.Api.csproj" -c Release -o /app/publish

# Stage 3: Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "VolunteerVision.Api.dll"]