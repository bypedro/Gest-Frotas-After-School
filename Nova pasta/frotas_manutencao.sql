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
-- Table structure for table `manutencao`
--

DROP TABLE IF EXISTS `manutencao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manutencao` (
  `CodManu` int(11) NOT NULL AUTO_INCREMENT,
  `Data_Efetuada` date DEFAULT '2000-01-01',
  `Veiculo_Km` int(11) DEFAULT '0',
  `Valor` int(11) DEFAULT '0',
  `Nota` varchar(500) DEFAULT ' ',
  `CodVei` int(11) DEFAULT NULL,
  `CodTipoM` int(11) DEFAULT NULL,
  `CodForn` int(11) DEFAULT NULL,
  `Data_Agendada` date DEFAULT '2000-01-01',
  `Efetuada` varchar(45) DEFAULT 'Nao',
  `Veiculo_Km_Agendado` int(11) DEFAULT '0',
  `LembrarPor` varchar(45) DEFAULT 'Nada',
  `CodUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodManu`),
  KEY `CodVei` (`CodVei`),
  KEY `CodTipoM` (`CodTipoM`),
  KEY `CodForn` (`CodForn`),
  KEY `manutencao_ibfk_4` (`CodUser`),
  CONSTRAINT `manutencao_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `manutencao_ibfk_2` FOREIGN KEY (`CodTipoM`) REFERENCES `tipomanu` (`CodTipoM`),
  CONSTRAINT `manutencao_ibfk_3` FOREIGN KEY (`CodForn`) REFERENCES `fornecedores` (`CodForn`),
  CONSTRAINT `manutencao_ibfk_4` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manutencao`
--

LOCK TABLES `manutencao` WRITE;
/*!40000 ALTER TABLE `manutencao` DISABLE KEYS */;
INSERT INTO `manutencao` VALUES (28,'2017-01-25',220,20,'',4,25,1,'2000-01-01','Sim',0,'Nada',2),(29,'2017-07-12',20,100,'Bateria teve um curto circuito.',5,2,1,'2000-01-01','Sim',0,'Nada',4),(30,'2000-01-01',0,0,'',5,14,1,'2017-07-28','Nao',0,'DATA',4),(31,'2017-07-12',230,300,'',6,15,1,'2000-01-01','Sim',0,'Nada',5),(32,'2000-01-01',0,0,'',6,19,1,'2017-11-01','Nao',0,'DATA',5),(33,'2017-05-31',60,50,'',7,36,1,'2000-01-01','Sim',0,'Nada',6),(34,'2017-07-12',80,400,'',7,4,1,'2000-01-01','Sim',0,'Nada',6),(35,'2017-07-04',88050,20,'',8,14,2,'2000-01-01','Sim',0,'Nada',7),(36,'2017-06-01',20,20,'',1,14,1,'2000-01-01','Sim',0,'Nada',8),(37,'2017-06-12',35,500,'',1,15,1,'2000-01-01','Sim',0,'Nada',8);
/*!40000 ALTER TABLE `manutencao` ENABLE KEYS */;
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
