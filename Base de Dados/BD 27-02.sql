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
) ENGINE=InnoDB AUTO_INCREMENT=160 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cidade`
--

LOCK TABLES `cidade` WRITE;
/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;
INSERT INTO `cidade` VALUES (1,'Abrantes',194),(2,'Agualva-Cacém',194),(3,'Albergaria-a-Velha',194),(4,'Albufeira',194),(5,'Alcobaça',194),(6,'Alcácer do Sal',194),(7,'Alfena',194),(8,'Almada',194),(9,'Almeirim',194),(10,'Alverca do Ribatejo',194),(11,'Amadora',194),(12,'Amarante',194),(13,'Amora',194),(14,'Anadia',194),(15,'Angra do Heroísmo',194),(16,'Aveiro',194),(17,'Barcelos',194),(18,'Barreiro',194),(19,'Beja',194),(20,'Borba',194),(21,'Braga',194),(22,'Bragança',194),(23,'Caldas da Rainha',194),(24,'Caniço',194),(25,'Cantanhede',194),(26,'Cartaxo',194),(27,'Castelo Branco',194),(28,'Chaves',194),(29,'Coimbra',194),(30,'Costa da Caparica',194),(31,'Covilhã',194),(32,'Câmara de Lobos',194),(33,'Elvas',194),(34,'Entroncamento',194),(35,'Ermesinde',194),(36,'Esmoriz',194),(37,'Espinho',194),(38,'Esposende',194),(39,'Estarreja',194),(40,'Estremoz',194),(41,'Fafe',194),(42,'Faro',194),(43,'Felgueiras',194),(44,'Figueira da Foz',194),(45,'Fiães',194),(46,'Freamunde',194),(47,'Funchal',194),(48,'Fundão',194),(49,'Fátima',194),(50,'Gafanha da Nazaré',194),(51,'Gaia',194),(52,'Gandra',194),(53,'Gondomar',194),(54,'Gouveia',194),(55,'Guarda',194),(56,'Guimarães',194),(57,'Horta',194),(58,'Lagoa',194),(59,'Lagoa',194),(60,'Lagos',194),(61,'Lamego',194),(62,'Leiria',194),(63,'Lisboa',194),(64,'Lixa',194),(65,'Lordelo',194),(66,'Loulé',194),(67,'Loures',194),(68,'Lourosa',194),(69,'Macedo de Cavaleiros',194),(70,'Machico',194),(71,'Maia',194),(72,'Mangualde',194),(73,'Marco de Canaveses',194),(74,'Marinha Grande',194),(75,'Matosinhos',194),(76,'Mealhada',194),(77,'Miranda do Douro / Miranda de l Douro',194),(78,'Mirandela',194),(79,'Montemor-o-Novo',194),(80,'Montijo',194),(81,'Moura',194),(82,'Mêda',194),(83,'Odivelas',194),(84,'Olhão da Restauração',194),(85,'Oliveira de Azeméis',194),(86,'Oliveira do Bairro',194),(87,'Oliveira do Hospital',194),(88,'Ourém',194),(89,'Ovar',194),(90,'Paredes',194),(91,'Paços de Ferreira',194),(92,'Penafiel',194),(93,'Peniche',194),(94,'Peso da Régua',194),(95,'Pinhel',194),(96,'Pombal',194),(97,'Ponta Delgada',194),(98,'Ponte de Sor',194),(99,'Portalegre',194),(100,'Portimão',194),(101,'Porto',194),(102,'Praia da Vitória',194),(103,'Póvoa de Santa Iria',194),(104,'Póvoa de Varzim',194),(105,'Quarteira',194),(106,'Queluz',194),(107,'Rebordosa',194),(108,'Reguengos de Monsaraz',194),(109,'Ribeira Grande',194),(110,'Rio Maior',194),(111,'Rio Tinto',194),(112,'Sabugal',194),(113,'Sacavém',194),(114,'Samora Correia',194),(115,'Santa Comba Dão',194),(116,'Santa Cruz',194),(117,'Santa Maria da Feira',194),(118,'Santana',194),(119,'Santarém',194),(120,'Santiago do Cacém',194),(121,'Santo Tirso',194),(122,'Seia',194),(123,'Seixal',194),(124,'Senhora da Hora',194),(125,'Serpa',194),(126,'Setúbal',194),(127,'Silves',194),(128,'Sines',194),(129,'São João da Madeira',194),(130,'São Mamede de Infesta',194),(131,'São Pedro do Sul',194),(132,'Tarouca',194),(133,'Tavira',194),(134,'Tomar',194),(135,'Tondela',194),(136,'Torres Novas',194),(137,'Torres Vedras',194),(138,'Trancoso',194),(139,'Trofa',194),(140,'Valbom',194),(141,'Vale de Cambra',194),(142,'Valença',194),(143,'Valongo',194),(144,'Valpaços',194),(145,'Vendas Novas',194),(146,'Viana do Castelo',194),(147,'Vila Baleira',194),(148,'Vila do Conde',194),(149,'Vila Franca de Xira',194),(150,'Vila Nova de Famalicão',194),(151,'Vila Nova de Foz Côa',194),(152,'Vila Nova de Santo André',194),(153,'Vila Real',194),(154,'Vila Real de Santo António',194),(155,'Viseu',194),(156,'Vizela',194),(157,'Águeda',194),(158,'Évora',194),(159,'Ílhavo',194);
/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `despesas`
--

DROP TABLE IF EXISTS `despesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `despesas` (
  `CodDesp` int(11) NOT NULL AUTO_INCREMENT,
  `Data_Efetuada` date DEFAULT NULL,
  `Veiculo_Km` int(11) DEFAULT NULL,
  `Valor` int(11) DEFAULT NULL,
  `Nota` varchar(500) DEFAULT NULL,
  `codVei` int(11) DEFAULT NULL,
  `codForn` int(11) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  `CodTipoD` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodDesp`),
  KEY `codVei` (`codVei`),
  KEY `codForn` (`codForn`),
  KEY `CodUser` (`CodUser`),
  KEY `CodTipoD` (`CodTipoD`),
  CONSTRAINT `despesas_ibfk_1` FOREIGN KEY (`codVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `despesas_ibfk_2` FOREIGN KEY (`codForn`) REFERENCES `fornecedores` (`CodForn`),
  CONSTRAINT `despesas_ibfk_3` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`),
  CONSTRAINT `despesas_ibfk_4` FOREIGN KEY (`CodTipoD`) REFERENCES `tipodesp` (`CodTipoD`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `despesas`
--

LOCK TABLES `despesas` WRITE;
/*!40000 ALTER TABLE `despesas` DISABLE KEYS */;
INSERT INTO `despesas` VALUES (1,'2000-01-01',23,100,'TESTE',1,1,1,1);
/*!40000 ALTER TABLE `despesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fornecedores`
--

DROP TABLE IF EXISTS `fornecedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedores` (
  `CodForn` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `Rua` varchar(200) DEFAULT NULL,
  `N_Telemovel` int(11) DEFAULT NULL,
  `N_Telefone` int(11) DEFAULT NULL,
  `site` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `CodTipoF` int(11) DEFAULT NULL,
  `CodCi` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodForn`),
  KEY `CodTipoF` (`CodTipoF`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `fornecedores_ibfk_1` FOREIGN KEY (`CodTipoF`) REFERENCES `tipofor` (`CodTipoF`),
  CONSTRAINT `fornecedores_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fornecedores`
--

LOCK TABLES `fornecedores` WRITE;
/*!40000 ALTER TABLE `fornecedores` DISABLE KEYS */;
INSERT INTO `fornecedores` VALUES (1,'N1 Combustiveis','ZONA 1',90000000,9000000,'www.N1.com','n1serv@gmail.com',2,1);
/*!40000 ALTER TABLE `fornecedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manutencao`
--

DROP TABLE IF EXISTS `manutencao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manutencao` (
  `CodManu` int(11) NOT NULL AUTO_INCREMENT,
  `Data_Efetuada` date DEFAULT NULL,
  `Veiculo_Km` int(11) DEFAULT NULL,
  `Valor` int(11) DEFAULT NULL,
  `Nota` varchar(500) DEFAULT NULL,
  `CodVei` int(11) DEFAULT NULL,
  `CodTipoM` int(11) DEFAULT NULL,
  `CodForn` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodManu`),
  KEY `CodVei` (`CodVei`),
  KEY `CodTipoM` (`CodTipoM`),
  KEY `CodForn` (`CodForn`),
  CONSTRAINT `manutencao_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `manutencao_ibfk_2` FOREIGN KEY (`CodTipoM`) REFERENCES `tipomanu` (`CodTipoM`),
  CONSTRAINT `manutencao_ibfk_3` FOREIGN KEY (`CodForn`) REFERENCES `fornecedores` (`CodForn`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manutencao`
--

LOCK TABLES `manutencao` WRITE;
/*!40000 ALTER TABLE `manutencao` DISABLE KEYS */;
INSERT INTO `manutencao` VALUES (1,'2000-01-01',25,2000,'Teste ',1,NULL,1);
/*!40000 ALTER TABLE `manutencao` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `tipocom`
--

DROP TABLE IF EXISTS `tipocom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipocom` (
  `CodTipoC` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `designacao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoC`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipocom`
--

LOCK TABLES `tipocom` WRITE;
/*!40000 ALTER TABLE `tipocom` DISABLE KEYS */;
INSERT INTO `tipocom` VALUES (1,'Gasolina','L'),(2,'Gasoleo','L'),(3,'GPL','L'),(4,'Eletricidade','Kw');
/*!40000 ALTER TABLE `tipocom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipodesp`
--

DROP TABLE IF EXISTS `tipodesp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipodesp` (
  `CodTipoD` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoD`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipodesp`
--

LOCK TABLES `tipodesp` WRITE;
/*!40000 ALTER TABLE `tipodesp` DISABLE KEYS */;
INSERT INTO `tipodesp` VALUES (1,'Empréstimo'),(2,'Estacionamento'),(3,'Impostos (IUC)'),(4,'Lavagem do carro'),(5,'Licenças'),(6,'Multa'),(7,'Reembolsos'),(8,'Seguros'),(9,'Taxas');
/*!40000 ALTER TABLE `tipodesp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipofor`
--

DROP TABLE IF EXISTS `tipofor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipofor` (
  `CodTipoF` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoF`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipofor`
--

LOCK TABLES `tipofor` WRITE;
/*!40000 ALTER TABLE `tipofor` DISABLE KEYS */;
INSERT INTO `tipofor` VALUES (1,'Oficina'),(2,'Estação de Serviço');
/*!40000 ALTER TABLE `tipofor` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `tipouser`
--

DROP TABLE IF EXISTS `tipouser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipouser` (
  `CodTipoU` int(11) NOT NULL AUTO_INCREMENT,
  `designacao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoU`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipouser`
--

LOCK TABLES `tipouser` WRITE;
/*!40000 ALTER TABLE `tipouser` DISABLE KEYS */;
INSERT INTO `tipouser` VALUES (1,'Admin'),(2,'Guest'),(3,'Funcinario Low'),(4,'Funcionario High');
/*!40000 ALTER TABLE `tipouser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipovei`
--

DROP TABLE IF EXISTS `tipovei`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipovei` (
  `CodTipoV` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoV`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipovei`
--

LOCK TABLES `tipovei` WRITE;
/*!40000 ALTER TABLE `tipovei` DISABLE KEYS */;
INSERT INTO `tipovei` VALUES (1,'Veiculo Ligeiro'),(2,'Veiculo Pesado'),(3,'Maquina');
/*!40000 ALTER TABLE `tipovei` ENABLE KEYS */;
UNLOCK TABLES;

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
  `Data_Contratacao` date DEFAULT NULL,
  `Pagamentos_Hora` varchar(50) DEFAULT NULL,
  `Habilitacoes` varchar(50) DEFAULT NULL,
  `Rua` varchar(200) DEFAULT NULL,
  `N_Telemovel` int(11) DEFAULT NULL,
  `N_Telefone` int(11) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Notas_contacto` varchar(500) DEFAULT NULL,
  `Notas_Contracto` varchar(500) DEFAULT NULL,
  `CodTipoU` int(11) DEFAULT '2',
  `CodCi` int(11) DEFAULT NULL,
  `UserPic` varchar(500) NOT NULL,
  PRIMARY KEY (`CodUser`),
  KEY `CodTipoU` (`CodTipoU`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `utilizador_ibfk_1` FOREIGN KEY (`CodTipoU`) REFERENCES `tipouser` (`CodTipoU`),
  CONSTRAINT `utilizador_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilizador`
--

LOCK TABLES `utilizador` WRITE;
/*!40000 ALTER TABLE `utilizador` DISABLE KEYS */;
INSERT INTO `utilizador` VALUES (1,'Admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Admin','Admin','Masculino','1997-02-01','1997-02-01','25','We dont Know!!\r\n\r\nTESTE','ADMIM Street',960000000,980000000,'admin@admin.com','He Likes to Sleep','He needs more money!!',1,63,''),(2,'bypedro','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'bypedro12@hotmail.com',NULL,NULL,2,NULL,''),(3,'Pedro2','fa611d6568e240efffb79b33f04f0d17460e49feab5c95ca6acc0c600966cdad',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'bypedro1@hotmail.com',NULL,NULL,2,NULL,''),(4,'LOL','ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'LOL@LOL.com',NULL,NULL,2,NULL,''),(5,'LOL1','ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'LOL@LOL',NULL,NULL,2,NULL,'');
/*!40000 ALTER TABLE `utilizador` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiabast`
--

LOCK TABLES `veiabast` WRITE;
/*!40000 ALTER TABLE `veiabast` DISABLE KEYS */;
INSERT INTO `veiabast` VALUES (1,'2000-01-01',10,10,10,'Teste',1,1,1),(2,'2000-01-01',15,10,10,'Teste 2',1,1,1);
/*!40000 ALTER TABLE `veiabast` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veiacid`
--

DROP TABLE IF EXISTS `veiacid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `veiacid` (
  `CodAcid` int(11) NOT NULL,
  `Data_Acidente` date DEFAULT NULL,
  `Notas` varchar(500) DEFAULT NULL,
  `CodVei` int(11) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodAcid`),
  KEY `CodVei` (`CodVei`),
  KEY `CodUser` (`CodUser`),
  CONSTRAINT `veiacid_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `veiacid_ibfk_2` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiacid`
--

LOCK TABLES `veiacid` WRITE;
/*!40000 ALTER TABLE `veiacid` DISABLE KEYS */;
INSERT INTO `veiacid` VALUES (1,'1999-12-12','TESTE',1,1);
/*!40000 ALTER TABLE `veiacid` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veicondu`
--

LOCK TABLES `veicondu` WRITE;
/*!40000 ALTER TABLE `veicondu` DISABLE KEYS */;
INSERT INTO `veicondu` VALUES (1,'Carro a ser Conduzido','2017-02-14','3000-00-00',1,1,'Sim'),(2,'Carro Parou de ser conduzido','2017-01-01','2017-02-13',1,1,'Nao');
/*!40000 ALTER TABLE `veicondu` ENABLE KEYS */;
UNLOCK TABLES;

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
  `Proxima_Inspecao` date DEFAULT NULL,
  `Ultima_Inspecao` date DEFAULT NULL,
  `CodTipoC` int(11) DEFAULT NULL,
  `CodTipoV` int(11) DEFAULT NULL,
  PRIMARY KEY (`codVei`),
  KEY `CodTipoC` (`CodTipoC`),
  KEY `CodTipoV` (`CodTipoV`),
  CONSTRAINT `veiculos_ibfk_1` FOREIGN KEY (`CodTipoC`) REFERENCES `tipocom` (`CodTipoC`),
  CONSTRAINT `veiculos_ibfk_2` FOREIGN KEY (`CodTipoV`) REFERENCES `tipovei` (`CodTipoV`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculos`
--

LOCK TABLES `veiculos` WRITE;
/*!40000 ALTER TABLE `veiculos` DISABLE KEYS */;
INSERT INTO `veiculos` VALUES (1,'00-AA-00','BMW','M3','Austin Yellow Metallic',2014,'2016-06-28','2014-06-28',1,1);
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

-- Dump completed on 2017-02-27 15:45:05
