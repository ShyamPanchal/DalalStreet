-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.6.20 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             10.1.0.5464
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for dalal_street_db
CREATE DATABASE IF NOT EXISTS `dalal_street_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `dalal_street_db`;

-- Dumping structure for table dalal_street_db.ds_company
CREATE TABLE IF NOT EXISTS `ds_company` (
  `company_id` int(11) NOT NULL AUTO_INCREMENT,
  `company_name` varchar(50) NOT NULL,
  `category` varchar(50) NOT NULL,
  `stock_price` decimal(19,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Dumping data for table dalal_street_db.ds_company: ~4 rows (approximately)
/*!40000 ALTER TABLE `ds_company` DISABLE KEYS */;
INSERT INTO `ds_company` (`company_id`, `company_name`, `category`, `stock_price`) VALUES
	(1, 'Samsung', 'Technology', 10.00),
	(2, 'Apple', 'Technology', 15.00),
	(3, 'KFC', 'Food', 5.00),
	(4, 'Popeyes', 'Food', 10.00);
/*!40000 ALTER TABLE `ds_company` ENABLE KEYS */;

-- Dumping structure for table dalal_street_db.ds_news_event
CREATE TABLE IF NOT EXISTS `ds_news_event` (
  `news_event_id` int(11) NOT NULL AUTO_INCREMENT,
  `company_id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `type` int(11) NOT NULL,
  PRIMARY KEY (`news_event_id`),
  KEY `news_event_company_id_fk` (`company_id`),
  CONSTRAINT `news_event_company_id_fk` FOREIGN KEY (`company_id`) REFERENCES `ds_company` (`company_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Dumping data for table dalal_street_db.ds_news_event: ~1 rows (approximately)
/*!40000 ALTER TABLE `ds_news_event` DISABLE KEYS */;
INSERT INTO `ds_news_event` (`news_event_id`, `company_id`, `description`, `type`) VALUES
	(1, 1, 'Launched a new product', 1),
	(2, 4, 'Problem found in one of its products', 0);
/*!40000 ALTER TABLE `ds_news_event` ENABLE KEYS */;

-- Dumping structure for table dalal_street_db.ds_player
CREATE TABLE IF NOT EXISTS `ds_player` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `wallet` decimal(19,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table dalal_street_db.ds_player: ~0 rows (approximately)
/*!40000 ALTER TABLE `ds_player` DISABLE KEYS */;
/*!40000 ALTER TABLE `ds_player` ENABLE KEYS */;

-- Dumping structure for table dalal_street_db.ds_possible_event
CREATE TABLE IF NOT EXISTS `ds_possible_event` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `event_name` varchar(50) NOT NULL,
  `event_description` varchar(255) NOT NULL,
  PRIMARY KEY (`event_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table dalal_street_db.ds_possible_event: ~0 rows (approximately)
/*!40000 ALTER TABLE `ds_possible_event` DISABLE KEYS */;
/*!40000 ALTER TABLE `ds_possible_event` ENABLE KEYS */;

-- Dumping structure for table dalal_street_db.ds_stock_purchase
CREATE TABLE IF NOT EXISTS `ds_stock_purchase` (
  `stock_purchase_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `company_id` int(11) NOT NULL,
  `amount` decimal(19,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`stock_purchase_id`),
  KEY `stock_purchase_company_id_fk` (`company_id`),
  KEY `stock_purchase_user_id_fk` (`user_id`),
  CONSTRAINT `stock_purchase_company_id_fk` FOREIGN KEY (`company_id`) REFERENCES `ds_company` (`company_id`) ON UPDATE CASCADE,
  CONSTRAINT `stock_purchase_user_id_fk` FOREIGN KEY (`user_id`) REFERENCES `ds_player` (`user_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table dalal_street_db.ds_stock_purchase: ~0 rows (approximately)
/*!40000 ALTER TABLE `ds_stock_purchase` DISABLE KEYS */;
/*!40000 ALTER TABLE `ds_stock_purchase` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
