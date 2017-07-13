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
-- Table structure for table `cidade`
--

DROP TABLE IF EXISTS `cidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cidade` (
  `CodCi` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  `Codpais` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodCi`),
  KEY `Codpais` (`Codpais`),
  CONSTRAINT `cidade_ibfk_1` FOREIGN KEY (`Codpais`) REFERENCES `pais` (`Codpais`)
) ENGINE=InnoDB AUTO_INCREMENT=161 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cidade`
--

LOCK TABLES `cidade` WRITE;
/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;
INSERT INTO `cidade` VALUES (1,'Abrantes',194),(2,'Agualva-Cacém',194),(3,'Albergaria-a-Velha',194),(4,'Albufeira',194),(5,'Alcobaça',194),(6,'Alcácer do Sal',194),(7,'Alfena',194),(8,'Almada',194),(9,'Almeirim',194),(10,'Alverca do Ribatejo',194),(11,'Amadora',194),(12,'Amarante',194),(13,'Amora',194),(14,'Anadia',194),(15,'Angra do Heroísmo',194),(16,'Aveiro',194),(17,'Barcelos',194),(18,'Barreiro',194),(19,'Beja',194),(20,'Borba',194),(21,'Braga',194),(22,'Bragança',194),(23,'Caldas da Rainha',194),(24,'Caniço',194),(25,'Cantanhede',194),(26,'Cartaxo',194),(27,'Castelo Branco',194),(28,'Chaves',194),(29,'Coimbra',194),(30,'Costa da Caparica',194),(31,'Covilhã',194),(32,'Câmara de Lobos',194),(33,'Elvas',194),(34,'Entroncamento',194),(35,'Ermesinde',194),(36,'Esmoriz',194),(37,'Espinho',194),(38,'Esposende',194),(39,'Estarreja',194),(40,'Estremoz',194),(41,'Fafe',194),(42,'Faro',194),(43,'Felgueiras',194),(44,'Figueira da Foz',194),(45,'Fiães',194),(46,'Freamunde',194),(47,'Funchal',194),(48,'Fundão',194),(49,'Fátima',194),(50,'Gafanha da Nazaré',194),(51,'Gaia',194),(52,'Gandra',194),(53,'Gondomar',194),(54,'Gouveia',194),(55,'Guarda',194),(56,'Guimarães',194),(57,'Horta',194),(58,'Lagoa',194),(59,'Lagoa',194),(60,'Lagos',194),(61,'Lamego',194),(62,'Leiria',194),(63,'Lisboa',194),(64,'Lixa',194),(65,'Lordelo',194),(66,'Loulé',194),(67,'Loures',194),(68,'Lourosa',194),(69,'Macedo de Cavaleiros',194),(70,'Machico',194),(71,'Maia',194),(72,'Mangualde',194),(73,'Marco de Canaveses',194),(74,'Marinha Grande',194),(75,'Matosinhos',194),(76,'Mealhada',194),(77,'Miranda do Douro / Miranda de l Douro',194),(78,'Mirandela',194),(79,'Montemor-o-Novo',194),(80,'Montijo',194),(81,'Moura',194),(82,'Mêda',194),(83,'Odivelas',194),(84,'Olhão da Restauração',194),(85,'Oliveira de Azeméis',194),(86,'Oliveira do Bairro',194),(87,'Oliveira do Hospital',194),(88,'Ourém',194),(89,'Ovar',194),(90,'Paredes',194),(91,'Paços de Ferreira',194),(92,'Penafiel',194),(93,'Peniche',194),(94,'Peso da Régua',194),(95,'Pinhel',194),(96,'Pombal',194),(97,'Ponta Delgada',194),(98,'Ponte de Sor',194),(99,'Portalegre',194),(100,'Portimão',194),(101,'Porto',194),(102,'Praia da Vitória',194),(103,'Póvoa de Santa Iria',194),(104,'Póvoa de Varzim',194),(105,'Quarteira',194),(106,'Queluz',194),(107,'Rebordosa',194),(108,'Reguengos de Monsaraz',194),(109,'Ribeira Grande',194),(110,'Rio Maior',194),(111,'Rio Tinto',194),(112,'Sabugal',194),(113,'Sacavém',194),(114,'Samora Correia',194),(115,'Santa Comba Dão',194),(116,'Santa Cruz',194),(117,'Santa Maria da Feira',194),(118,'Santana',194),(119,'Santarém',194),(120,'Santiago do Cacém',194),(121,'Santo Tirso',194),(122,'Seia',194),(123,'Seixal',194),(124,'Senhora da Hora',194),(125,'Serpa',194),(126,'Setúbal',194),(127,'Silves',194),(128,'Sines',194),(129,'São João da Madeira',194),(130,'São Mamede de Infesta',194),(131,'São Pedro do Sul',194),(132,'Tarouca',194),(133,'Tavira',194),(134,'Tomar',194),(135,'Tondela',194),(136,'Torres Novas',194),(137,'Torres Vedras',194),(138,'Trancoso',194),(139,'Trofa',194),(140,'Valbom',194),(141,'Vale de Cambra',194),(142,'Valença',194),(143,'Valongo',194),(144,'Valpaços',194),(145,'Vendas Novas',194),(146,'Viana do Castelo',194),(147,'Vila Baleira',194),(148,'Vila do Conde',194),(149,'Vila Franca de Xira',194),(150,'Vila Nova de Famalicão',194),(151,'Vila Nova de Foz Côa',194),(152,'Vila Nova de Santo André',194),(153,'Vila Real',194),(154,'Vila Real de Santo António',194),(155,'Viseu',194),(156,'Vizela',194),(157,'Águeda',194),(158,'Évora',194),(159,'Ílhavo',194),(160,'Barcelona',66);
/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;
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
