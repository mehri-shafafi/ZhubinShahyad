#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
WORKDIR /app
EXPOSE 82

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/Educations/Education.Presentation/Education.Presentation.csproj", "src/Services/Educations/Education.Presentation/"]
RUN dotnet restore "src/Services/Educations/Education.Presentation/Education.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Educations/Education.Presentation"
RUN dotnet build "Education.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Education.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Education.Presentation.dll"]
