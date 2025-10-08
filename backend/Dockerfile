# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./TrashBoard.Api/TrashBoard.Api.csproj ./TrashBoard.Api/
COPY ./TrashBoard.Application/TrashBoard.Application.csproj ./TrashBoard.Application/
COPY ./TrashBoard.Domain/TrashBoard.Domain.csproj ./TrashBoard.Domain/
COPY ./TrashBoard.Infrastructure/TrashBoard.Infrastructure.csproj ./TrashBoard.Infrastructure/

RUN dotnet restore ./TrashBoard.Api/TrashBoard.Api.csproj

COPY . .

RUN dotnet publish ./TrashBoard.Api/TrashBoard.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "TrashBoard.Api.dll"]