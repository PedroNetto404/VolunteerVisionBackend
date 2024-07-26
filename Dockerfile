# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Debug: Check the dotnet installation
RUN echo "Checking dotnet installation..." && dotnet --info

# Copy the .csproj files and restore dependencies
COPY ["src/VolunteerVision.Api/VolunteerVision.Api.csproj", "VolunteerVision.Api/"]
COPY ["src/VolunteerVision.Application/VolunteerVision.Application.csproj", "VolunteerVision.Application/"]
COPY ["src/VolunteerVision.Domain/VolunteerVision.Domain.csproj", "VolunteerVision.Domain/"]
COPY ["src/VolunteerVision.Infra/VolunteerVision.Infra.csproj", "VolunteerVision.Infra/"]

RUN dotnet restore "VolunteerVision.Api/VolunteerVision.Api.csproj"

# Copy the rest of the source code and build the application
COPY . .
WORKDIR /src/VolunteerVision.Api
RUN dotnet build "VolunteerVision.Api.csproj" -c Release -o /app/build

# Stage 2: Publish Stage
FROM build AS publish
RUN dotnet publish "VolunteerVision.Api.csproj" -c Release -o /app/publish

# Stage 3: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolunteerVision.Api.dll"]
