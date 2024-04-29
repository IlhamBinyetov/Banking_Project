#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Banking_Project.PresentationLayer/Banking_Project.PresentationLayer.csproj", "Banking_Project.PresentationLayer/"]
COPY ["Banking_Project.BusinessLayer/Banking_Project.BusinessLayer.csproj", "Banking_Project.BusinessLayer/"]
COPY ["Banking_Project.DataAccessLayer/Banking_Project.DataAccessLayer.csproj", "Banking_Project.DataAccessLayer/"]
COPY ["Banking_Project.DtoLayer/Banking_Project.DtoLayer.csproj", "Banking_Project.DtoLayer/"]
COPY ["Banking_Project.EntityLayer/Banking_Project.EntityLayer.csproj", "Banking_Project.EntityLayer/"]
RUN dotnet restore "./Banking_Project.PresentationLayer/./Banking_Project.PresentationLayer.csproj"
COPY . .
WORKDIR "/src/Banking_Project.PresentationLayer"
RUN dotnet build "./Banking_Project.PresentationLayer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Banking_Project.PresentationLayer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking_Project.PresentationLayer.dll"]