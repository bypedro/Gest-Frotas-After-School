CREATE DATABASE  IF NOT EXISTS `frotas` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `frotas`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: frotas
-- ------------------------------------------------------
-- Server version	5.7.17-log

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
-- Table structure for table `veicondu`
--

DROP TABLE IF EXISTS `veicondu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `veicondu` (
  `CodVeiC` int(11) NOT NULL AUTO_INCREMENT,
  `Notas` varchar(500) DEFAULT NULL,
  `Quando_Comecou` date DEFAULT NULL,
  `Quando_Acabou` date DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  `CodVei` int(11) DEFAULT NULL,
  `EmUso` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CodVeiC`),
  KEY `CodUser` (`CodUser`),
  KEY `CodVei` (`CodVei`),
  CONSTRAINT `veicondu_ibfk_1` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`),
  CONSTRAINT `veicondu_ibfk_2` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veicondu`
--

LOCK TABLES `veicondu` WRITE;
/*!40000 ALTER TABLE `veicondu` DISABLE KEYS */;
INSERT INTO `veicondu` VALUES (1,'Carro a ser Conduzido','2017-02-14','2017-07-12',1,1,'Nao'),(2,'Carro Parou de ser conduzido','2017-01-01','2017-02-13',1,1,'Nao'),(3,'CARRO PAROU UPDATE','2017-03-01','2017-03-05',1,1,'Nao'),(4,'Novo','2017-03-05','2017-03-09',1,3,'Nao'),(5,' ','2017-07-12','2017-07-12',6,8,'Nao'),(6,' ','2017-07-12','2017-07-12',5,8,'Nao'),(7,' ','2017-07-12','3000-01-01',2,4,'Sim'),(8,' ','2017-07-12','3000-01-01',4,5,'Sim'),(9,' ','2017-07-12','3000-01-01',5,6,'Sim'),(10,' ','2017-07-12','3000-01-01',6,7,'Sim'),(11,' ','2017-07-12','2017-07-12',7,8,'Nao'),(12,' ','2017-07-12','3000-01-01',8,1,'Sim'),(13,' ','2017-07-12','3000-01-01',9,8,'Sim');
/*!40000 ALTER TABLE `veicondu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-13 16:25:02
