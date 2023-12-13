BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Author" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SurName"	TEXT NOT NULL CHECK(LENGTH("SurName") < 100),
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 75),
	"SecondName"	TEXT CHECK(LENGTH("SecondName") < 103),
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Discount" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50),
	"Value"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Genre" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 50) UNIQUE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Publisher" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 100) UNIQUE,
	PRIMARY KEY("ID")
);
CREATE TABLE IF NOT EXISTS "Role" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL CHECK(LENGTH("Name") < 100) UNIQUE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Book" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Author_ID"	NUMERIC NOT NULL,
	"Publisher_ID"	NUMERIC NOT NULL,
	"Genre_ID"	NUMERIC NOT NULL,
	"Title"	TEXT NOT NULL CHECK(LENGTH("Title") < 100),
	"Cost"	INTEGER NOT NULL,
	"Quantity"	INTEGER NOT NULL,
	FOREIGN KEY("Author_ID") REFERENCES "Author"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Genre_ID") REFERENCES "Genre"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("Publisher_ID") REFERENCES "Publisher"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Ordering" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"People_ID"	INTEGER NOT NULL,
	"Book_ID"	INTEGER NOT NULL,
	"Count"	INTEGER NOT NULL,
	"Date"	TEXT NOT NULL CHECK(LENGTH("Date") < 20),
	FOREIGN KEY("Book_ID") REFERENCES "Book"("ID") ON UPDATE CASCADE,
	FOREIGN KEY("People_ID") REFERENCES "People"("ID") ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "People" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"SecondName"	TEXT NOT NULL CHECK((LENGTH("SecondName") < 100)),
	"Name"	TEXT NOT NULL CHECK((LENGTH("Name") < 100)),
	"SurName"	BLOB CHECK((LENGTH("SurName") < 100)),
	"Sex"	BLOB NOT NULL CHECK((LENGTH("Sex") < 10)),
	"DateOfBirth"	TEXT NOT NULL CHECK((LENGTH("DateOfBirth") < 20)),
	"UserLogin"	TEXT CHECK((LENGTH("UserLogin") < 100)),
	FOREIGN KEY("UserLogin") REFERENCES "User"("Login") ON DELETE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "User" (
	"Login"	TEXT NOT NULL DEFAULT '(LENGTH("Login") < 100)' UNIQUE,
	"Password"	TEXT NOT NULL DEFAULT '(LENGTH("Password") < 100)',
	"Role_ID"	INTEGER NOT NULL,
	PRIMARY KEY("Login","Password")
);
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
INSERT INTO "Discount" ("ID","Title","Value") VALUES (1,'Новый года',20);
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
INSERT INTO "Publisher" ("ID","Title") VALUES (1,'Shueisha'),
 (2,'Young Magazine'),
 (3,'Kodansha'),
 (4,'Nakayoshi'),
 (5,'Hakusensha'),
 (6,'Kadokawa Shoten');
INSERT INTO "Role" ("ID","Name") VALUES (1,'Клиент'),
 (2,'Сотрудник'),
 (3,'Админ'),
 (4,'Гость');
INSERT INTO "Book" ("ID","Author_ID","Publisher_ID","Genre_ID","Title","Cost","Quantity") VALUES (1,8,6,2,'Евангелион',1099,35),
 (2,7,6,11,'Дневник будущего',799,50),
 (3,9,1,11,'Адский рай',899,39),
 (4,10,1,8,'Звёздное дитя',999,38),
 (5,10,1,6,'Госпожа Кагуя: В любви как на войне',999,24),
 (6,11,1,12,'Токийский гуль',1299,47);
INSERT INTO "Ordering" ("ID","People_ID","Book_ID","Count","Date") VALUES (1,5,5,1,'21.10.2022');
INSERT INTO "People" ("ID","SecondName","Name","SurName","Sex","DateOfBirth","UserLogin") VALUES (1,'Ковалёв','Артур','Владимирович','Мужской','26.05.2005','Mu3aHTp0n'),
 (2,'Журавлёв','Виктор','Дмитриевич','Мужской','22.11.2005','teploVictor'),
 (3,'Мельников','Никита','Сергеевич','Мужской','18.03.2005','Doki4an'),
 (4,'Румянцев','Антон','Александрович','Мужской','29.05.2005','Sullpe'),
 (5,'None','Singletone',NULL,'Мужской','31.08.2022','Singletone');
INSERT INTO "User" ("Login","Password","Role_ID") VALUES ('Doki4an','NiceMan',1),
 ('Mu3aHTp0n','abc_123456',3),
 ('Singletone','LifeIsPain',3),
 ('Sullpe','SocialPhobe',2),
 ('teploVictor','St3sNyashka',2);
COMMIT;
