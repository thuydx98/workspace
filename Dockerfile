### STAGE 1: Build front-end ###
FROM node:14.15-alpine AS frontend
WORKDIR /app
COPY frontend/package.json frontend/package-lock.json ./
RUN npm install
COPY ./frontend .
RUN npm run build-docker

### STAGE 2: Build back-end ###
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["backend/JJWS.Api/JWS.Api.csproj", "JWS.Api/"]
COPY ["backend/JJWS.Mail/JWS.Mail.csproj", "JWS.Mail/"]
COPY ["backend/JJWS.Common/JWS.Common.csproj", "JWS.Common/"]
COPY ["backend/JJWS.Infrastructure/JWS.Infrastructure.csproj", "JWS.Infrastructure/"]
COPY ["backend/JJWS.Service/JWS.Service.csproj", "JWS.Service/"]
COPY ["backend/JJWS.Data/JWS.Data.csproj", "JWS.Data/"]
COPY ["backend/JJWS.EntityFramework/JWS.EntityFramework.csproj", "JWS.EntityFramework/"]
COPY ["backend/JJWS.Contracts/JWS.Contracts.csproj", "JWS.Contracts/"]

RUN dotnet restore "JWS.Api/JWS.Api.csproj"
COPY ./backend .
COPY --from=frontend /app/build ./JWS.Api/wwwroot

WORKDIR "/src/JWS.Api"
RUN dotnet build "JWS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JWS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JWS.Api.dll"]