FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Workshop.Api/Workshop.Api.csproj", "src/Workshop.Api/"]
COPY ["Workshop.Logging/Workshop.Logging.csproj", "src/Workshop.Logging/"]
COPY ["Workshop.Data/Workshop.Data.csproj", "src/Workshop.Data/"]
COPY ["Workshop.Car/Workshop.Cars.csproj", "src/Workshop.Car/"]
COPY ["Workshop.Common/Workshop.Common.csproj", "src/Workshop.Common/"]
COPY ["Workshop.Account/Workshop.Account.csproj", "src/Workshop.Account/"]
RUN dotnet restore "src/Workshop.Api/Workshop.Api.csproj"
COPY . .
WORKDIR "/src/Workshop.Api"
RUN dotnet build "Workshop.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Workshop.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Workshop.Api.dll"]