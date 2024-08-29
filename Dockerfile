FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY Domain/Domain.csproj ./Domain/
COPY Application/Application.csproj ./Application/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY WebAPI/WebAPI.csproj ./WebAPI/
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80
ENV ConnectionStrings__DefaultConnection="Host=${DB_HOST};Database=${DB_NAME};Username=${DB_USER};Password=${DB_PASSWORD}"

ENTRYPOINT ["dotnet", "WebAPI.dll"]
