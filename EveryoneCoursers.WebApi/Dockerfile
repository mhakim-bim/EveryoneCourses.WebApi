FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EveryoneCoursers.WebApi/EveryoneCoursers.WebApi.csproj", "EveryoneCoursers.WebApi/"]
RUN dotnet restore "EveryoneCoursers.WebApi/EveryoneCoursers.WebApi.csproj"
COPY . .
WORKDIR "/src/EveryoneCoursers.WebApi"
RUN dotnet build "EveryoneCoursers.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EveryoneCoursers.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EveryoneCoursers.WebApi.dll"]
