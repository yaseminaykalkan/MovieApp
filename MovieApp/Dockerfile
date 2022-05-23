#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MovieApp/MovieApp.csproj", "MovieApp/"]
COPY ["MovieApp.Services/MovieApp.Services.csproj", "MovieApp.Services/"]
COPY ["MovieApp.Data/MovieApp.Data.csproj", "MovieApp.Data/"]
COPY ["MovieApp.Core/MovieApp.Core.csproj", "MovieApp.Core/"]
RUN dotnet restore "MovieApp/MovieApp.csproj"
COPY . .
WORKDIR "/src/MovieApp"
RUN dotnet build "MovieApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieApp.dll"]
