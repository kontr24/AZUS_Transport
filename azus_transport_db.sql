-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: azus_transport_db
-- ------------------------------------------------------
-- Server version	5.5.62

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Temporary table structure for view `applicationagreedview`
--

DROP TABLE IF EXISTS `applicationagreedview`;
/*!50001 DROP VIEW IF EXISTS `applicationagreedview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `applicationagreedview` (
  `Id` tinyint NOT NULL,
  `Client` tinyint NOT NULL,
  `Email` tinyint NOT NULL,
  `Post` tinyint NOT NULL,
  `Division` tinyint NOT NULL,
  `Building` tinyint NOT NULL,
  `Room` tinyint NOT NULL,
  `Director` tinyint NOT NULL,
  `Economist` tinyint NOT NULL,
  `CPC` tinyint NOT NULL,
  `IntercityСity` tinyint NOT NULL,
  `PurposeUsingTransport` tinyint NOT NULL,
  `DaysWorkerOrWeekend` tinyint NOT NULL,
  `WorkPhone` tinyint NOT NULL,
  `MobilePhone` tinyint NOT NULL,
  `DateCreation` tinyint NOT NULL,
  `StartDate` tinyint NOT NULL,
  `EndDate` tinyint NOT NULL,
  `TypeCar` tinyint NOT NULL,
  `Model` tinyint NOT NULL,
  `RegisterSign` tinyint NOT NULL,
  `QuantityPassengers` tinyint NOT NULL,
  `CargoWeight` tinyint NOT NULL,
  `PlaceSubmission` tinyint NOT NULL,
  `Route` tinyint NOT NULL,
  `CommentClient` tinyint NOT NULL,
  `СommentDirector` tinyint NOT NULL,
  `СommentEconomist` tinyint NOT NULL,
  `СommentDepartment` tinyint NOT NULL,
  `СommentDispatcherNIIAR` tinyint NOT NULL,
  `СommentDispatcherATA` tinyint NOT NULL,
  `DirectorStatusDone` tinyint NOT NULL,
  `EconomistStatusDone` tinyint NOT NULL,
  `DepartmentStatusDone` tinyint NOT NULL,
  `DispatcherNIIAR_StatusDone` tinyint NOT NULL,
  `DispatcherATA_StatusDone` tinyint NOT NULL,
  `SelectionApplicationJoin` tinyint NOT NULL,
  `ApplicationJoin` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `applications`
--

DROP TABLE IF EXISTS `applications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applications` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `UserID` int(3) NOT NULL,
  `CPC` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IntercityСity` bit(3) DEFAULT NULL,
  `PurposeUsingTransport` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Days` bit(3) DEFAULT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `DateCreation` datetime NOT NULL,
  `TypeCarID` int(3) NOT NULL,
  `QuantityPassengers` int(3) NOT NULL,
  `CargoWeight` float NOT NULL,
  `CarID` int(3) NOT NULL,
  `PlaceSubmission` varchar(300) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Route` varchar(300) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CommentClient` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `СommentDirector` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `СommentEconomist` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `СommentDepartment` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `СommentDispatcherNIIAR` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `СommentDispatcherATA` varchar(500) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DirectorStatusDoneID` int(3) NOT NULL,
  `EconomistStatusDoneID` int(3) NOT NULL,
  `DepartmentStatusDoneID` int(3) NOT NULL,
  `DispatcherNIIAR_StatusDoneID` int(3) NOT NULL,
  `DispatcherATA_StatusDoneID` int(3) NOT NULL,
  `SelectionApplicationJoin` bit(3) DEFAULT NULL,
  `ApplicationJoin` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `CarID` (`CarID`),
  KEY `DepartmentStatusDoneID` (`DepartmentStatusDoneID`),
  KEY `DirectorStatusDoneID` (`DirectorStatusDoneID`),
  KEY `DispatcherATA_StatusDoneID` (`DispatcherATA_StatusDoneID`),
  KEY `DispatcherNIIAR_StatusDoneID` (`DispatcherNIIAR_StatusDoneID`),
  KEY `EconomistStatusDoneID` (`EconomistStatusDoneID`),
  KEY `TypeCarID` (`TypeCarID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `applications_ibfk_8` FOREIGN KEY (`UserID`) REFERENCES `users` (`Id`),
  CONSTRAINT `applications_ibfk_1` FOREIGN KEY (`CarID`) REFERENCES `cars` (`Id`),
  CONSTRAINT `applications_ibfk_2` FOREIGN KEY (`DepartmentStatusDoneID`) REFERENCES `statusesdone` (`Id`),
  CONSTRAINT `applications_ibfk_3` FOREIGN KEY (`DirectorStatusDoneID`) REFERENCES `statusesdone` (`Id`),
  CONSTRAINT `applications_ibfk_4` FOREIGN KEY (`DispatcherATA_StatusDoneID`) REFERENCES `statusesdone` (`Id`),
  CONSTRAINT `applications_ibfk_5` FOREIGN KEY (`DispatcherNIIAR_StatusDoneID`) REFERENCES `statusesdone` (`Id`),
  CONSTRAINT `applications_ibfk_6` FOREIGN KEY (`EconomistStatusDoneID`) REFERENCES `statusesdone` (`Id`),
  CONSTRAINT `applications_ibfk_7` FOREIGN KEY (`TypeCarID`) REFERENCES `typecars` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applications`
--

LOCK TABLES `applications` WRITE;
/*!40000 ALTER TABLE `applications` DISABLE KEYS */;
INSERT INTO `applications` VALUES (1,13,'NULL','\0',NULL,'\0','2022-04-20 19:35:38','2022-04-22 15:11:16','2022-04-25 18:36:57',1,1,0,1,'Соцгород','Соцгород - Химмаш','','','','','','',3,3,3,3,3,'\0','NULL');
/*!40000 ALTER TABLE `applications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `applicationview`
--

DROP TABLE IF EXISTS `applicationview`;
/*!50001 DROP VIEW IF EXISTS `applicationview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `applicationview` (
  `Id` tinyint NOT NULL,
  `Client` tinyint NOT NULL,
  `Email` tinyint NOT NULL,
  `Post` tinyint NOT NULL,
  `Division` tinyint NOT NULL,
  `Building` tinyint NOT NULL,
  `Room` tinyint NOT NULL,
  `Director` tinyint NOT NULL,
  `Economist` tinyint NOT NULL,
  `CPC` tinyint NOT NULL,
  `IntercityСity` tinyint NOT NULL,
  `PurposeUsingTransport` tinyint NOT NULL,
  `DaysWorkerOrWeekend` tinyint NOT NULL,
  `WorkPhone` tinyint NOT NULL,
  `MobilePhone` tinyint NOT NULL,
  `DateCreation` tinyint NOT NULL,
  `StartDate` tinyint NOT NULL,
  `EndDate` tinyint NOT NULL,
  `TypeCar` tinyint NOT NULL,
  `QuantityPassengers` tinyint NOT NULL,
  `CargoWeight` tinyint NOT NULL,
  `PlaceSubmission` tinyint NOT NULL,
  `Route` tinyint NOT NULL,
  `CommentClient` tinyint NOT NULL,
  `СommentDirector` tinyint NOT NULL,
  `СommentEconomist` tinyint NOT NULL,
  `СommentDepartment` tinyint NOT NULL,
  `СommentDispatcherNIIAR` tinyint NOT NULL,
  `СommentDispatcherATA` tinyint NOT NULL,
  `DirectorStatusDone` tinyint NOT NULL,
  `EconomistStatusDone` tinyint NOT NULL,
  `DepartmentStatusDone` tinyint NOT NULL,
  `DispatcherNIIAR_StatusDone` tinyint NOT NULL,
  `DispatcherATA_StatusDone` tinyint NOT NULL,
  `SelectionApplicationJoin` tinyint NOT NULL,
  `ApplicationJoin` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `carmodelview`
--

DROP TABLE IF EXISTS `carmodelview`;
/*!50001 DROP VIEW IF EXISTS `carmodelview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `carmodelview` (
  `Id` tinyint NOT NULL,
  `TypeCar` tinyint NOT NULL,
  `Model` tinyint NOT NULL,
  `RegisterSign` tinyint NOT NULL,
  `StatusCar` tinyint NOT NULL,
  `ImageData` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `cars`
--

DROP TABLE IF EXISTS `cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cars` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `TypeCarID` int(3) NOT NULL,
  `ModelCarID` int(3) NOT NULL,
  `RegisterSign` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `StatusCarID` int(11) NOT NULL,
  `ImageMimeType` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `ModelCarID` (`ModelCarID`),
  KEY `StatusCarID` (`StatusCarID`),
  KEY `TypeCarID` (`TypeCarID`),
  CONSTRAINT `cars_ibfk_1` FOREIGN KEY (`ModelCarID`) REFERENCES `modelcars` (`Id`),
  CONSTRAINT `cars_ibfk_2` FOREIGN KEY (`StatusCarID`) REFERENCES `statuscars` (`Id`),
  CONSTRAINT `cars_ibfk_3` FOREIGN KEY (`TypeCarID`) REFERENCES `typecars` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES (1,1,1,'—',1,'Audi_Q8.jpg'),(2,2,2,'C456МC 78 RUS',1,'Audi_TT.jpg');
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `carview`
--

DROP TABLE IF EXISTS `carview`;
/*!50001 DROP VIEW IF EXISTS `carview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `carview` (
  `Id` tinyint NOT NULL,
  `TypeCar` tinyint NOT NULL,
  `Model` tinyint NOT NULL,
  `RegisterSign` tinyint NOT NULL,
  `StatusCar` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `divisions`
--

DROP TABLE IF EXISTS `divisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `divisions` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Building` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Room` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `divisions`
--

LOCK TABLES `divisions` WRITE;
/*!40000 ALTER TABLE `divisions` DISABLE KEYS */;
INSERT INTO `divisions` VALUES (1,'Управление ГНЦ НИИАР','103','120'),(2,'АО \"Гринатом\"','102','213');
/*!40000 ALTER TABLE `divisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `divisionview`
--

DROP TABLE IF EXISTS `divisionview`;
/*!50001 DROP VIEW IF EXISTS `divisionview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `divisionview` (
  `Id` tinyint NOT NULL,
  `Division` tinyint NOT NULL,
  `Building` tinyint NOT NULL,
  `Room` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `modelcars`
--

DROP TABLE IF EXISTS `modelcars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modelcars` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modelcars`
--

LOCK TABLES `modelcars` WRITE;
/*!40000 ALTER TABLE `modelcars` DISABLE KEYS */;
INSERT INTO `modelcars` VALUES (1,'Audi Q8'),(2,'Audi TT'),(3,'BMW E46'),(4,'BMW E90');
/*!40000 ALTER TABLE `modelcars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `modelcarview`
--

DROP TABLE IF EXISTS `modelcarview`;
/*!50001 DROP VIEW IF EXISTS `modelcarview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `modelcarview` (
  `Id` tinyint NOT NULL,
  `Model` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `statuscars`
--

DROP TABLE IF EXISTS `statuscars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `statuscars` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuscars`
--

LOCK TABLES `statuscars` WRITE;
/*!40000 ALTER TABLE `statuscars` DISABLE KEYS */;
INSERT INTO `statuscars` VALUES (1,'Доступна'),(2,'Нет на месте');
/*!40000 ALTER TABLE `statuscars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuses`
--

DROP TABLE IF EXISTS `statuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `statuses` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuses`
--

LOCK TABLES `statuses` WRITE;
/*!40000 ALTER TABLE `statuses` DISABLE KEYS */;
INSERT INTO `statuses` VALUES (1,'Администратор'),(2,'Клиент'),(3,'Руководитель'),(4,'Экономист'),(5,'Диспетчер НИИАР'),(6,'ДИД'),(7,'Диспетчер АТА');
/*!40000 ALTER TABLE `statuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statusesdone`
--

DROP TABLE IF EXISTS `statusesdone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `statusesdone` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statusesdone`
--

LOCK TABLES `statusesdone` WRITE;
/*!40000 ALTER TABLE `statusesdone` DISABLE KEYS */;
INSERT INTO `statusesdone` VALUES (1,'Согласовано'),(2,'Отклонена'),(3,'На рассмотрении'),(4,'Исполнено'),(5,'Не исполнено');
/*!40000 ALTER TABLE `statusesdone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typecars`
--

DROP TABLE IF EXISTS `typecars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `typecars` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typecars`
--

LOCK TABLES `typecars` WRITE;
/*!40000 ALTER TABLE `typecars` DISABLE KEYS */;
INSERT INTO `typecars` VALUES (1,'Легковые автомобили и автобусы'),(2,'Грузовые автомобили');
/*!40000 ALTER TABLE `typecars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `typecarview`
--

DROP TABLE IF EXISTS `typecarview`;
/*!50001 DROP VIEW IF EXISTS `typecarview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `typecarview` (
  `Id` tinyint NOT NULL,
  `TypeCar` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` int(3) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SurName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Partonymic` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Post` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DivisionID` int(3) NOT NULL,
  `WorkPhone` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MobilePhone` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `StatusID` int(3) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `DivisionID` (`DivisionID`),
  KEY `StatusID` (`StatusID`),
  CONSTRAINT `users_ibfk_2` FOREIGN KEY (`StatusID`) REFERENCES `statuses` (`Id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`DivisionID`) REFERENCES `divisions` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (13,'sergey','sergey','seregeisysorov@mail.ru','Литвинцев','Виктор','Степанович','Главный специалист по технологическому оборудованию',1,'+7(309-45)3-52-44','+7(309)345-52-44',2),(14,'admin','admin','admin@yandex.ru','Астафьев','Иван','Иванович','Администратор',2,'+7(309-45)3-12-44','+7(309-45)3-12-44',1),(18,'director','director','a.pvrpva@mail.ru','Астафьев','Иван','Иванович','Директор',1,'+7(309-45)3-36-44','',3),(22,'economist','economist','a.pvrpva@mail.ru','Васюткин','Пётр','Петрович','Экономист',1,'+7(309-45)3-30-44','+7(309-45)3-12-23',4),(25,'dispatcherNIIAR','dispatcherNIIAR','a.pvrpva@mail.ru','Сидоров','Семён',' Петрович','Диспетчер НИИАР',1,'+7(309-32)3-52-44','',5),(32,'department','department','seregeisysorov@mail.ru','Казанцев','Игорь','Петрович','Главный департамента',1,'+7(312-32)3-52-44','',6),(34,'dispatcherATA','dispatcherATA','a.pvrpva@mail.ru','Истомин','Василий','Григорьевич','Диспетчер АТА',1,'+7(312-37)3-52-48','',7);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `userview`
--

DROP TABLE IF EXISTS `userview`;
/*!50001 DROP VIEW IF EXISTS `userview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `userview` (
  `Id` tinyint NOT NULL,
  `Email` tinyint NOT NULL,
  `Customer` tinyint NOT NULL,
  `Post` tinyint NOT NULL,
  `Division` tinyint NOT NULL,
  `Building` tinyint NOT NULL,
  `Room` tinyint NOT NULL,
  `WorkPhone` tinyint NOT NULL,
  `MobilePhone` tinyint NOT NULL,
  `Status` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `applicationagreedview`
--

/*!50001 DROP TABLE IF EXISTS `applicationagreedview`*/;
/*!50001 DROP VIEW IF EXISTS `applicationagreedview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `applicationagreedview` AS select `app`.`Id` AS `Id`,((((`us`.`SurName` + ' ') + `us`.`Name`) + ' ') + `us`.`Partonymic`) AS `Client`,`us`.`Email` AS `Email`,`us`.`Post` AS `Post`,`dvs`.`Name` AS `Division`,`dvs`.`Building` AS `Building`,`dvs`.`Room` AS `Room`,((((`usrdrc`.`SurName` + ' ') + `usrdrc`.`Name`) + ' ') + `usrdrc`.`Partonymic`) AS `Director`,((((`usrecn`.`SurName` + ' ') + `usrecn`.`Name`) + ' ') + `usrecn`.`Partonymic`) AS `Economist`,`app`.`CPC` AS `CPC`,`app`.`IntercityСity` AS `IntercityСity`,`app`.`PurposeUsingTransport` AS `PurposeUsingTransport`,`app`.`Days` AS `DaysWorkerOrWeekend`,`us`.`WorkPhone` AS `WorkPhone`,`us`.`MobilePhone` AS `MobilePhone`,`app`.`DateCreation` AS `DateCreation`,`app`.`StartDate` AS `StartDate`,`app`.`EndDate` AS `EndDate`,`tc`.`Name` AS `TypeCar`,`mc`.`Name` AS `Model`,`crs`.`RegisterSign` AS `RegisterSign`,`app`.`QuantityPassengers` AS `QuantityPassengers`,`app`.`CargoWeight` AS `CargoWeight`,`app`.`PlaceSubmission` AS `PlaceSubmission`,`app`.`Route` AS `Route`,`app`.`CommentClient` AS `CommentClient`,`app`.`СommentDirector` AS `СommentDirector`,`app`.`СommentEconomist` AS `СommentEconomist`,`app`.`СommentDepartment` AS `СommentDepartment`,`app`.`СommentDispatcherNIIAR` AS `СommentDispatcherNIIAR`,`app`.`СommentDispatcherATA` AS `СommentDispatcherATA`,`sdd`.`Name` AS `DirectorStatusDone`,`sde`.`Name` AS `EconomistStatusDone`,`sdddd`.`Name` AS `DepartmentStatusDone`,`sddd`.`Name` AS `DispatcherNIIAR_StatusDone`,`sddddd`.`Name` AS `DispatcherATA_StatusDone`,`app`.`SelectionApplicationJoin` AS `SelectionApplicationJoin`,`app`.`ApplicationJoin` AS `ApplicationJoin` from ((((((((((((`applications` `app` join `typecars` `tc` on((`app`.`TypeCarID` = `tc`.`Id`))) join `cars` `crs` on((`app`.`CarID` = `crs`.`Id`))) join `modelcars` `mc` on((`crs`.`ModelCarID` = `mc`.`Id`))) join `statusesdone` `sdd` on((`app`.`DirectorStatusDoneID` = `sdd`.`Id`))) join `statusesdone` `sddd` on((`app`.`DispatcherNIIAR_StatusDoneID` = `sddd`.`Id`))) join `statusesdone` `sde` on((`app`.`EconomistStatusDoneID` = `sde`.`Id`))) join `statusesdone` `sdddd` on((`app`.`DepartmentStatusDoneID` = `sdddd`.`Id`))) join `statusesdone` `sddddd` on((`app`.`DispatcherATA_StatusDoneID` = `sddddd`.`Id`))) join `users` `us` on((`app`.`UserID` = `us`.`Id`))) join `users` `usrdrc` on(((`usrdrc`.`StatusID` = 3) and (`usrdrc`.`DivisionID` = `us`.`DivisionID`)))) join `users` `usrecn` on(((`usrecn`.`StatusID` = 4) and (`usrecn`.`DivisionID` = `us`.`DivisionID`)))) join `divisions` `dvs` on((`us`.`DivisionID` = `dvs`.`Id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `applicationview`
--

/*!50001 DROP TABLE IF EXISTS `applicationview`*/;
/*!50001 DROP VIEW IF EXISTS `applicationview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `applicationview` AS select `app`.`Id` AS `Id`,((((`us`.`SurName` + ' ') + `us`.`Name`) + ' ') + `us`.`Partonymic`) AS `Client`,`us`.`Email` AS `Email`,`us`.`Post` AS `Post`,`dvs`.`Name` AS `Division`,`dvs`.`Building` AS `Building`,`dvs`.`Room` AS `Room`,((((`usrdrc`.`SurName` + ' ') + `usrdrc`.`Name`) + ' ') + `usrdrc`.`Partonymic`) AS `Director`,((((`usrecn`.`SurName` + ' ') + `usrecn`.`Name`) + ' ') + `usrecn`.`Partonymic`) AS `Economist`,`app`.`CPC` AS `CPC`,`app`.`IntercityСity` AS `IntercityСity`,`app`.`PurposeUsingTransport` AS `PurposeUsingTransport`,`app`.`Days` AS `DaysWorkerOrWeekend`,`us`.`WorkPhone` AS `WorkPhone`,`us`.`MobilePhone` AS `MobilePhone`,`app`.`DateCreation` AS `DateCreation`,`app`.`StartDate` AS `StartDate`,`app`.`EndDate` AS `EndDate`,`tc`.`Name` AS `TypeCar`,`app`.`QuantityPassengers` AS `QuantityPassengers`,`app`.`CargoWeight` AS `CargoWeight`,`app`.`PlaceSubmission` AS `PlaceSubmission`,`app`.`Route` AS `Route`,`app`.`CommentClient` AS `CommentClient`,`app`.`СommentDirector` AS `СommentDirector`,`app`.`СommentEconomist` AS `СommentEconomist`,`app`.`СommentDepartment` AS `СommentDepartment`,`app`.`СommentDispatcherNIIAR` AS `СommentDispatcherNIIAR`,`app`.`СommentDispatcherATA` AS `СommentDispatcherATA`,`sdd`.`Name` AS `DirectorStatusDone`,`sde`.`Name` AS `EconomistStatusDone`,`sdddd`.`Name` AS `DepartmentStatusDone`,`sddd`.`Name` AS `DispatcherNIIAR_StatusDone`,`sddddd`.`Name` AS `DispatcherATA_StatusDone`,`app`.`SelectionApplicationJoin` AS `SelectionApplicationJoin`,`app`.`ApplicationJoin` AS `ApplicationJoin` from ((((((((((`applications` `app` join `typecars` `tc` on((`app`.`TypeCarID` = `tc`.`Id`))) join `statusesdone` `sdd` on((`app`.`DirectorStatusDoneID` = `sdd`.`Id`))) join `statusesdone` `sddd` on((`app`.`DispatcherNIIAR_StatusDoneID` = `sddd`.`Id`))) join `statusesdone` `sde` on((`app`.`EconomistStatusDoneID` = `sde`.`Id`))) join `statusesdone` `sdddd` on((`app`.`DepartmentStatusDoneID` = `sdddd`.`Id`))) join `statusesdone` `sddddd` on((`app`.`DispatcherATA_StatusDoneID` = `sddddd`.`Id`))) join `users` `us` on((`app`.`UserID` = `us`.`Id`))) join `users` `usrdrc` on(((`usrdrc`.`StatusID` = 3) and (`usrdrc`.`DivisionID` = `us`.`DivisionID`)))) join `users` `usrecn` on(((`usrecn`.`StatusID` = 4) and (`usrecn`.`DivisionID` = `us`.`DivisionID`)))) join `divisions` `dvs` on((`us`.`DivisionID` = `dvs`.`Id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `carmodelview`
--

/*!50001 DROP TABLE IF EXISTS `carmodelview`*/;
/*!50001 DROP VIEW IF EXISTS `carmodelview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `carmodelview` AS select `crs`.`Id` AS `Id`,`tc`.`Name` AS `TypeCar`,`mc`.`Name` AS `Model`,`crs`.`RegisterSign` AS `RegisterSign`,`sc`.`Name` AS `StatusCar`,`crs`.`ImageMimeType` AS `ImageData` from (((`cars` `crs` join `typecars` `tc` on((`crs`.`TypeCarID` = `tc`.`Id`))) join `modelcars` `mc` on((`crs`.`ModelCarID` = `mc`.`Id`))) join `statuscars` `sc` on((`crs`.`StatusCarID` = `sc`.`Id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `carview`
--

/*!50001 DROP TABLE IF EXISTS `carview`*/;
/*!50001 DROP VIEW IF EXISTS `carview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `carview` AS select `crs`.`Id` AS `Id`,`tc`.`Name` AS `TypeCar`,`mc`.`Name` AS `Model`,`crs`.`RegisterSign` AS `RegisterSign`,`sc`.`Name` AS `StatusCar` from (((`cars` `crs` join `typecars` `tc` on((`crs`.`TypeCarID` = `tc`.`Id`))) join `modelcars` `mc` on((`crs`.`ModelCarID` = `mc`.`Id`))) join `statuscars` `sc` on((`crs`.`StatusCarID` = `sc`.`Id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `divisionview`
--

/*!50001 DROP TABLE IF EXISTS `divisionview`*/;
/*!50001 DROP VIEW IF EXISTS `divisionview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `divisionview` AS select `dvs`.`Id` AS `Id`,`dvs`.`Name` AS `Division`,`dvs`.`Building` AS `Building`,`dvs`.`Room` AS `Room` from `divisions` `dvs` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `modelcarview`
--

/*!50001 DROP TABLE IF EXISTS `modelcarview`*/;
/*!50001 DROP VIEW IF EXISTS `modelcarview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `modelcarview` AS select `ml`.`Id` AS `Id`,`ml`.`Name` AS `Model` from `modelcars` `ml` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `typecarview`
--

/*!50001 DROP TABLE IF EXISTS `typecarview`*/;
/*!50001 DROP VIEW IF EXISTS `typecarview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `typecarview` AS select `tc`.`Id` AS `Id`,`tc`.`Name` AS `TypeCar` from `typecars` `tc` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `userview`
--

/*!50001 DROP TABLE IF EXISTS `userview`*/;
/*!50001 DROP VIEW IF EXISTS `userview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `userview` AS select `usr`.`Id` AS `Id`,`usr`.`Email` AS `Email`,((((`usr`.`SurName` + ' ') + `usr`.`Name`) + ' ') + `usr`.`Partonymic`) AS `Customer`,`usr`.`Post` AS `Post`,`dvs`.`Name` AS `Division`,`dvs`.`Building` AS `Building`,`dvs`.`Room` AS `Room`,`usr`.`WorkPhone` AS `WorkPhone`,`usr`.`MobilePhone` AS `MobilePhone`,`sts`.`Name` AS `Status` from ((`users` `usr` join `divisions` `dvs` on((`usr`.`DivisionID` = `dvs`.`Id`))) join `statuses` `sts` on((`usr`.`StatusID` = `sts`.`Id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-29 16:18:22
