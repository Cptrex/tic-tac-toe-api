# Крестики-Нолики API
---

#### Описание
ASP .NET CORE WEB API приложение для игры в крестики-нолики.
* __Размер игры__: 3х3
* __Количество игроков__: 2

---
#### Требования
* MySql Server >= 8.0.3
* Entity Framework Core >=7.0.3
* .NET 6
* Microsoft Visual Studio 2022
* Newtonsoft.Json >= 13.0

---
### Endpoints

Контроллер| Маршрут | Описание
:---------| :------:|---------:
|GameController | __api/v1/game/make-move__ |Сделать ход |
|GameController | __api/v1/game/client-update__ |Принудительный апдейт игровой сессии |
|RoomController | __api/v1/room/create__ |Создание комнаты для игры |
|RoomController | __api/v1/room/delete__ |Удаление комнаты |
|RoomController | __api/v1/room/enter__  |Войти в комнату по номеру комнаты |
|RoomController | __api/v1/room/leave__  |Выйти из комнаты. Если комнату покидает создатель, то комната удаляется |


---
### Response Code API

Название         | Response Api Code | Описание |
:----------------| :----------------:|----------:
|RoomNotFound    | 1                 | Комната не найдена
|MakeMoveError   | 2                 | Ошибка при выполнении хода
|WrongQuequeTurn | 4                 | Ошибка при нарушении очередности хода
|ContinuePlay    | 5                 | Продолжение игры после хода
|EndPlay         | 6                 | Игра окончена
|Draw            | 7                 | Ничья
|RoomCreated     | 8                 | Комната создана
|RoomDeleted     | 9                 | Комната удалена
|RoomEntered     | 10                | Вход в комнату
|LeaveRoom       | 11                | Выход из комнаты
|Win             | 12                | Победа(игра окончена)



### Пример запроса на api/v1/room/create

__Запрос:__
```
{
    "login": "test1",
    "team": "X",
    "firstTurnTeam": "X"
}
```
__Ответ от сервера:__
```
{
    "responseCode": 8,
    "message": "Room has been created",
    "body": {
        "creator": "test1",
        "currentTurnTeam": "X",
        "roomCode": "50866-100",
        "winner": null,
        "playersInRoom": {
            "X": "test1",
            "O": ""
        },
        "gameArea": {
            "1": "",
            "2": "",
            "3": "",
            "4": "",
            "5": "",
            "6": "",
            "7": "",
            "8": "",
            "9": ""
        }
    }
}
```


### Postman

В файле проекта лежит готовый файл конфигирации __TicTacToe.postman_collection.json__
Используйте его, чтобы наглядно увидеть входные и выходные данные при работе с данным API.
