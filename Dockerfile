FROM mcr.microsoft.com/dotnet/sdk:7.0 as build 
WORKDIR /app
COPY ./DockerizeNLayer.Core/*.csproj ./DockerizeNLayer.Core/
COPY ./DockerizeNLayer.Repository/*.csproj ./DockerizeNLayer.Repository/
COPY ./DockerizeNLayer.Service/*.csproj ./DockerizeNLayer.Service/
COPY ./DockerizeNLayer.Caching/*.csproj ./DockerizeNLayer.Caching/
COPY ./DockerizeNLayer.API/*.csproj ./DockerizeNLayer.API/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./DockerizeNLayer.API/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /publish . 
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","DockerizeNLayer.API.dll"]