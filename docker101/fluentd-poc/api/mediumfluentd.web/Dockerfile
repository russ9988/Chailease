FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet build /warnaserror -c Release "mediumfluentd.web.sln"

FROM build AS publish
WORKDIR /src
RUN dotnet publish --no-self-contained --no-build --no-restore -c Release -o /app/publish "./mediumfluentd.web/mediumfluentd.web.csproj"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mediumfluentd.web.dll"]