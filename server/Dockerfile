# Stage 1: Runtime environment (Small image for execution)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Stage 2: Build (Large image with SDK for building)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files (helps Docker cache dependencies)
COPY ["EquipTrack.Api/EquipTrack.Api.csproj", "EquipTrack.Api/"]
COPY ["EquipTrack.Application/EquipTrack.Application.csproj", "EquipTrack.Application/"]
COPY ["EquipTrack.Domain/EquipTrack.Domain.csproj", "EquipTrack.Domain/"]
COPY ["EquipTrack.Infrastructure/EquipTrack.Infrastructure.csproj", "EquipTrack.Infrastructure/"]

# Run Restore (download NuGet packages)
RUN dotnet restore "EquipTrack.Api/EquipTrack.Api.csproj"

# Copy the rest of the source code and build the application
COPY . .
WORKDIR "/src/EquipTrack.Api"
RUN dotnet build "EquipTrack.Api.csproj" -c Release -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "EquipTrack.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final image
FROM base AS final
WORKDIR /app
# Copy the compiled application from the 'publish' stage into the clean runtime environment
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquipTrack.Api.dll"]