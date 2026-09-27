FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files first so NuGet restore is cached across builds until a project file actually changes.
COPY Csproj.slnx ./
COPY Domain/Domain.csproj Domain/
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY API/API.csproj API/

RUN dotnet restore API/API.csproj

# Now copy everything else and publish.
COPY . .
RUN dotnet publish API/API.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Railway injects PORT at runtime (a different value per deploy), so it must be read in the shell
# at container start, not baked in at build time via a plain ENV instruction.
EXPOSE 8080
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-8080} dotnet API.dll"]