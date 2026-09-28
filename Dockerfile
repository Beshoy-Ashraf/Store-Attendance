FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Directory.Build.props/Directory.Packages.props are auto-imported by MSBuild and carry shared
# settings (TargetFramework, central package versions) that the individual .csproj files rely on —
# they must be present before `dotnet restore` runs, or TargetFramework resolves to empty.
COPY Csproj.slnx Directory.Build.props Directory.Packages.props ./
COPY Domain/Domain.csproj Domain/
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY API/API.csproj API/

RUN dotnet restore API/API.csproj

# Now copy everything else and publish.
COPY . .
RUN dotnet publish API/API.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
RUN apt-get update && apt-get install -y --no-install-recommends libgssapi-krb5-2 \
      && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .

# Railway injects PORT at runtime (a different value per deploy), so it must be read in the shell
# at container start, not baked in at build time via a plain ENV instruction.
EXPOSE 8080
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:${PORT:-8080} dotnet API.dll"]