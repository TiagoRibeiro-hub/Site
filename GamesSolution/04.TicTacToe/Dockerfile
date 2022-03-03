#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["04.TicTacToe/04.TicTacToe.csproj", "04.TicTacToe/"]
RUN dotnet restore "04.TicTacToe/04.TicTacToe.csproj"
COPY . .
WORKDIR "/src/04.TicTacToe"
RUN dotnet build "04.TicTacToe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "04.TicTacToe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "04.TicTacToe.dll"]