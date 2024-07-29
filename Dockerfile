FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . .
WORKDIR /src/VolunteerVision.Api
RUN dotnet restore
RUN dotnet build -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM publish AS setup_enviroment
EXPOSE 5458 
EXPOSE 5459
ENV ASPNETCORE_URLS=http://+:5458;https://+:5459

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolunteerVision.Api.dll"]