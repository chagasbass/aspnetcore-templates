#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
WORKDIR /src
COPY ["Chagas.API/Chagas.Worker.API", "Chagas.API/"]
COPY ["Chagas.Extensions/Chagas.Extensions.csproj", "Chagas.Extensions/"]
COPY ["Chagas.Shared/Chagas.Shared.csproj", "Chagas.Shared/"]
COPY ["Chagas.Tests/Chagas.Tests.csproj", "Chagas.Tests/"]
COPY ["Chagas.Domain/Chagas.Domain.csproj", "Chagas.Domain/"]
COPY ["Chagas.Application/Chagas.Application.csproj", "Chagas.Application/"]
COPY ["Chagas.Infra.Data/Chagas.Infra.Data.csproj", "Chagas.Infra.Data/"]
RUN dotnet restore "Chagas.API/Chagas.API.csproj"
COPY . .
WORKDIR "/src/Chagas.API"
RUN dotnet build "Chagas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chagas.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chagas.API.dll"]