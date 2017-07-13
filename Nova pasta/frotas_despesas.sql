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
-- Table structure for table `despesas`
--

DROP TABLE IF EXISTS `despesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `despesas` (
  `CodDesp` int(11) NOT NULL AUTO_INCREMENT,
  `Data_Efetuada` date DEFAULT '2000-01-01',
  `Veiculo_Km` int(11) DEFAULT '0',
  `Valor` int(11) DEFAULT '0',
  `Nota` varchar(500) DEFAULT ' ',
  `codVei` int(11) DEFAULT NULL,
  `codForn` int(11) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  `CodTipoD` int(11) DEFAULT NULL,
  `Data_Agendada` date DEFAULT '2000-01-01',
  `Efetuada` varchar(45) DEFAULT 'Nao',
  `Veiculo_Km_Agendado` int(11) DEFAULT '0',
  `LembrarPor` varchar(45) DEFAULT 'Nada',
  PRIMARY KEY (`CodDesp`),
  KEY `codVei` (`codVei`),
  KEY `codForn` (`codForn`),
  KEY `CodUser` (`CodUser`),
  KEY `CodTipoD` (`CodTipoD`),
  CONSTRAINT `despesas_ibfk_1` FOREIGN KEY (`codVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `despesas_ibfk_2` FOREIGN KEY (`codForn`) REFERENCES `fornecedores` (`CodForn`),
  CONSTRAINT `despesas_ibfk_3` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`),
  CONSTRAINT `despesas_ibfk_4` FOREIGN KEY (`CodTipoD`) REFERENCES `tipodesp` (`CodTipoD`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `despesas`
--

LOCK TABLES `despesas` WRITE;
/*!40000 ALTER TABLE `despesas` DISABLE KEYS */;
INSERT INTO `despesas` VALUES (17,'2017-07-12',234,5,'',4,4,2,2,'2000-01-01','Sim',0,'Nada'),(18,'2017-07-12',240,100,'Carro estacionado em local impróprio.',4,4,2,6,'2000-01-01','Sim',0,'Nada'),(19,'2017-07-12',25,2,'',5,2,4,2,'2000-01-01','Sim',0,'Nada'),(20,'2017-07-15',41,50,'',5,5,4,3,'2000-01-01','Sim',0,'Nada'),(21,'2000-01-01',0,0,'',5,1,4,1,'2017-08-05','Nao',0,'DATA'),(22,'2017-07-13',235,230,'',6,1,5,8,'2000-01-01','Sim',0,'Nada'),(23,'2000-01-01',0,0,'',6,1,5,1,'2017-08-04','Nao',0,'DATA'),(24,'2017-06-15',100,1000,'',7,4,6,1,'2000-01-01','Sim',0,'Nada'),(25,'2017-07-12',150,385,'',7,1,6,8,'2000-01-01','Sim',0,'Nada'),(26,'2017-07-12',88052,10,'',8,1,7,4,'2000-01-01','Sim',0,'Nada'),(27,'2017-07-12',88098,200,'Execesso de velocidade.',8,1,7,6,'2000-01-01','Sim',0,'Nada'),(28,'2017-07-12',70,500,'',1,2,8,6,'2000-01-01','Sim',0,'Nada');
/*!40000 ALTER TABLE `despesas` ENABLE KEYS */;
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
