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
-- Table structure for table `tipomanu`
--

DROP TABLE IF EXISTS `tipomanu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipomanu` (
  `CodTipoM` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoM`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipomanu`
--

LOCK TABLES `tipomanu` WRITE;
/*!40000 ALTER TABLE `tipomanu` DISABLE KEYS */;
INSERT INTO `tipomanu` VALUES (1,'Ar condicionado'),(2,'Bateria'),(3,'Bomba de combustível'),(4,'Buzina'),(5,'Carroçaria/Chassis'),(6,'Cintos de segurança'),(7,'Correias'),(8,'Direção hidráulica'),(9,'Escovas do limpa pára-brisas'),(10,'Filtro de ar'),(11,'Filtro de combustível'),(12,'Filtro de óleo'),(13,'Filtro do habitáculo'),(14,'Inspeção técnica obrigatória'),(15,'Luzes'),(16,'Maxilas dos travões'),(17,'Mão de obra'),(18,'Pastilhas dos travões'),(19,'Pneus'),(20,'Pneus - Alinhamento/Calibragem'),(21,'Pneus - Calibragem'),(22,'Pneus - Troca'),(23,'Radiador'),(24,'Reparação de motor'),(25,'Revisão'),(26,'Sistema da embraiagem'),(27,'Sistema de aquecimento'),(28,'Sistema de arrefecimento'),(29,'Sistema de escape'),(30,'Suspensão/Amortecedores'),(31,'Troca de óleo'),(32,'Velas de ignição'),(33,'Vidros/Espelhos'),(34,'Óleo da embraiagem'),(35,'Óleo da transmissão'),(36,'Óleo dos travões');
/*!40000 ALTER TABLE `tipomanu` ENABLE KEYS */;
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
