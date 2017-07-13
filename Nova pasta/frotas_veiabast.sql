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
-- Table structure for table `veiabast`
--

DROP TABLE IF EXISTS `veiabast`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `veiabast` (
  `CodVeiAbast` int(11) NOT NULL AUTO_INCREMENT,
  `Data` date DEFAULT NULL,
  `Veiculo_Km` int(11) DEFAULT NULL,
  `Quantidade` int(11) DEFAULT NULL,
  `Valor` int(11) DEFAULT NULL,
  `Notas` varchar(500) DEFAULT NULL,
  `CodVei` int(11) DEFAULT NULL,
  `CodForn` int(11) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodVeiAbast`),
  KEY `CodVei` (`CodVei`),
  KEY `CodForn` (`CodForn`),
  KEY `CodUser` (`CodUser`),
  CONSTRAINT `veiabast_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `veiabast_ibfk_2` FOREIGN KEY (`CodForn`) REFERENCES `fornecedores` (`CodForn`),
  CONSTRAINT `veiabast_ibfk_3` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiabast`
--

LOCK TABLES `veiabast` WRITE;
/*!40000 ALTER TABLE `veiabast` DISABLE KEYS */;
INSERT INTO `veiabast` VALUES (44,'2017-01-01',1,50,87,'',4,1,2),(45,'2017-06-14',1,200,10,'',5,2,4),(46,'2017-07-14',40,100,10,'',5,3,4),(47,'2017-04-04',1,100,10,'',6,2,5),(48,'2017-04-28',120,80,8,'',6,2,5),(49,'2017-05-18',200,67,7,'',6,3,5),(50,'2017-03-15',1,100,10,'',7,1,6),(51,'2017-06-29',123,100,10,'',7,3,6),(52,'2017-06-22',88000,60,114,'',8,2,7),(53,'2017-05-24',10,50,90,'',1,1,8),(54,'2017-07-12',88100,60,95,'',8,2,9);
/*!40000 ALTER TABLE `veiabast` ENABLE KEYS */;
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
