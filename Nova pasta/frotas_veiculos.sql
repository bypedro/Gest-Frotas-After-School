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
-- Table structure for table `veiculos`
--

DROP TABLE IF EXISTS `veiculos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `veiculos` (
  `codVei` int(11) NOT NULL AUTO_INCREMENT,
  `Matricula` varchar(50) DEFAULT NULL,
  `Marca` varchar(50) DEFAULT NULL,
  `Modelo` varchar(50) DEFAULT NULL,
  `cor` varchar(50) DEFAULT NULL,
  `Ano` int(11) DEFAULT NULL,
  `CodTipoC` int(11) DEFAULT NULL,
  `CodTipoV` int(11) DEFAULT NULL,
  PRIMARY KEY (`codVei`),
  KEY `CodTipoC` (`CodTipoC`),
  KEY `CodTipoV` (`CodTipoV`),
  CONSTRAINT `veiculos_ibfk_1` FOREIGN KEY (`CodTipoC`) REFERENCES `tipocom` (`CodTipoC`),
  CONSTRAINT `veiculos_ibfk_2` FOREIGN KEY (`CodTipoV`) REFERENCES `tipovei` (`CodTipoV`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculos`
--

LOCK TABLES `veiculos` WRITE;
/*!40000 ALTER TABLE `veiculos` DISABLE KEYS */;
INSERT INTO `veiculos` VALUES (1,'00-AA-00','BMW','M3','Austin Yellow Metallic',2014,1,1),(2,'00-BB-00','Nissan','Skyline','Branco',1997,1,4),(3,'00-BB-00','Nissan','Skyline','Azul',2000,1,4),(4,'12-33-DD','Mercedes','Actros','Preto',2001,2,2),(5,'43-DD-21','Tesla','S','Cinza',2017,4,1),(6,'44-DD-22','Tesla','E','Branco',2017,4,1),(7,'44-DD-23','Tesla','X','Preto',2017,4,1),(8,'12-DD-12','Mercedos','SLS','Preto',2012,1,1),(9,'42-55-EE','Nissan','Micra','Verde',1997,1,4);
/*!40000 ALTER TABLE `veiculos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-13 16:25:03
