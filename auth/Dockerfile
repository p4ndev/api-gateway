FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /auth

EXPOSE 80

COPY ./bin/Debug/net6.0/publish/ ./

ENTRYPOINT ["dotnet", "auth.dll"]