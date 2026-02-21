#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

WORKDIR /app
EXPOSE 8083
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/Services/Products/Products.Presentation/Products.Presentation.csproj", "src/Services/Products/Products.Presentation/"]
RUN dotnet restore "src/Services/Products/Products.Presentation/Products.Presentation.csproj"
# copy all source code
COPY . .

WORKDIR "/src/src/Services/Products/Products.Presentation"

# Build stage
RUN dotnet build "Products.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "Products.Presentation.dll"]
