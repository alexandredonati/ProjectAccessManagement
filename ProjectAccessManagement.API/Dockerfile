# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjectAccessManagement.API/ProjectAccessManagement.API.csproj", "ProjectAccessManagement.API/"]
COPY ["ProjectAccessManagement.Application/ProjectAccessManagement.Application.csproj", "ProjectAccessManagement.Application/"]
COPY ["ProjectAccessManagement.Domain/ProjectAccessManagement.Domain.csproj", "ProjectAccessManagement.Domain/"]
COPY ["ProjectAccessManagement.Repository/ProjectAccessManagement.Repository.csproj", "ProjectAccessManagement.Repository/"]
COPY ["ProjectAccessManagement.Tests/ProjectAccessManagement.Tests.csproj", "ProjectAccessManagement.Tests/"]

RUN dotnet restore "./ProjectAccessManagement.API/ProjectAccessManagement.API.csproj"

COPY . .
WORKDIR "/src/ProjectAccessManagement.API"
RUN dotnet build "./ProjectAccessManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para executar os testes de unidade
RUN dotnet test /src/ProjectAccessManagement.Tests/ProjectAccessManagement.Tests.csproj --verbosity normal

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectAccessManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectAccessManagement.API.dll"]