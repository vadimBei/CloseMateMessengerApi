#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/CloseMate.Api/CloseMate.Api.csproj", "src/Services/CloseMate.Api/"]
COPY ["src/Services/ApplicationServices.Implementation/ApplicationServices.Implementation.csproj", "src/Services/ApplicationServices.Implementation/"]
COPY ["src/Services/ApplicationServices.Interfaces/ApplicationServices.Interfaces.csproj", "src/Services/ApplicationServices.Interfaces/"]
COPY ["src/Services/Entities/Entities.csproj", "src/Services/Entities/"]
COPY ["src/Services/Infrastructure.Interfaces/Infrastructure.Interfaces.csproj", "src/Services/Infrastructure.Interfaces/"]
COPY ["src/Services/Utils/Utils.csproj", "src/Services/Utils/"]
COPY ["src/Services/DataAccess.PostgreSQL/DataAccess.PostgreSQL.csproj", "src/Services/DataAccess.PostgreSQL/"]
COPY ["src/Services/OpenAI.Implementations/OpenAI.Implementations.csproj", "src/Services/OpenAI.Implementations/"]
COPY ["src/Services/OpenAI.Interfaces/OpenAI.Interfaces.csproj", "src/Services/OpenAI.Interfaces/"]
COPY ["src/Services/WebClient.Implementations/WebClient.Implementations.csproj", "src/Services/WebClient.Implementations/"]
COPY ["src/Services/WebClient.Interfaces/WebClient.Interfaces.csproj", "src/Services/WebClient.Interfaces/"]
COPY ["src/Services/UseCases/UseCases.csproj", "src/Services/UseCases/"]
RUN dotnet restore "src/Services/CloseMate.Api/CloseMate.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/CloseMate.Api"
RUN dotnet build "CloseMate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloseMate.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloseMate.Api.dll"]