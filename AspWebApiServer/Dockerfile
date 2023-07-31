#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80 9285

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AspWebApiServer/AspWebApiServer.csproj", "AspWebApiServer/"]
RUN dotnet restore "AspWebApiServer/AspWebApiServer.csproj"
COPY . .
WORKDIR "/src/AspWebApiServer"
RUN dotnet build "AspWebApiServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspWebApiServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspWebApiServer.dll", "--urls", "http://0.0.0.0:9285"]