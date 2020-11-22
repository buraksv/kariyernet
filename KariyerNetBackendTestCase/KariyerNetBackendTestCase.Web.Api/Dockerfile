#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KariyerNetBackendTestCase.Web.Api/KariyerNetBackendTestCase.Web.Api.csproj", "KariyerNetBackendTestCase.Web.Api/"]
COPY ["KariyerNetBackendTestCase.Business/KariyerNetBackendTestCase.Business.csproj", "KariyerNetBackendTestCase.Business/"]
COPY ["KariyerNetBackendTestCase.Entity/KariyerNetBackendTestCase.Entity.csproj", "KariyerNetBackendTestCase.Entity/"]
COPY ["KariyerNetBackendTestCase.Core/KariyerNetBackendTestCase.Core.csproj", "KariyerNetBackendTestCase.Core/"]
COPY ["KariyerNetBackendTestCase.Enum/KariyerNetBackendTestCase.Enum.csproj", "KariyerNetBackendTestCase.Enum/"]
COPY ["KariyerNetBackendTestCase.Dto/KariyerNetBackendTestCase.Dto.csproj", "KariyerNetBackendTestCase.Dto/"]
COPY ["KariyerNetBackendTestCase.DataAccess/KariyerNetBackendTestCase.DataAccess.csproj", "KariyerNetBackendTestCase.DataAccess/"]
RUN dotnet restore "KariyerNetBackendTestCase.Web.Api/KariyerNetBackendTestCase.Web.Api.csproj"
COPY . .
WORKDIR "/src/KariyerNetBackendTestCase.Web.Api"
RUN dotnet build "KariyerNetBackendTestCase.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KariyerNetBackendTestCase.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KariyerNetBackendTestCase.Web.Api.dll"]
