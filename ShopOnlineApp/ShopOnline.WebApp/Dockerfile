#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY ["ShopOnline.WebApp/nuget.config","ShopOnline.WebApp/"]
COPY ["ShopOnline.WebApp/ShopOnline.WebApp.csproj", "ShopOnline.WebApp/"]
COPY ["ShopOnline.Model/ShopOnline.Model.csproj", "ShopOnline.Model/"]
COPY ["ShopOnline.BAL/ShopOnline.BAL.csproj", "ShopOnline.BAL/"]
COPY ["ManishKumar.POC.Messaging.RMQ.Publisher.1.0.2.nupkg","ShopOnline.WebApp/"]
COPY ["ShopOnline.WebApp/nuget.config",""]

RUN dotnet restore "ShopOnline.WebApp/ShopOnline.WebApp.csproj"
COPY . .
WORKDIR "/src/ShopOnline.WebApp"
RUN dotnet build "ShopOnline.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopOnline.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopOnline.WebApp.dll"," --environment=Production"]