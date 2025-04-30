#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/News/News.Presentation/News.Presentation.csproj", "src/Services/News/News.Presentation/"]
COPY ["src/Services/News/News.Application/News.Application.csproj", "src/Services/News/News.Application/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["src/Services/News/News.Infrastructure/News.Infrastructure.csproj", "src/Services/News/News.Infrastructure/"]
COPY ["src/Services/News/News.Domain/News.Domain.csproj", "src/Services/News/News.Domain/"]
RUN dotnet restore "./src/Services/News/News.Presentation/News.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/News/News.Presentation"
RUN dotnet build "./News.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./News.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "News.Presentation.dll"]