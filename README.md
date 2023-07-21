# MTFTest
Техническое задание

Основное приложение:

UI (по возможности Knockout.js, если с этим трудности, то на усмотрение исполнителя, как
пример Vue.js / React.js)

Регистрация. Нужно заполнить: логин и пароль/повторить пароль (цель - создать юзера в БД).

После регистрации, отдаётся страничка в режиме редактирования, где нужно заполнить:

• ФИО, ИНН (валидация 10 или 12 символов);

• Паспортные данные, Телефон (маска ввода);

• Не редактируемая строка адреса (составляется из вводимых данных Город, Улица,
Дом);

• Должность (селект: Директор, Бухгалтер, Доверенное лицо).

Кнопка: Идентифицировать. По нажатию форма выводится из режима редактирования.

Вместо кнопки отображается статус-идентификатор:

• В процессе;

• Успешно;

• Ошибка.

Отправляется запрос в API-приложение. По возможности: использовать SignalR или вебсокеты, чтобы обновить состояния идентификатора без опрашивания API. Если с этим
трудности, то добавить кнопку с обновлением статуса

API:

Без UI (.Net 6 и выше, Entity Framework Core, PostgreSQL)

Ручка, которая принимает данные пользователя. Заглушка, имитирующая идентификацию. По
завершению - оповещение основного приложения.

Если с этим трудности, то ещё одна ручка, возвращающая статус обработки.

Заметка: больше интересуют архитектурные решения и выбранные подходы при
проектировании. Над UI не нужно сильно заморачиваться.
