BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Ordering" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Client_ID"	INTEGER NOT NULL,
	"Book_ID"	INTEGER NOT NULL,
	"Count"	INTEGER NOT NULL,
	"Date"	NUMERIC NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("Book_ID") REFERENCES "Book"("ID") ON UPDATE CASCADE,
	FOREIGN KEY("Client_ID") REFERENCES "Client"("ID") ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "Book" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Author_ID"	INTEGER NOT NULL,
	"Publisher_ID"	INTEGER NOT NULL,
	"Genre_ID"	INTEGER NOT NULL,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 100),
	"Cost"	INTEGER NOT NULL,
	"Quantity"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("Genre_ID") REFERENCES "Genre"("ID") ON UPDATE CASCADE,
	FOREIGN KEY("Publisher_ID") REFERENCES "Publisher"("ID") ON UPDATE CASCADE,
	FOREIGN KEY("Author_ID") REFERENCES "Author"("ID")
);
CREATE TABLE IF NOT EXISTS "Author" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SurName"	TEXT NOT NULL CHECK(LENGTH("SurName") < 100),
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 75),
	"SecondName"	TEXT CHECK(LENGTH("SecondName") < 103),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Client" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SurName"	TEXT NOT NULL CHECK(LENGTH("SurName") < 100),
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 75),
	"SecondName"	TEXT CHECK(LENGTH("SecondName") < 103),
	"Sex"	TEXT NOT NULL CHECK(LENGTH("Sex") < 10),
	"DateOfBirth"	NUMERIC NOT NULL,
	"Discount_ID"	INTEGER,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("Discount_ID") REFERENCES "Discount"("ID") ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "Discount" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50),
	"Value"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Employee" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SurName"	TEXT NOT NULL CHECK(LENGTH("SurName") < 100),
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 75),
	"SecondName"	TEXT CHECK(LENGTH("SecondName") < 103),
	"Sex"	TEXT NOT NULL CHECK(LENGTH("Sex") < 10),
	"DateOfBirth"	NUMERIC NOT NULL,
	"Experience"	INTEGER NOT NULL,
	"Post_ID"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("Post_ID") REFERENCES "Post"("ID") ON UPDATE CASCADE
);
CREATE TABLE IF NOT EXISTS "Genre" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50) UNIQUE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Post" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50),
	"Salary"	INTEGER NOT NULL,
	"WorkSchedule"	TEXT NOT NULL CHECK(LENGTH("WorkSchedule") < 50),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Publisher" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 100) UNIQUE,
	PRIMARY KEY("ID")
);
INSERT INTO "Book" ("ID","Author_ID","Publisher_ID","Genre_ID","Title","Cost","Quantity") VALUES (1,8,6,2,'Евангелион',1099,35),
 (2,7,6,11,'Дневник будущего',799,50),
 (3,9,1,11,'Адский рай',899,39),
 (4,10,1,8,'Звёздное дитя',999,38),
 (5,10,1,6,'Госпожа Кагуя: В любви как на войне',999,24),
 (6,11,1,12,'Токийский гуль',1299,47);
INSERT INTO "Author" ("ID","SurName","Name","SecondName") VALUES (1,'Хирохико','Араки',NULL),
 (2,'Масаси','Кисимото',NULL),
 (3,'Кэнтаро','Миура',NULL),
 (4,'Кацухиро','Отомо',NULL),
 (5,'Макото','Синкай',NULL),
 (6,'Хирому','Аракава',NULL),
 (7,'Сакаэ','Эсуно',NULL),
 (8,'Ёсиюки','Садомото',NULL),
 (9,'Юдзи','Каку',NULL),
 (10,'Ака','Акасака',NULL),
 (11,'Суи','Ишида',NULL);
INSERT INTO "Client" ("ID","SurName","Name","SecondName","Sex","DateOfBirth","Discount_ID") VALUES (1,'Орлов','Николай','Арсеньевич','Мужской','13.01.1994',NULL),
 (2,'Макаров','Леонид','Михайлович','Мужской','24.07.2001',NULL),
 (3,'Горбачёв','Дмитрий','Степанович','Мужской','30.11.1987',NULL),
 (4,'Матвеева','Евгения','Анатольевна','Женский','04.09.2003',NULL),
 (5,'Субботина','Алина','Григорьевна','Женский','14.03.2004',NULL),
 (6,'Мельников','Никита','Сергеевич','Мужской','18.03.2005',NULL),
 (7,'Доброниченко','Григорий','Алексеевич','Мужской','09.10.2003',NULL),
 (8,'Косарев','Александр','Александрович','Мужской','03.06.2005',NULL),
 (9,'Осокин','Бесперебойник',NULL,'Мужской','05.10.2021',NULL),
 (10,'Папич','Володя','Врайзкингович','Мужской','05.04.1992',NULL),
 (11,'Владимирова','Оксана','Александровна','Женский','02.01.2005',NULL),
 (12,'Тиньков','Олег','Юрьевич','Мужской','25.12.1967',NULL),
 (13,'Баринова','Екатерина','Шефовна','Женский','17.08.1996',NULL),
 (14,'Могилёва','Елена','Павловна','Женский','23.09.1985',NULL),
 (15,'Моисеенко','Наталья','Александровна','Женский','26.12.1988',NULL),
 (16,'Кукушкин','Егор','Игоревич','Мужской','01.02.2005',NULL);
INSERT INTO "Discount" ("ID","Title","Value") VALUES (1,'Новый года',20);
INSERT INTO "Employee" ("ID","SurName","Name","SecondName","Sex","DateOfBirth","Experience","Post_ID") VALUES (1,'Таджик','Узбек','Махмудень','Мужской','19.07.1994',4,4),
 (2,'Магомедов','Шамиль',NULL,'Мужской','25.12.1991',23,4),
 (3,'Гофра','Ахмед','Бабайкович','Мужской','08.08.1999',14,4),
 (4,'Насриддинов','Рустам','Магомедович','Мужской','01.05.2000',6,4),
 (5,'Фахрудинов','Азамат',NULL,'Мужской','14.09.1997',9,4),
 (6,'Измайлов','Александр','Болтаевич','Мужской','11.01.1963',2,2),
 (7,'Нафиг','Виктор','Сергеевич','Мужской','22.11.2003',3,1),
 (8,'Глотаева','Виктория','Борисовна','Женский','06.08.2002',4,1);
INSERT INTO "Genre" ("ID","Title") VALUES (1,'Сёнен'),
 (2,'Меха'),
 (3,'Идолы'),
 (4,'Гарем'),
 (5,'Добуцу'),
 (6,'Комедия'),
 (7,'Боевик'),
 (8,'Драма'),
 (9,'Детектив'),
 (10,'Этти'),
 (11,'Психологический триллер'),
 (12,'Ужасы');
INSERT INTO "Post" ("ID","Title","Salary","WorkSchedule") VALUES (1,'Продавец-консультант',35000,'2/1'),
 (2,'Директор',65000,'5/2'),
 (3,'Охранник',18000,'7/0'),
 (4,'Работник склада','Еда','7/0');
INSERT INTO "Publisher" ("ID","Title") VALUES (1,'Shueisha'),
 (2,'Young Magazine'),
 (3,'Kodansha'),
 (4,'Nakayoshi'),
 (5,'Hakusensha'),
 (6,'Kadokawa Shoten');
COMMIT;
