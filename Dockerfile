FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 5285
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

COPY ["TaskManagement.API/TaskManagement.API.csproj", "TaskManagement.API/"]
COPY ["TaskManagement.Application/TaskManagement.Application.csproj", "TaskManagement.Application/"]
COPY ["TaskManagement.Persistence/TaskManagement.Persistence.csproj", "TaskManagement.Persistence/"]
COPY ["Taskmanagement.Domain/Taskmanagement.Domain.csproj", "Taskmanagement.Domain/"]

RUN dotnet restore "TaskManagement.API/TaskManagement.API.csproj"

COPY . .

WORKDIR "/src/TaskManagement.API"
RUN dotnet build "TaskManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "TaskManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "TaskManagement.API.dll" ]
