-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 01 2024 г., 22:58
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
  `Number` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Frozen` tinyint(1) NOT NULL,
  `Balance` float NOT NULL,
  `Card_number` varchar(19) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `bill_owner` int UNSIGNED NOT NULL,
  PRIMARY KEY (`Number`),
  KEY `bill_owner` (`bill_owner`),
  KEY `Card_number` (`Card_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `bill`
--

INSERT INTO `bill` (`Number`, `Frozen`, `Balance`, `Card_number`, `bill_owner`) VALUES
('31063587124772876927', 0, 5574, NULL, 18),
('59864871948951720427', 0, 9100, '1739 1564 1434 7057', 24),
('86751043112319142340', 0, 5326, NULL, 18);

-- --------------------------------------------------------

--
-- Структура таблицы `card`
--

DROP TABLE IF EXISTS `card`;
CREATE TABLE IF NOT EXISTS `card` (
  `Number` varchar(19) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `CVV` smallint UNSIGNED NOT NULL,
  `Validity` varchar(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `card`
--

INSERT INTO `card` (`Number`, `CVV`, `Validity`) VALUES
('1739 1564 1434 7057', 354, '3/2024'),
('4808 7327 6366 4416', 540, '2/2024'),
('4937 3071 1490 1765', 173, '2/2024'),
('8787 7702 8585 9878', 883, '2/2024');

-- --------------------------------------------------------

--
-- Структура таблицы `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
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
  `Status` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Status` (`Status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `status_transfer`
--

INSERT INTO `status_transfer` (`id`, `Status`) VALUES
(1, 'Выполнен'),
(2, 'Отменен'),
(3, 'Отправлен');

-- --------------------------------------------------------

--
-- Структура таблицы `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE IF NOT EXISTS `transaction` (
  `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `Type_transfer` tinyint(1) NOT NULL,
  `transfer_recipient` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `transfer_sender` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `status_id` tinyint(1) NOT NULL,
  `amount` float UNSIGNED NOT NULL,
  `Date` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Type_transfer` (`Type_transfer`,`transfer_recipient`,`transfer_sender`,`status_id`),
  KEY `status_id` (`status_id`),
  KEY `transfer_sender` (`transfer_sender`),
  KEY `transfer_recipient` (`transfer_recipient`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `transaction`
--

INSERT INTO `transaction` (`id`, `Type_transfer`, `transfer_recipient`, `transfer_sender`, `status_id`, `amount`, `Date`) VALUES
(2, 2, '86751043112319142340', '31063587124772876927', 1, 1, '2024-03-01 22:49:35');

--
-- Триггеры `transaction`
--
DROP TRIGGER IF EXISTS `update_trigger_transaction`;
DELIMITER $$
CREATE TRIGGER `update_trigger_transaction` AFTER INSERT ON `transaction` FOR EACH ROW BEGIN
UPDATE bill
SET `Balance` = `Balance` + NEW.amount WHERE Number = NEW.transfer_recipient AND (NEW.Type_transfer = 1 OR NEW.Type_transfer = 2);
UPDATE bill
SET `Balance` = `Balance` - NEW.amount WHERE Number = NEW.transfer_sender AND (NEW.Type_transfer = 1 OR NEW.Type_transfer = 2);
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `type_transfer`
--

DROP TABLE IF EXISTS `type_transfer`;
CREATE TABLE IF NOT EXISTS `type_transfer` (
  `id` tinyint(1) NOT NULL,
  `Type` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
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
  `surname_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `patronymic_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `login_user` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_user` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Role_id` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Role_id` (`Role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
(17, 'wefwerg', 'qwewfe', 'wergwerfgewr', 'qweqwe', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'v@gm.co'),
(18, 'qweqwe', 'qweqwe', 'qweqwe', 'qwerty', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'ja@co.com'),
(19, 'ввв', 'Пупкин', 'вв', 'тест', 'qVC/36e7ZNnA6MUR09BwFqHLSazU29Mj2bwOnrUh2ZE=', '1', 'a@tu.ru'),
(20, 'qqerqw', 'qwr', 'qwr', 'qwerty12', '9wykuAfIGX+mZn9WzSadRAxWvlVcL33DjQVkt3PS5EU=', '1', '123@123.com'),
(21, 'ef', 'wef', '', 'qwerty1231212', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'vjd@gs.co'),
(22, 'qwfe', 'qw', '', 'qwerty123', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'va@co.co'),
(23, 'qw', 'qwerty', '', 'qwerty4', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'va@v.co'),
(24, 'aboba', 'abobav', '', '1', 'lY/rXGksRbThh+WeLl3ROrw56B+YjP9peQxkBLrAt08=', '1', 'va1@co.co');

-- --------------------------------------------------------

--
-- Структура таблицы `v_role`
--

DROP TABLE IF EXISTS `v_role`;
CREATE TABLE IF NOT EXISTS `v_role` (
  `id` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `name_role` varchar(13) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Дублирующая структура для представления `v_transaction`
-- (См. Ниже фактическое представление)
--
DROP VIEW IF EXISTS `v_transaction`;
CREATE TABLE IF NOT EXISTS `v_transaction` (
`amount` float unsigned
,`Date` datetime
,`id` bigint unsigned
,`recipient_id` int unsigned
,`recipient_name` varchar(92)
,`sender_id` int unsigned
,`sender_name` varchar(92)
,`Status` varchar(20)
,`transfer_recipient` varchar(20)
,`transfer_sender` varchar(20)
,`Type` varchar(20)
);

-- --------------------------------------------------------

--
-- Структура для представления `v_transaction`
--
DROP TABLE IF EXISTS `v_transaction`;

DROP VIEW IF EXISTS `v_transaction`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_transaction`  AS SELECT `tranz`.`id` AS `id`, `u1`.`id` AS `recipient_id`, `u2`.`id` AS `sender_id`, `tranz`.`amount` AS `amount`, `type_transfer`.`Type` AS `Type`, `tranz`.`transfer_recipient` AS `transfer_recipient`, `tranz`.`transfer_sender` AS `transfer_sender`, `st`.`Status` AS `Status`, concat(`u1`.`surname_user`,' ',`u1`.`name_user`,' ',`u1`.`patronymic_user`) AS `recipient_name`, concat(`u2`.`surname_user`,' ',`u2`.`name_user`,' ',`u2`.`patronymic_user`) AS `sender_name`, `tranz`.`Date` AS `Date` FROM ((((((`transaction` `tranz` join `type_transfer` on((`tranz`.`Type_transfer` = `type_transfer`.`id`))) join `status_transfer` `st` on((`tranz`.`status_id` = `st`.`id`))) join `bill` `b1` on((`b1`.`Number` = `tranz`.`transfer_recipient`))) join `bill` `b2` on((`b2`.`Number` = `tranz`.`transfer_sender`))) join `user` `u1` on((`u1`.`id` = `b1`.`bill_owner`))) join `user` `u2` on((`u2`.`id` = `b2`.`bill_owner`)))  ;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `bill_ibfk_2` FOREIGN KEY (`bill_owner`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bill_ibfk_3` FOREIGN KEY (`Card_number`) REFERENCES `card` (`Number`) ON DELETE CASCADE ON UPDATE CASCADE;

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
