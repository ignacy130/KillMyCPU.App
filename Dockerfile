FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["KillMyCPU.WebApp/KillMyCPU.WebApp.csproj", "KillMyCPU.WebApp/"]
RUN dotnet restore "KillMyCPU.WebApp/KillMyCPU.WebApp.csproj"
COPY . .
WORKDIR "/src/KillMyCPU.WebApp"
RUN dotnet build "KillMyCPU.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KillMyCPU.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KillMyCPU.WebApp.dll"]