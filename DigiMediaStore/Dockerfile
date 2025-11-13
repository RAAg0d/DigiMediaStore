# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы решения и проектов
COPY ["DigiMediaStore.sln", "./"]
COPY ["DigiMediaStore/DigiMediaStore.csproj", "DigiMediaStore/"]
COPY ["DigiMediaStore.BusinessLogic/DigiMediaStore.BusinessLogic.csproj", "DigiMediaStore.BusinessLogic/"]
COPY ["DigiMediaStore.DataAccess/DigiMediaStore.DataAccess.csproj", "DigiMediaStore.DataAccess/"]
COPY ["DigiMediaStore.Domain/DigiMediaStore.Domain.csproj", "DigiMediaStore.Domain/"]

# Восстанавливаем зависимости
RUN dotnet restore "DigiMediaStore/DigiMediaStore.csproj"

# Копируем весь исходный код
COPY DigiMediaStore/ ./DigiMediaStore/
COPY DigiMediaStore.BusinessLogic/ ./DigiMediaStore.BusinessLogic/
COPY DigiMediaStore.DataAccess/ ./DigiMediaStore.DataAccess/
COPY DigiMediaStore.Domain/ ./DigiMediaStore.Domain/

# Собираем и публикуем приложение
WORKDIR "/src/DigiMediaStore"
RUN dotnet build "DigiMediaStore.csproj" -c Release -o /app/build
RUN dotnet publish "DigiMediaStore.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

# Копируем опубликованное приложение
COPY --from=build /app/publish .

# Устанавливаем переменные окружения
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "DigiMediaStore.dll"]

