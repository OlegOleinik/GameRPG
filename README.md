# test
(ДЕВ-ВЕРСИЯ) 24.02.22 Попытка добавить заклинания. Лазер пока что нормально не работает, второе не прописал

(ДЕВ-ВЕРСИЯ) 20.02.22 Продолжение работы над системой характеристик, улучшение всех характеристик (статы меняются, но не все влияют на игру), нормальное открытие панелей (инвентарь/характеристики), спринт и выносливость, панель магии (меняется кликом, кнопками 1-9, колесиком мыши), заготовка под заклинания

ОБНОВЛЕНО 09.02.22 Начал делать систему характеристик. Добавил шкалу здоровья и опыта игрока, получение урона игроком (смерти пока нет), получение опыта с противников, задержку перед повторным получением урона игроком

ОБНОВЛЕНО 03.02.22 Наконец-то загрузил все. Переписал инвентарь, теперь работает слайдер, оптимизировал. Чтобы выкинуть предмет, надо выбрать его в инвентаре нажатием, затем количество слайдером и нажать кнопку, но пока появляется независимо от взляда. С противника падает одна вещь. Стартовая сцена-StartMenu, с других нормально не запустится, работает новая игра и выход (в собранном проекте), загрузка пока нет. Также переписал меч на Coroutine, добавил каркас для возможности серий ударов. Магии теперь нет (пока что)

16.01.22 ~~(Не загружено)~~ Прописал ИИ противника. Противник перемещается вокруг точки спавна в определенном радиусе, иногда останавливаясь. Если замечает игрока, начинает проеследовать, если игрок пропал из виду-до последней точки, где был замечен игрок, если отходит слишком далеко - возвращается на точку спавна. Противник видит игрока в определенном радиусе вокруг себя, но не видит сквозь стены. Если сталкивается со стеной, меняет направление.


09.01.22 ~~(Не загружено)~~
Чтобы не казалось, что я ничем не занят, напишу сюда что-нибудь. Сделал возможность бесшовного мира. Т.е. куски мира прогружаются вслед за передвижением игрока, что позволит делать большой мир без сильной нагрузки на систему. При отдалении части мира пропадают. Это происходит вне поля зрения, т.е. игроку не видно. Для добавления новой части мира достаточно добавить сцену, после чего все должно работать автоматически. Сделал именно так для простоты дальнейшего расширения мира и добавления новых локаций. Сделал главное меню. Сократил некоторые части кода.
!!НАКОНЕЦ ИСПРАВИЛ ТОТ БАГ С ФИЗИКОЙ ПРИ ОТТАЛКИВАНИИ В ВОДУ!!


ОБНОВЛЕНО 17.12.21
Добавлена возможность выкидывать предметы из инвентаря. Предметы появляются на некотором расстоянии от игрока по оси x в зависимости от направления взгляда игрока. Также есть небольшой разброс, чтобы предметы появлялись не в одной точке. Слайдер для выбора количества не работает. Предметы выкидываются по 1, после выкидывания 1 предмета, фокус с ячейки пропадает. Чтобы выкинуть предмет, надо выбрать ячейку ЛКМ и нажать кнопу Drop Item, после чего 1 предмет пропадет из инвентаря, а в мире появится соответствующий.


ОБНОВЛЕНО 14.12.21
Показывает описание предмета при наведении курсора



ПЕРВАЯ ВЕРСИЯ:
В данный момент:
Игрок двигается (WASD). Машет мечем (ЛКМ). Пытается в магию (ПКМ). Открывается инвентарь (I или кнопка на экране). Противники отталкиваются при ударе мечем в сторону по линии игрок-враг. Удар мечем наносит 1 урона, у противников 3 ХП, при снижении меняется цвет. При смерти противника респавнится через несколько секунд в месте изначального спавна. Дропает предметы-2, вероятность 50% для каждого (т.е. может выпасть 1, 2 разных или ни одного)(При дропе 2 одновременно одного не видно из-за схожих текстур). При попадании (столкновении) противника и игрока, игрока отталкивает. Игрок не умирает. Вода замедляет (как игрока, так и противников). Стены не дают пройти.
ИИ противников: двигаются к координатам игрока, независимо от расстояния и препятствий.




~~Необходимо переписать метод паузы игры (разбить на 2). Сейчас 1 и меняет состояние, работает, но в консоли ошибки, при добавлении других кнопок, останавливающих игру, работать перестанет.~~
Переписать игрока под систему состояний (state machine). В данный момент планируются следующие состояния: 1) Норма 2) Оглушен 3) Атакует (заблокировать смену взгляда игрока, но оставить возможность ходить) 4)(Возможно) Идет СКОРЕЕ ВСЕГО НЕ НУЖНО
~~Привязать первичный спавн противников к методу респавна~~ (Не нужно)
~~..Сделать что-то с физикой при изменении среды во время действия физики~~....ЧЕК!
Изменить способ движения игрока на физику, вместо смены координат
Убрать взмах мечем при нажатии кнопок
Изменить систему дропа (сейчас-дроп всех предметов с шансом для каждого 50%, количестве 1, на месте смерти противника. Стоит сделать вероятность для каждого, возможное количество одинаковых (самый простой вариант-дублировать в списке возможного дропа) и небольшое отклонение от точки)...частично сделано
Изменить код инвентаря так, чтобы можно было менять число ячеек без смены кода
~~?Изменить метод взмаха мечем на рекурсию?~~сделано Coroutine
?Добавить переменную, чтобы у разных мечей была разная скорость?



ВОЗМОЖНО, изменить систему дропа на обыск. Предметы не появляются на карте, а появляются в сумке/останках на месте смерти противника. Игрок может увидеть список и взять, что хочет


Планируется сделать в примерно следующем порядке
~~1.	Дописать инвентарь. Отображение описания предметов (чек), выбрасывание предметов (чек). Полностью проверить работоспособность (Возможно добавть шкалу для выбора кол-ва предметов дропа/продажи)~~ чек
2.	Система способностей
3.	Формулы, зависящие от способностей
4.	Зелья лечения/еда
  4.1 Соответственно, возможность использовать предметы
5.	Магазин с покупкой/продажей вещей
  5.1 Система денег
6.	Смерть игрока и возможность проигрыша
7.	Разное оружие и его влияние на характеристики
  7.1 Как и пункт 4.1, возможность менять оружие, отображение текущего и т.д.
  7.2 Показывать текущие характеристики в окне инвентаря
8.	~~Поле зрения~~(ЧЕК) ~~и направление противников ~~(не нужно)
9.	~~Улучшить ИИ в принципе ~~(чек)
10.	Возможно, система уровней для противников. Пока сомневаюсь, что она вообще нужна
11.	Меню (чек), сохранение
12.	Сложный режим (удаление сохранений при проигрыше)
13.	Где-то тут добавить звуки
14.	Изменение внешнего вида игрока
