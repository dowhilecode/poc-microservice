#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProductService.Catalog/nuget.config", "ProductService.Catalog/"]
COPY ["ProductService.Catalog/ProductService.Catalog.csproj", "ProductService.Catalog/"]
COPY ["ProductService.DataAccess/ProductService.DataAccess.csproj", "ProductService.DataAccess/"]
COPY ["ProductService.Model/ProductService.Model.csproj", "ProductService.Model/"]
COPY ["ManishKumar.POC.Messaging.RMQ.Publisher.1.0.1.nupkg","ProductService.Catalog/"]
copy ["ProductService.Catalog/nuget.config",""]

RUN dotnet restore "ProductService.Catalog/ProductService.Catalog.csproj" --configfile "./nuget.config"
COPY . .
WORKDIR "/src/ProductService.Catalog"
RUN dotnet build "ProductService.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.Catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.Catalog.dll"]