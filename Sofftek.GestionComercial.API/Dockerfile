#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sofftek.GestionComercial.API/Sofftek.GestionComercial.API.csproj", "Sofftek.GestionComercial.API/"]
RUN dotnet restore "Sofftek.GestionComercial.API/Sofftek.GestionComercial.API.csproj"
COPY . .
WORKDIR "/src/Sofftek.GestionComercial.API"
RUN dotnet build "Sofftek.GestionComercial.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sofftek.GestionComercial.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sofftek.GestionComercial.API.dll"]