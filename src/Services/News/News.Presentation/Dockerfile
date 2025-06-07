#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
WORKDIR /app
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/News/News.Presentation/News.Presentation.csproj", "src/Services/News/News.Presentation/"]
RUN dotnet restore "src/Services/News/News.Presentation/News.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/News/News.Presentation"
RUN dotnet build "News.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "News.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "News.Presentation.dll"]
