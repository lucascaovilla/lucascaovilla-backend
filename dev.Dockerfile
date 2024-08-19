# Use the official .NET SDK image as base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Expose the port the app runs on
EXPOSE 5000

RUN dotnet tool install --global dotnet-ef --version 8.0.8

# Create a solution and projects for DDD and TDD if they don't exist
CMD if [ ! -f *.sln ]; then \
        dotnet new sln; \
        dotnet new classlib -n Domain; \
        dotnet new classlib -n Application; \
        dotnet new classlib -n Infrastructure; \
        dotnet new webapi -n WebAPI; \
        dotnet sln add Domain/Domain.csproj Application/Application.csproj Infrastructure/Infrastructure.csproj WebAPI/WebAPI.csproj; \
        dotnet add WebAPI/WebAPI.csproj reference Domain/Domain.csproj Application/Application.csproj Infrastructure/Infrastructure.csproj; \
        dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj Application/Application.csproj; \
        mkdir -p Domain/Entities; \
        mkdir -p Application/Services; \
        dotnet add Domain/Domain.csproj package coverlet.collector; \
        dotnet add Application/Application.csproj package coverlet.collector; \
        dotnet add Infrastructure/Infrastructure.csproj package coverlet.collector; \
        dotnet add WebAPI/WebAPI.csproj package coverlet.collector; \
        dotnet add Domain/Domain.csproj package xunit; \
        dotnet add Application/Application.csproj package xunit; \
        dotnet add Infrastructure/Infrastructure.csproj package xunit; \
        dotnet add WebAPI/WebAPI.csproj package xunit; \
        dotnet add WebAPI/WebAPI.csproj package Microsoft.EntityFrameworkCore.Design \
        dotnet add Infrastructure/Infrastructure.csproj package Npgsql.EntityFrameworkCore.PostgreSQL; \
    fi; \
    echo "export PATH=\"$PATH:/root/.dotnet/tools\"" >> ~/.bashrc; \
    dotnet restore; \
    dotnet watch run --urls http://0.0.0.0:5000 --project WebAPI/WebAPI.csproj;
