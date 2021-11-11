FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UniversityApp.API/UniversityApp.API.csproj", "UniversityApp.API/"]
RUN dotnet restore "src/UniversityApp.API/UniversityApp.API.csproj"
COPY . .
WORKDIR "/src/UniversityApp.API"
RUN dotnet build "UniversityApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniversityApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniversityApp.API.dll"]
