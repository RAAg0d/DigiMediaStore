# DigiMediaStore API - Документация

## Описание
API для цифрового медиа-магазина с поддержкой пользователей, контента и заказов.

## Запуск проекта

### Предварительные требования
- .NET 8.0 SDK
- PostgreSQL (локально или удаленно)
- Visual Studio 2022 или VS Code

### Шаги запуска

1. **Клонирование и переход в папку проекта**
   ```bash
   cd DigiMediaStore
   ```

2. **Восстановление пакетов**
   ```bash
   dotnet restore
   ```

3. **Настройка базы данных**
   - Убедитесь, что PostgreSQL запущен
   - Проверьте строку подключения в `appsettings.json`
   - Примените миграции:
   ```bash
   dotnet ef database update --project ../DigiMediaStore.DataAccess --startup-project .
   ```

4. **Запуск приложения**
   ```bash
   dotnet run
   ```

5. **Открытие Swagger UI**
   - Перейдите по адресу: `https://localhost:7xxx/swagger` (порт будет показан в консоли)
   - Или: `http://localhost:5xxx/swagger`

## Доступные эндпоинты

### UserController (`/api/user`)
- `GET /api/user` - Получить всех пользователей
- `GET /api/user/{id}` - Получить пользователя по ID
- `POST /api/user` - Создать нового пользователя
- `PUT /api/user` - Обновить пользователя
- `DELETE /api/user/{id}` - Удалить пользователя

### ContentController (`/api/content`)
- `GET /api/content` - Получить весь контент
- `GET /api/content/{id}` - Получить контент по ID
- `POST /api/content` - Создать новый контент
- `PUT /api/content` - Обновить контент
- `DELETE /api/content/{id}` - Удалить контент

### OrderController (`/api/order`)
- `GET /api/order` - Получить все заказы
- `GET /api/order/{id}` - Получить заказ по ID
- `GET /api/order/user/{userId}` - Получить заказы пользователя
- `POST /api/order` - Создать новый заказ
- `PUT /api/order` - Обновить заказ
- `DELETE /api/order/{id}` - Удалить заказ

### GenreController (`/api/genre`)
- `GET /api/genre` - Получить все жанры
- `GET /api/genre/{id}` - Получить жанр по ID
- `POST /api/genre` - Создать новый жанр
- `PUT /api/genre` - Обновить жанр
- `DELETE /api/genre/{id}` - Удалить жанр

### ReviewController (`/api/review`)
- `GET /api/review` - Получить все отзывы
- `GET /api/review/{id}` - Получить отзыв по ID
- `GET /api/review/content/{contentId}` - Получить отзывы по контенту
- `GET /api/review/user/{userId}` - Получить отзывы пользователя
- `POST /api/review` - Создать новый отзыв
- `PUT /api/review` - Обновить отзыв
- `DELETE /api/review/{id}` - Удалить отзыв

## Особенности реализации

### Контракты (DTO)
- Используются отдельные модели для запросов и ответов
- Исключены лишние поля из моделей БД
- Добавлена валидация с помощью Data Annotations

### Маппинг
- Используется библиотека Mapster для преобразования объектов
- Автоматическое маппинг между контрактами и моделями БД

### Документация
- Полная XML-документация для всех методов
- Swagger UI с примерами запросов и ответов
- Описание всех HTTP-кодов ответов

## Тестирование

### Через Swagger UI
1. Откройте Swagger UI
2. Выберите нужный эндпоинт
3. Нажмите "Try it out"
4. Заполните параметры
5. Нажмите "Execute"

### Примеры запросов

#### Создание пользователя
```json
POST /api/user
{
  "email": "user@example.com",
  "passwordHash": "hashed_password",
  "fullName": "Иван Иванов"
}
```

#### Создание контента
```json
POST /api/content
{
  "title": "Новый фильм",
  "description": "Описание фильма",
  "contentTypeId": 1,
  "genreId": 1,
  "price": 299.99,
  "releaseDate": "2024-01-01T00:00:00Z"
}
```

## Структура проекта

```
DigiMediaStore/
├── Controllers/          # API контроллеры
├── Contracts/           # DTO модели
│   ├── User/
│   ├── Content/
│   └── Order/
├── Models/              # Дополнительные модели
├── Program.cs           # Конфигурация приложения
└── appsettings.json    # Настройки подключения к БД
```

## Устранение неполадок

### Ошибка подключения к БД
- Проверьте, что PostgreSQL запущен
- Убедитесь в правильности строки подключения
- Проверьте права доступа пользователя БД

### Ошибки компиляции
- Выполните `dotnet clean` и `dotnet restore`
- Убедитесь, что все зависимости установлены

### Swagger не отображается
- Проверьте, что проект запущен в режиме Development
- Убедитесь, что `GenerateDocumentationFile` установлен в `true`
