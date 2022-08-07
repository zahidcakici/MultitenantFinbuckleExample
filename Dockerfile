FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MultitenantExample/MultitenantExample.csproj", "MultitenantExample/"]
RUN dotnet restore "MultitenantExample/MultitenantExample.csproj"
COPY . .
WORKDIR "/src/MultitenantExample"
RUN dotnet build "MultitenantExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MultitenantExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultitenantExample.dll"]
