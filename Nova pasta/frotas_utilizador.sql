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
-- Table structure for table `utilizador`
--

DROP TABLE IF EXISTS `utilizador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utilizador` (
  `CodUser` int(11) NOT NULL AUTO_INCREMENT,
  `Nome_Registo` varchar(50) DEFAULT NULL,
  `Senha` varchar(256) DEFAULT NULL,
  `Nome_Proprio` varchar(100) DEFAULT NULL,
  `Apelido` varchar(100) DEFAULT NULL,
  `Genero` varchar(50) DEFAULT NULL,
  `Data_Nascimento` date DEFAULT NULL,
  `Rua` varchar(200) DEFAULT NULL,
  `N_Telemovel` int(10) unsigned zerofill DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `CodTipoU` int(11) DEFAULT '2',
  `CodCi` int(11) DEFAULT NULL,
  `location` varchar(100) DEFAULT 'photos/default_avatar.jpg',
  PRIMARY KEY (`CodUser`),
  KEY `CodTipoU` (`CodTipoU`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `utilizador_ibfk_1` FOREIGN KEY (`CodTipoU`) REFERENCES `tipouser` (`CodTipoU`),
  CONSTRAINT `utilizador_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilizador`
--

LOCK TABLES `utilizador` WRITE;
/*!40000 ALTER TABLE `utilizador` DISABLE KEYS */;
INSERT INTO `utilizador` VALUES (1,'Admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Admin Admin','Admin Admin','Masculino','1997-06-28','ADMIM Street',0960000000,'admin@admin.com',1,63,'photos/default_avatar.jpg'),(2,'bypedro','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Pedro','Gaspar','Masculino','1997-02-06','Av Portugal',0968011419,'bypedro12@hotmail.com',3,63,'photos/default_avatar.jpg'),(4,'Soares','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Gonçalo','Soares','Masculino','1998-04-21','',0960000000,'LOL@LOL.com',3,63,'photos/default_avatar.jpg'),(5,'User1234','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','User','Teste','Masculino','1997-07-01','',0960000000,'LOL@LOL',3,63,'photos/default_avatar.jpg'),(6,'Paulo','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Paulo','Laneiro','Masculino','1997-02-01','',0000000000,'PaUlO_Juão@sapo.pt',3,63,'photos/default_avatar.jpg'),(7,'JJ','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','João','Jacinto','Masculino','1997-02-01','Avenida de Portugal',0960000000,'bypedro12@hotmail.com',3,63,'photos/default_avatar.jpg'),(8,'Diogo','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Diogo','Rodrigues','Masculino','1988-05-11',' ',0960000000,'diogo@gmail.com',3,63,'photos/default_avatar.jpg'),(9,'Joana','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','Joana','Isabel','Masculino','2017-07-11',' ',0960000000,'ji@gmail.com',4,63,'photos/default_avatar.jpg');
/*!40000 ALTER TABLE `utilizador` ENABLE KEYS */;
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
