-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 26 2024 г., 19:45
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
  `Number` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `Frozen` varchar(1) COLLATE utf8mb4_general_ci NOT NULL,
  `Balance` float NOT NULL,
  `Card_number` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `bill_owner` int UNSIGNED NOT NULL,
  PRIMARY KEY (`Number`),
  KEY `bill_owner` (`bill_owner`),
  KEY `Card_number` (`Card_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `bill`
--

INSERT INTO `bill` (`Number`, `Frozen`, `Balance`, `Card_number`, `bill_owner`) VALUES
('10022840951914971083', '0', 500, NULL, 16),
('15693621506289198497', '0', 0, NULL, 16),
('15805134954767937447', '0', 0, NULL, 16),
('16831247747629799340', '0', 0, NULL, 16),
('21238976505654478197', '0', 0, NULL, 16),
('26293433432092643405', '0', 0, NULL, 16),
('26329330833102636652', '0', 0, NULL, 16),
('2861404514986843137', '0', 0, NULL, 16),
('3979419555337303955', '0', 0, NULL, 16),
('4295844136395648336', '0', 0, NULL, 16),
('5218372617602512511', '0', 0, NULL, 16),
('53589887917358434729', '0', 0, NULL, 16),
('55831734924512126996', '0', 0, NULL, 16),
('63095824818582130128', '0', 0, NULL, 16),
('6486657841495595054', '0', 0, NULL, 16),
('73008428559381488816', '0', 0, NULL, 16),
('7921711053409321920', '0', 0, NULL, 16),
('85851979546488656568', '0', 0, NULL, 16),
('85918393422995267114', '0', 0, NULL, 16),
('87873917538062913963', '0', 0, NULL, 16),
('93665789626419327952', '0', 0, NULL, 16),
('94698654665703841998', '0', 0, NULL, 16),
('9540563377297992424', '0', 0, NULL, 16);

-- --------------------------------------------------------

--
-- Структура таблицы `card`
--

DROP TABLE IF EXISTS `card`;
CREATE TABLE IF NOT EXISTS `card` (
  `Number` varchar(16) COLLATE utf8mb4_general_ci NOT NULL,
  `CVV` int UNSIGNED NOT NULL,
  `Validity` varchar(5) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id` varchar(1) COLLATE utf8mb4_general_ci NOT NULL,
  `name_role` varchar(13) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `role`
--

INSERT INTO `role` (`id`, `name_role`) VALUES
('1', 'Клиент'),
('2', 'Менеджер'),
('3', 'Администратор');

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
  `transfer_recipient` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `transfer_sender` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `status_id` tinyint(1) NOT NULL,
  `amount` float UNSIGNED NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Type_transfer` (`Type_transfer`,`transfer_recipient`,`transfer_sender`,`status_id`),
  KEY `status_id` (`status_id`),
  KEY `transfer_sender` (`transfer_sender`),
  KEY `transfer_recipient` (`transfer_recipient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `type_transfer`
--

DROP TABLE IF EXISTS `type_transfer`;
CREATE TABLE IF NOT EXISTS `type_transfer` (
  `id` tinyint(1) NOT NULL,
  `Type` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `type_transfer`
--

INSERT INTO `type_transfer` (`id`, `Type`) VALUES
(1, 'Перевод'),
(2, 'Перевод между своими'),
(3, 'Снятие со счёта'),
(4, 'Пополнение');

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `surname_user` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `patronymic_user` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `login_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_user` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Role_id` varchar(1) COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Role_id` (`Role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `user`
--

INSERT INTO `user` (`id`, `name_user`, `surname_user`, `patronymic_user`, `login_user`, `password_user`, `Role_id`, `Email`) VALUES
(9, 'Данил', 'Шестопалов', 'Гелаевич', 'sral1', 'k/xmyJcKBBSjEwNeBb1bhfbLiQ4Er9UHuwk5oXAuZrs=', '1', 'vanda9gmai;.cpom'),
(10, 'Бэбранил', 'Шестопалов', 'Пендосович', 'danil', 'lUTuIkn5sQOfiY5pj0lwrmwVOxNhIg0zgLLVnfLQwXw=', '1', 'qwerty@gmail.com'),
(11, 'щуиергзкптлц', 'ущрткпшлукп', 'щертшкьплвуп', 'nasral228', 'BQBwJSFewnQ0m1r2CZCTFvnjQIJ+L9W0+Ets2V1JK7M=', '1', 'fegjbneiorgj@gmail.com'),
(12, 'ewrqwrqwe', 'qwrqwrq', 'werqwrqwr', 'qwerty1', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'vandal231@gmail.com'),
(13, 'hetherth', 'ewfreyhrete', 'ethrwthert', 'gwerthrth', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'erhrenjg@#'),
(14, 'wthwrth', 'qwrhh', 'rtherthq', 'qqwrret', 'SBLydhVABemfpVP6oAC9kCKpoS2yPamN+HGGgoKLP9Q=', '1', 'qwerty@gmail.com'),
(15, 'qwe', 'efwqe', 'qwe', 'qwe', 'cQjqrMov0Q4jCOPcbrM/hfWr2b1slgGEYSS/znk9kRE=', '1', 'wqw'),
(16, 'Генацвали', 'Абубэба', 'Пюрэнович', 'ПажылаяПаста', 'aKUVCICVY8pE+hNpKr7Ol75vLy6eoHIhmUF9qSxVBB4=', '1', 'wamp@gmail.com'),
(17, 'wefwerg', 'qwewfe', 'wergwerfgewr', 'qweqwe', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'v@gm.co');

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `v_role`
-- (См. Ниже фактическое представление)
--
DROP VIEW IF EXISTS `v_role`;
CREATE TABLE IF NOT EXISTS `v_role` (
`id` varchar(1)
,`name_role` varchar(13)
);

-- --------------------------------------------------------

--
-- Структура для представления `v_role`
--
DROP TABLE IF EXISTS `v_role`;

DROP VIEW IF EXISTS `v_role`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_role`  AS SELECT `name_role`.`id` AS `id`, `name_role`.`name_role` AS `name_role` FROM `role` AS `name_role``name_role`  ;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `bill_ibfk_2` FOREIGN KEY (`bill_owner`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bill_ibfk_3` FOREIGN KEY (`Card_number`) REFERENCES `card` (`Number`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`status_id`) REFERENCES `status_transfer` (`id`),
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`Type_transfer`) REFERENCES `type_transfer` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_4` FOREIGN KEY (`transfer_sender`) REFERENCES `bill` (`Number`) ON UPDATE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_5` FOREIGN KEY (`transfer_recipient`) REFERENCES `bill` (`Number`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`Role_id`) REFERENCES `role` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
