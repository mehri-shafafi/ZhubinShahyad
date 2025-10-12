#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

WORKDIR /app
EXPOSE 8086
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/Contact/Contact.Presentation/Contact.Presentation.csproj", "src/Services/Contact/Contact.Presentation/"]
RUN dotnet restore "src/Services/Contact/Contact.Presentation/Contact.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Contact/Contact.Presentation"
RUN dotnet build "Contact.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.Presentation.dll"]
