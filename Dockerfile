FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Lollipop.API/Lollipop.API.csproj"
RUN dotnet build "Lollipop.API/Lollipop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lollipop.API/Lollipop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "Lollipop.API.dll"]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Lollipop.API.dll
