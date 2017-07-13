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
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pais` (
  `Codpais` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Codpais`)
) ENGINE=InnoDB AUTO_INCREMENT=253 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pais`
--

LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
INSERT INTO `pais` VALUES (1,'Afeganistão'),(2,'África do Sul'),(3,'Albânia'),(4,'Alderney'),(5,'Alemanha'),(6,'Andorra'),(7,'Angola'),(8,'Anguilla'),(9,'Antártida'),(10,'Antígua e Barbuda'),(11,'Antilhas Holandesas'),(12,'Arábia Saudita'),(13,'Argélia'),(14,'Argentina'),(15,'Armênia'),(16,'Aruba'),(17,'Austrália'),(18,'Áustria'),(19,'Azerbaijão'),(20,'Bahamas'),(21,'Bahrein'),(22,'Bangladesh'),(23,'Barbados'),(24,'Belarus'),(25,'Bélgica'),(26,'Belize'),(27,'Benin'),(28,'Bermudas'),(29,'Bolívia'),(30,'Bósnia-Herzegóvina'),(31,'Botsuana'),(32,'Brasil'),(33,'Brunei'),(34,'Bulgária'),(35,'Burkina Fasso'),(36,'Burundi'),(37,'Butão'),(38,'Cabo Verde'),(39,'Camarões'),(40,'Camboja'),(41,'Canadá'),(42,'Cazaquistão'),(43,'Chade'),(44,'Chile'),(45,'China'),(46,'Chipre'),(47,'Cingapura'),(48,'Colômbia'),(49,'Congo'),(50,'Coréia do Norte'),(51,'Coréia do Sul'),(52,'Costa do Marfim'),(53,'Costa Rica'),(54,'Croácia (Hrvatska)'),(55,'Cuba'),(56,'Dinamarca'),(57,'Djibuti'),(58,'Dominica'),(59,'Egito'),(60,'El Salvador'),(61,'Emirados Árabes Unidos'),(62,'Equador'),(63,'Eritréia'),(64,'Eslováquia'),(65,'Eslovênia'),(66,'Espanha'),(67,'Estados Unidos'),(68,'Estônia'),(69,'Etiópia'),(70,'Federação Russa'),(71,'Fiji'),(72,'Filipinas'),(73,'Finlândia'),(74,'França'),(75,'Gabão'),(76,'Gâmbia'),(77,'Gana'),(78,'Geórgia'),(79,'Gibraltar'),(80,'Grã-Bretanha (Reino Unido)'),(81,'Granada'),(82,'Grécia'),(83,'Groelândia'),(84,'Guadalupe'),(85,'Guam (Território dos Estados Unidos)'),(86,'Guatemala'),(87,'Guernsey'),(88,'Guiana'),(89,'Guiana Francesa'),(90,'Guiné'),(91,'Guiné Equatorial'),(92,'Guiné-Bissau'),(93,'Haiti'),(94,'Holanda'),(95,'Honduras'),(96,'Hong Kong'),(97,'Hungria'),(98,'Iêmen'),(99,'Ilha Bouvet (Território da Noruega)'),(100,'Ilha de Ascensão'),(101,'Ilha do Homem'),(102,'Ilha Natal'),(103,'Ilha Pitcairn'),(104,'Ilha Reunião'),(105,'Ilhas Aland'),(106,'Ilhas Cayman'),(107,'Ilhas Cocos'),(108,'Ilhas Comores'),(109,'Ilhas Cook'),(110,'Ilhas do Canal'),(111,'Ilhas Falkland (Malvinas)'),(112,'Ilhas Faroes'),(113,'Ilhas Geórgia do Sul e Sandwich do Sul'),(114,'Ilhas Heard e McDonald (Território da Austrália)'),(115,'Ilhas Marianas do Norte'),(116,'Ilhas Marshall'),(117,'Ilhas Menores dos Estados Unidos'),(118,'Ilhas Norfolk'),(119,'Ilhas Seychelles'),(120,'Ilhas Solomão'),(121,'Ilhas Svalbard e Jan Mayen'),(122,'Ilhas Tokelau'),(123,'Ilhas Turks e Caicos'),(124,'Ilhas Virgens (Estados Unidos)'),(125,'Ilhas Virgens (Inglaterra)'),(126,'Ilhas Wallis e Futuna'),(127,'Índia'),(128,'Indonésia'),(129,'Irã'),(130,'Iraque'),(131,'Irlanda'),(132,'Islândia'),(133,'Israel'),(134,'Itália'),(135,'Jamaica'),(136,'Japão'),(137,'Jersey'),(138,'Jordânia'),(139,'Kênia'),(140,'Kiribati'),(141,'Kuait'),(142,'Kyrgyzstan'),(143,'Laos'),(144,'Látvia'),(145,'Lesoto'),(146,'Líbano'),(147,'Libéria'),(148,'Líbia'),(149,'Liechtenstein'),(150,'Lituânia'),(151,'Luxemburgo'),(152,'Macau'),(153,'Macedônia (República Yugoslava)'),(154,'Madagascar'),(155,'Malásia'),(156,'Malaui'),(157,'Maldivas'),(158,'Mali'),(159,'Malta'),(160,'Marrocos'),(161,'Martinica'),(162,'Maurício'),(163,'Mauritânia'),(164,'Mayotte'),(165,'Mexico'),(166,'Micronésia'),(167,'Moçambique'),(168,'Moldova'),(169,'Mônaco'),(170,'Mongólia'),(171,'Montenegro'),(172,'Montserrat'),(173,'Myanma (Ex-Burma)'),(174,'Namíbia'),(175,'Nauru'),(176,'Nepal'),(177,'Nicarágua'),(178,'Níger'),(179,'Nigéria'),(180,'Niue'),(181,'Noruega'),(182,'Nova Caledônia'),(183,'Nova Zelândia'),(184,'Omã'),(185,'Palau'),(186,'Panamá'),(187,'Papua-Nova Guiné'),(188,'Paquistão'),(189,'Paraguai'),(190,'Peru'),(191,'Polinésia Francesa'),(192,'Polônia'),(193,'Porto Rico'),(194,'Portugal'),(195,'Qatar'),(196,'Reino da Jugoslávia'),(197,'República Centro-Africana'),(198,'República Democrática do Congo (ex-Zaire)'),(199,'República Dominicana'),(200,'República Tcheca'),(201,'Romênia'),(202,'Ruanda'),(203,'Saara Ocidental (Ex-Spanish Sahara)'),(204,'Saint Vincente e Granadinas'),(205,'Samoa Americana'),(206,'Samoa Ocidental'),(207,'San Marino'),(208,'Santa Helena'),(209,'Santa Lúcia'),(210,'São Bartolomeu'),(211,'São Cristóvão e Névis'),(212,'São Martim'),(213,'São Tomé e Príncipe'),(214,'Senegal'),(215,'Serra Leoa'),(216,'Sérvia'),(217,'Síria'),(218,'Somália'),(219,'Sri Lanka'),(220,'St. Pierre and Miquelon'),(221,'Suazilândia'),(222,'Sudão'),(223,'Suécia'),(224,'Suíça'),(225,'Suriname'),(226,'Tadjiquistão'),(227,'Tailândia'),(228,'Taiwan'),(229,'Tanganica'),(230,'Tanzânia'),(231,'Território Britânico do Oceano índico'),(232,'Territórios do Sul da França'),(233,'Territórios Palestinos Ocupados'),(234,'Timor Leste (Ex-East Timor)'),(235,'Togo'),(236,'Tonga'),(237,'Trinidad and Tobago'),(238,'Tunísia'),(239,'Turcomenistão'),(240,'Turquia'),(241,'Tuvalu'),(242,'Ucrânia'),(243,'Uganda'),(244,'Uruguai'),(245,'Uzbequistão'),(246,'Vanuatu'),(247,'Vaticano'),(248,'Venezuela'),(249,'Vietnam'),(250,'Zâmbia'),(251,'Zanzibar					'),(252,'Zimbábue');
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
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
