FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY *.sln .
COPY Pokedex/*.csproj ./Pokedex/
COPY Pokedex.Test/*.csproj ./Pokedex.Test/
RUN dotnet restore

COPY Pokedex/. ./Pokedex/
COPY Pokedex.Test/. ./Pokedex.Test/

WORKDIR /app/Pokedex
RUN dotnet publish -c Release -o /out --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Pokedex.dll"]
