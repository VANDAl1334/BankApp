-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 01 2023 г., 22:50
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
-- База данных: `bank`
--

-- --------------------------------------------------------

--
-- Структура таблицы `bill`
--

DROP TABLE IF EXISTS `bill`;
CREATE TABLE IF NOT EXISTS `bill` (
  `Number` int NOT NULL AUTO_INCREMENT,
  `Forzen` tinyint(1) NOT NULL,
  `Balance` float NOT NULL,
  `Card_number` int UNSIGNED NOT NULL,
  `bill_owner` int UNSIGNED NOT NULL,
  PRIMARY KEY (`Number`),
  KEY `bill_owner` (`bill_owner`),
  KEY `Card_number` (`Card_number`)
) ENGINE=InnoDB AUTO_INCREMENT=10000000000 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `card`
--

DROP TABLE IF EXISTS `card`;
CREATE TABLE IF NOT EXISTS `card` (
  `Number` int UNSIGNED NOT NULL,
  `CVV` int UNSIGNED NOT NULL,
  `Validity` int UNSIGNED NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id` tinyint UNSIGNED NOT NULL,
  `role_user` varchar(13) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `status_transfer`
--

DROP TABLE IF EXISTS `status_transfer`;
CREATE TABLE IF NOT EXISTS `status_transfer` (
  `id` tinyint(1) NOT NULL,
  `Status` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Status` (`Status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE IF NOT EXISTS `transaction` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Type_transfer` tinyint(1) NOT NULL,
  `transfer_recipient` int NOT NULL,
  `transfer_sender` int NOT NULL,
  `status_id` tinyint(1) NOT NULL,
  `amount` float UNSIGNED NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Type_transfer` (`Type_transfer`,`transfer_recipient`,`transfer_sender`,`status_id`),
  KEY `status_id` (`status_id`),
  KEY `transfer_my` (`transfer_recipient`),
  KEY `transfer_your` (`transfer_sender`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `type_transfer`
--

DROP TABLE IF EXISTS `type_transfer`;
CREATE TABLE IF NOT EXISTS `type_transfer` (
  `id` tinyint(1) NOT NULL,
  `Type` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Type` (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `login_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_user` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Role_id` tinyint UNSIGNED NOT NULL,
  `Phone` int UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Role_id` (`Role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `bill_ibfk_1` FOREIGN KEY (`Card_number`) REFERENCES `card` (`Number`),
  ADD CONSTRAINT `bill_ibfk_2` FOREIGN KEY (`bill_owner`) REFERENCES `user` (`id`);

--
-- Ограничения внешнего ключа таблицы `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`status_id`) REFERENCES `status_transfer` (`id`),
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`transfer_recipient`) REFERENCES `bill` (`Number`),
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`transfer_sender`) REFERENCES `bill` (`Number`);

--
-- Ограничения внешнего ключа таблицы `type_transfer`
--
ALTER TABLE `type_transfer`
  ADD CONSTRAINT `type_transfer_ibfk_1` FOREIGN KEY (`id`) REFERENCES `transaction` (`Type_transfer`);

--
-- Ограничения внешнего ключа таблицы `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `fk_Role_id` FOREIGN KEY (`Role_id`) REFERENCES `role` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
