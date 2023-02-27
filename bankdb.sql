-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 27 2023 г., 16:13
-- Версия сервера: 8.0.31
-- Версия PHP: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bankdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `bill`
--

DROP TABLE IF EXISTS `bill`;
CREATE TABLE IF NOT EXISTS `bill` (
  `Number` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Номер платёжного счёта',
  `Balance` float UNSIGNED NOT NULL COMMENT 'Баланс платёжного счёта',
  `OwnerID` int UNSIGNED NOT NULL COMMENT 'Владелец',
  `CardNumber` char(16) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Привязанная карта',
  `IsFrozen` tinyint(1) NOT NULL COMMENT 'Заморожен ли счет',
  PRIMARY KEY (`Number`),
  KEY `bill_OwnerID_FK` (`OwnerID`),
  KEY `CardNumber` (`CardNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица платёжного счёта';

--
-- Дамп данных таблицы `bill`
--

INSERT INTO `bill` (`Number`, `Balance`, `OwnerID`, `CardNumber`, `IsFrozen`) VALUES
('83908264019463784765', 3214, 1, '8475639487263849', 1),
('84763901452084629873', 8932, 2, '1728374678360872', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `card`
--

DROP TABLE IF EXISTS `card`;
CREATE TABLE IF NOT EXISTS `card` (
  `Number` char(16) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Номер карты',
  `CVC` int UNSIGNED NOT NULL COMMENT 'CVC-Код',
  `Date` date NOT NULL COMMENT 'Срок действия',
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица дебитовых карт';

--
-- Дамп данных таблицы `card`
--

INSERT INTO `card` (`Number`, `CVC`, `Date`) VALUES
('1728374678360872', 151, '2023-02-01'),
('8475639487263849', 146, '2023-03-01');

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `ID` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор роли',
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Наименование роли',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Role_Name_UK` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица-справочник ролей пользователей';

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`ID`, `Name`) VALUES
(1, 'Администратор'),
(3, 'Клиент'),
(2, 'Менеджер');

-- --------------------------------------------------------

--
-- Структура таблицы `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE IF NOT EXISTS `transaction` (
  `ID` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор транзакции',
  `TransactionTypeID` int NOT NULL COMMENT 'Тип транзакции',
  `BillToNumber` char(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Счёт получателя',
  `BillFromNumber` char(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Счёт отправителя',
  `StatusID` int NOT NULL COMMENT 'Статус',
  `Amount` float UNSIGNED NOT NULL COMMENT 'Сумма перевода',
  `Date` date NOT NULL COMMENT 'Дата перевода',
  PRIMARY KEY (`ID`),
  KEY `TransactionTypeID` (`TransactionTypeID`),
  KEY `StatusID` (`StatusID`),
  KEY `BillToNumber` (`BillToNumber`),
  KEY `BillFromNumber` (`BillFromNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `transaction`
--

INSERT INTO `transaction` (`ID`, `TransactionTypeID`, `BillToNumber`, `BillFromNumber`, `StatusID`, `Amount`, `Date`) VALUES
(1, 1, '84763901452084629873', '83908264019463784765', 1, 120, '2023-01-11'),
(2, 1, '84763901452084629873', '83908264019463784765', 1, 124, '2022-12-23');

-- --------------------------------------------------------

--
-- Структура таблицы `transactionstatus`
--

DROP TABLE IF EXISTS `transactionstatus`;
CREATE TABLE IF NOT EXISTS `transactionstatus` (
  `ID` int NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор статуса',
  `Name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `TransactionStatus_Name_UK` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица-справочник статусов транзакций';

--
-- Дамп данных таблицы `transactionstatus`
--

INSERT INTO `transactionstatus` (`ID`, `Name`) VALUES
(2, 'Ожидание перевода'),
(1, 'Перевод доставлен'),
(3, 'Перевод отклонён');

-- --------------------------------------------------------

--
-- Структура таблицы `transactiontype`
--

DROP TABLE IF EXISTS `transactiontype`;
CREATE TABLE IF NOT EXISTS `transactiontype` (
  `ID` int NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор типа',
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Наименование типа',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `TransactionType_Name_UK` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица-справочник типов транзакций';

--
-- Дамп данных таблицы `transactiontype`
--

INSERT INTO `transactiontype` (`ID`, `Name`) VALUES
(1, 'Перевод'),
(2, 'Перевод между своими'),
(3, 'Пополнение счёта'),
(4, 'Снятие средств');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `ID` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор пользователя',
  `FName` varchar(75) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Имя пользователя',
  `LName` varchar(75) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Фамилия пользователя',
  `MName` varchar(75) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Отчество пользователя',
  `Login` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Логин',
  `Password` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Пароль, хешированный функцией MD5',
  `Phone` int UNSIGNED DEFAULT NULL COMMENT 'Телефон пользователя',
  `RoleID` int UNSIGNED NOT NULL COMMENT 'Роль пользователя',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `User_Login_UK` (`Login`),
  UNIQUE KEY `User_Phone_UK` (`Phone`),
  KEY `User_RoleID_FK` (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Таблица пользователей';

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`ID`, `FName`, `LName`, `MName`, `Login`, `Password`, `Phone`, `RoleID`) VALUES
(1, 'Евгений', 'Прохоров', 'Павлович', 'Ev_Pav', '26fe0cdfe99bfa306e31733c4e2b17dc', NULL, 3),
(2, 'Екатерина', 'Лебедева', 'Никитична', 'Eka_Leb', '26fe0cdfe99bfa306e31733c4e2b17dc', 4294967295, 3),
(3, 'Антонио', 'Попов', 'Робертович', 'Anto_Pop', '202cb962ac59075b964b07152d234b70', NULL, 3);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `bill_ibfk_1` FOREIGN KEY (`CardNumber`) REFERENCES `card` (`Number`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `bill_OwnerID_FK` FOREIGN KEY (`OwnerID`) REFERENCES `user` (`ID`);

--
-- Ограничения внешнего ключа таблицы `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`TransactionTypeID`) REFERENCES `transactiontype` (`ID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`StatusID`) REFERENCES `transactionstatus` (`ID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`BillToNumber`) REFERENCES `bill` (`Number`) ON UPDATE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_4` FOREIGN KEY (`BillFromNumber`) REFERENCES `bill` (`Number`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `User_RoleID_FK` FOREIGN KEY (`RoleID`) REFERENCES `role` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
