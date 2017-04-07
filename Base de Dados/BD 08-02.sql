-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema frotas
--

CREATE DATABASE IF NOT EXISTS frotas;
USE frotas;

--
-- Definition of table `cidade`
--

DROP TABLE IF EXISTS `cidade`;
CREATE TABLE `cidade` (
  `CodCi` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) default NULL,
  `Codpais` int(11) default NULL,
  PRIMARY KEY  (`CodCi`),
  KEY `Codpais` (`Codpais`),
  CONSTRAINT `cidade_ibfk_1` FOREIGN KEY (`Codpais`) REFERENCES `pais` (`Codpais`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cidade`
--

/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;
/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;


--
-- Definition of table `fornecedores`
--

DROP TABLE IF EXISTS `fornecedores`;
CREATE TABLE `fornecedores` (
  `CodForn` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  `Rua` varchar(200) default NULL,
  `N_Telemovel` int(11) default NULL,
  `N_Telefone` int(11) default NULL,
  `site` varchar(50) default NULL,
  `email` varchar(100) default NULL,
  `CodTipoF` int(11) default NULL,
  `CodCi` int(11) default NULL,
  PRIMARY KEY  (`CodForn`),
  KEY `CodTipoF` (`CodTipoF`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `fornecedores_ibfk_1` FOREIGN KEY (`CodTipoF`) REFERENCES `tipofor` (`CodTipoF`),
  CONSTRAINT `fornecedores_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fornecedores`
--

/*!40000 ALTER TABLE `fornecedores` DISABLE KEYS */;
/*!40000 ALTER TABLE `fornecedores` ENABLE KEYS */;


--
-- Definition of table `manutencao`
--

DROP TABLE IF EXISTS `manutencao`;
CREATE TABLE `manutencao` (
  `CodManu` int(11) NOT NULL auto_increment,
  `Data_Efetuada` date default NULL,
  `Veiculo_Km` int(11) default NULL,
  `Valor` int(11) default NULL,
  `Nota` varchar(500) default NULL,
  `CodVei` int(11) default NULL,
  `CodTipoM` int(11) default NULL,
  `CodForn` int(11) default NULL,
  PRIMARY KEY  (`CodManu`),
  KEY `CodVei` (`CodVei`),
  KEY `CodTipoM` (`CodTipoM`),
  KEY `CodForn` (`CodForn`),
  CONSTRAINT `manutencao_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `manutencao_ibfk_2` FOREIGN KEY (`CodTipoM`) REFERENCES `tipomanu` (`CodTipoM`),
  CONSTRAINT `manutencao_ibfk_3` FOREIGN KEY (`CodForn`) REFERENCES `fornecedores` (`CodForn`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manutencao`
--

/*!40000 ALTER TABLE `manutencao` DISABLE KEYS */;
/*!40000 ALTER TABLE `manutencao` ENABLE KEYS */;


--
-- Definition of table `pais`
--

DROP TABLE IF EXISTS `pais`;
CREATE TABLE `pais` (
  `Codpais` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) default NULL,
  PRIMARY KEY  (`Codpais`)
) ENGINE=InnoDB AUTO_INCREMENT=253 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pais`
--

/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
INSERT INTO `pais` (`Codpais`,`Nome`) VALUES 
 (1,'Afeganistão'),
 (2,'África do Sul'),
 (3,'Albânia'),
 (4,'Alderney'),
 (5,'Alemanha'),
 (6,'Andorra'),
 (7,'Angola'),
 (8,'Anguilla'),
 (9,'Antártida'),
 (10,'Antígua e Barbuda'),
 (11,'Antilhas Holandesas'),
 (12,'Arábia Saudita'),
 (13,'Argélia'),
 (14,'Argentina'),
 (15,'Armênia'),
 (16,'Aruba'),
 (17,'Austrália'),
 (18,'Áustria'),
 (19,'Azerbaijão'),
 (20,'Bahamas'),
 (21,'Bahrein'),
 (22,'Bangladesh'),
 (23,'Barbados'),
 (24,'Belarus'),
 (25,'Bélgica'),
 (26,'Belize'),
 (27,'Benin'),
 (28,'Bermudas'),
 (29,'Bolívia'),
 (30,'Bósnia-Herzegóvina'),
 (31,'Botsuana'),
 (32,'Brasil'),
 (33,'Brunei'),
 (34,'Bulgária'),
 (35,'Burkina Fasso'),
 (36,'Burundi'),
 (37,'Butão'),
 (38,'Cabo Verde'),
 (39,'Camarões'),
 (40,'Camboja'),
 (41,'Canadá'),
 (42,'Cazaquistão'),
 (43,'Chade'),
 (44,'Chile'),
 (45,'China'),
 (46,'Chipre'),
 (47,'Cingapura'),
 (48,'Colômbia'),
 (49,'Congo'),
 (50,'Coréia do Norte'),
 (51,'Coréia do Sul'),
 (52,'Costa do Marfim'),
 (53,'Costa Rica'),
 (54,'Croácia (Hrvatska)'),
 (55,'Cuba'),
 (56,'Dinamarca'),
 (57,'Djibuti'),
 (58,'Dominica'),
 (59,'Egito'),
 (60,'El Salvador'),
 (61,'Emirados Árabes Unidos'),
 (62,'Equador'),
 (63,'Eritréia'),
 (64,'Eslováquia'),
 (65,'Eslovênia'),
 (66,'Espanha'),
 (67,'Estados Unidos'),
 (68,'Estônia'),
 (69,'Etiópia'),
 (70,'Federação Russa'),
 (71,'Fiji'),
 (72,'Filipinas'),
 (73,'Finlândia'),
 (74,'França'),
 (75,'Gabão'),
 (76,'Gâmbia'),
 (77,'Gana'),
 (78,'Geórgia'),
 (79,'Gibraltar'),
 (80,'Grã-Bretanha (Reino Unido)'),
 (81,'Granada'),
 (82,'Grécia'),
 (83,'Groelândia'),
 (84,'Guadalupe'),
 (85,'Guam (Território dos Estados Unidos)'),
 (86,'Guatemala'),
 (87,'Guernsey'),
 (88,'Guiana'),
 (89,'Guiana Francesa'),
 (90,'Guiné'),
 (91,'Guiné Equatorial'),
 (92,'Guiné-Bissau'),
 (93,'Haiti'),
 (94,'Holanda'),
 (95,'Honduras'),
 (96,'Hong Kong'),
 (97,'Hungria'),
 (98,'Iêmen'),
 (99,'Ilha Bouvet (Território da Noruega)'),
 (100,'Ilha de Ascensão'),
 (101,'Ilha do Homem'),
 (102,'Ilha Natal'),
 (103,'Ilha Pitcairn'),
 (104,'Ilha Reunião'),
 (105,'Ilhas Aland'),
 (106,'Ilhas Cayman'),
 (107,'Ilhas Cocos'),
 (108,'Ilhas Comores'),
 (109,'Ilhas Cook'),
 (110,'Ilhas do Canal'),
 (111,'Ilhas Falkland (Malvinas)'),
 (112,'Ilhas Faroes'),
 (113,'Ilhas Geórgia do Sul e Sandwich do Sul'),
 (114,'Ilhas Heard e McDonald (Território da Austrália)'),
 (115,'Ilhas Marianas do Norte'),
 (116,'Ilhas Marshall'),
 (117,'Ilhas Menores dos Estados Unidos'),
 (118,'Ilhas Norfolk'),
 (119,'Ilhas Seychelles'),
 (120,'Ilhas Solomão'),
 (121,'Ilhas Svalbard e Jan Mayen'),
 (122,'Ilhas Tokelau'),
 (123,'Ilhas Turks e Caicos'),
 (124,'Ilhas Virgens (Estados Unidos)'),
 (125,'Ilhas Virgens (Inglaterra)'),
 (126,'Ilhas Wallis e Futuna'),
 (127,'Índia'),
 (128,'Indonésia'),
 (129,'Irã'),
 (130,'Iraque'),
 (131,'Irlanda'),
 (132,'Islândia'),
 (133,'Israel'),
 (134,'Itália'),
 (135,'Jamaica'),
 (136,'Japão'),
 (137,'Jersey'),
 (138,'Jordânia'),
 (139,'Kênia'),
 (140,'Kiribati'),
 (141,'Kuait'),
 (142,'Kyrgyzstan'),
 (143,'Laos'),
 (144,'Látvia'),
 (145,'Lesoto'),
 (146,'Líbano'),
 (147,'Libéria'),
 (148,'Líbia'),
 (149,'Liechtenstein'),
 (150,'Lituânia'),
 (151,'Luxemburgo'),
 (152,'Macau'),
 (153,'Macedônia (República Yugoslava)'),
 (154,'Madagascar'),
 (155,'Malásia'),
 (156,'Malaui'),
 (157,'Maldivas'),
 (158,'Mali'),
 (159,'Malta'),
 (160,'Marrocos'),
 (161,'Martinica'),
 (162,'Maurício'),
 (163,'Mauritânia'),
 (164,'Mayotte'),
 (165,'Mexico'),
 (166,'Micronésia'),
 (167,'Moçambique'),
 (168,'Moldova'),
 (169,'Mônaco'),
 (170,'Mongólia'),
 (171,'Montenegro'),
 (172,'Montserrat'),
 (173,'Myanma (Ex-Burma)'),
 (174,'Namíbia'),
 (175,'Nauru'),
 (176,'Nepal'),
 (177,'Nicarágua'),
 (178,'Níger'),
 (179,'Nigéria'),
 (180,'Niue'),
 (181,'Noruega'),
 (182,'Nova Caledônia'),
 (183,'Nova Zelândia'),
 (184,'Omã'),
 (185,'Palau'),
 (186,'Panamá'),
 (187,'Papua-Nova Guiné'),
 (188,'Paquistão'),
 (189,'Paraguai'),
 (190,'Peru'),
 (191,'Polinésia Francesa'),
 (192,'Polônia'),
 (193,'Porto Rico'),
 (194,'Portugal'),
 (195,'Qatar'),
 (196,'Reino da Jugoslávia'),
 (197,'República Centro-Africana'),
 (198,'República Democrática do Congo (ex-Zaire)'),
 (199,'República Dominicana'),
 (200,'República Tcheca'),
 (201,'Romênia'),
 (202,'Ruanda'),
 (203,'Saara Ocidental (Ex-Spanish Sahara)'),
 (204,'Saint Vincente e Granadinas'),
 (205,'Samoa Americana'),
 (206,'Samoa Ocidental'),
 (207,'San Marino'),
 (208,'Santa Helena'),
 (209,'Santa Lúcia'),
 (210,'São Bartolomeu'),
 (211,'São Cristóvão e Névis'),
 (212,'São Martim'),
 (213,'São Tomé e Príncipe'),
 (214,'Senegal'),
 (215,'Serra Leoa'),
 (216,'Sérvia'),
 (217,'Síria'),
 (218,'Somália'),
 (219,'Sri Lanka'),
 (220,'St. Pierre and Miquelon'),
 (221,'Suazilândia'),
 (222,'Sudão'),
 (223,'Suécia'),
 (224,'Suíça'),
 (225,'Suriname'),
 (226,'Tadjiquistão'),
 (227,'Tailândia'),
 (228,'Taiwan'),
 (229,'Tanganica'),
 (230,'Tanzânia'),
 (231,'Território Britânico do Oceano índico'),
 (232,'Territórios do Sul da França'),
 (233,'Territórios Palestinos Ocupados'),
 (234,'Timor Leste (Ex-East Timor)'),
 (235,'Togo'),
 (236,'Tonga'),
 (237,'Trinidad and Tobago'),
 (238,'Tunísia'),
 (239,'Turcomenistão'),
 (240,'Turquia'),
 (241,'Tuvalu'),
 (242,'Ucrânia'),
 (243,'Uganda'),
 (244,'Uruguai'),
 (245,'Uzbequistão'),
 (246,'Vanuatu'),
 (247,'Vaticano'),
 (248,'Venezuela'),
 (249,'Vietnam'),
 (250,'Zâmbia'),
 (251,'Zanzibar					'),
 (252,'Zimbábue');
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;


--
-- Definition of table `tipocom`
--

DROP TABLE IF EXISTS `tipocom`;
CREATE TABLE `tipocom` (
  `CodTipoC` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  `designacao` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoC`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipocom`
--

/*!40000 ALTER TABLE `tipocom` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipocom` ENABLE KEYS */;


--
-- Definition of table `tipodesp`
--

DROP TABLE IF EXISTS `tipodesp`;
CREATE TABLE `tipodesp` (
  `CodTipoD` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoD`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipodesp`
--

/*!40000 ALTER TABLE `tipodesp` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipodesp` ENABLE KEYS */;


--
-- Definition of table `tipofor`
--

DROP TABLE IF EXISTS `tipofor`;
CREATE TABLE `tipofor` (
  `CodTipoF` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipofor`
--

/*!40000 ALTER TABLE `tipofor` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipofor` ENABLE KEYS */;


--
-- Definition of table `tipomanu`
--

DROP TABLE IF EXISTS `tipomanu`;
CREATE TABLE `tipomanu` (
  `CodTipoM` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoM`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipomanu`
--

/*!40000 ALTER TABLE `tipomanu` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipomanu` ENABLE KEYS */;


--
-- Definition of table `tipouser`
--

DROP TABLE IF EXISTS `tipouser`;
CREATE TABLE `tipouser` (
  `CodTipoU` int(11) NOT NULL auto_increment,
  `designacao` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoU`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipouser`
--

/*!40000 ALTER TABLE `tipouser` DISABLE KEYS */;
INSERT INTO `tipouser` (`CodTipoU`,`designacao`) VALUES 
 (1,'Admin'),
 (2,'Guest'),
 (3,'Funcinario Low'),
 (4,'Funcionario High');
/*!40000 ALTER TABLE `tipouser` ENABLE KEYS */;


--
-- Definition of table `tipovei`
--

DROP TABLE IF EXISTS `tipovei`;
CREATE TABLE `tipovei` (
  `CodTipoV` int(11) NOT NULL auto_increment,
  `nome` varchar(50) default NULL,
  PRIMARY KEY  (`CodTipoV`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipovei`
--

/*!40000 ALTER TABLE `tipovei` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipovei` ENABLE KEYS */;


--
-- Definition of table `utilizador`
--

DROP TABLE IF EXISTS `utilizador`;
CREATE TABLE `utilizador` (
  `CodUser` int(11) NOT NULL auto_increment,
  `Nome_Registo` varchar(50) default NULL,
  `Senha` varchar(256) default NULL,
  `Nome_Proprio` varchar(100) default NULL,
  `Apelido` varchar(100) default NULL,
  `Genero` varchar(50) default NULL,
  `Data_Nascimento` date default NULL,
  `Data_Contratacao` date default NULL,
  `Pagamentos_Hora` varchar(50) default NULL,
  `Habilitacoes` varchar(50) default NULL,
  `Rua` varchar(200) default NULL,
  `N_Telemovel` int(11) default NULL,
  `N_Telefone` int(11) default NULL,
  `Email` varchar(100) default NULL,
  `Notas_contacto` varchar(500) default NULL,
  `Notas_Contracto` varchar(500) default NULL,
  `CodTipoU` int(11) default '2',
  `CodCi` int(11) default NULL,
  PRIMARY KEY  (`CodUser`),
  KEY `CodTipoU` (`CodTipoU`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `utilizador_ibfk_1` FOREIGN KEY (`CodTipoU`) REFERENCES `tipouser` (`CodTipoU`),
  CONSTRAINT `utilizador_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `utilizador`
--

/*!40000 ALTER TABLE `utilizador` DISABLE KEYS */;
INSERT INTO `utilizador` (`CodUser`,`Nome_Registo`,`Senha`,`Nome_Proprio`,`Apelido`,`Genero`,`Data_Nascimento`,`Data_Contratacao`,`Pagamentos_Hora`,`Habilitacoes`,`Rua`,`N_Telemovel`,`N_Telefone`,`Email`,`Notas_contacto`,`Notas_Contracto`,`CodTipoU`,`CodCi`) VALUES 
 (1,'Admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'admin@admin.com',NULL,NULL,1,NULL),
 (2,'bypedro','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'bypedro12@hotmail.com',NULL,NULL,2,NULL),
 (3,'Pedro2','fa611d6568e240efffb79b33f04f0d17460e49feab5c95ca6acc0c600966cdad',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'bypedro1@hotmail.com',NULL,NULL,2,NULL);
/*!40000 ALTER TABLE `utilizador` ENABLE KEYS */;


--
-- Definition of table `veiabast`
--

DROP TABLE IF EXISTS `veiabast`;
CREATE TABLE `veiabast` (
  `CodVeiAbast` int(11) NOT NULL auto_increment,
  `Data` date default NULL,
  `Veiculo_Km` int(11) default NULL,
  `Quantidade` int(11) default NULL,
  `Valor` int(11) default NULL,
  `Notas` varchar(500) default NULL,
  `CodVei` int(11) default NULL,
  `CodForn` int(11) default NULL,
  `CodUser` int(11) default NULL,
  PRIMARY KEY  (`CodVeiAbast`),
  KEY `CodVei` (`CodVei`),
  KEY `CodForn` (`CodForn`),
  KEY `CodUser` (`CodUser`),
  CONSTRAINT `veiabast_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `veiabast_ibfk_2` FOREIGN KEY (`CodForn`) REFERENCES `fornecedores` (`CodForn`),
  CONSTRAINT `veiabast_ibfk_3` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `veiabast`
--

/*!40000 ALTER TABLE `veiabast` DISABLE KEYS */;
/*!40000 ALTER TABLE `veiabast` ENABLE KEYS */;


--
-- Definition of table `veiacid`
--

DROP TABLE IF EXISTS `veiacid`;
CREATE TABLE `veiacid` (
  `CodAcid` int(11) NOT NULL,
  `Data_Acidente` date default NULL,
  `Notas` varchar(500) default NULL,
  `CodVei` int(11) default NULL,
  `CodUser` int(11) default NULL,
  PRIMARY KEY  (`CodAcid`),
  KEY `CodVei` (`CodVei`),
  KEY `CodUser` (`CodUser`),
  CONSTRAINT `veiacid_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `veiacid_ibfk_2` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `veiacid`
--

/*!40000 ALTER TABLE `veiacid` DISABLE KEYS */;
/*!40000 ALTER TABLE `veiacid` ENABLE KEYS */;


--
-- Definition of table `veicondu`
--

DROP TABLE IF EXISTS `veicondu`;
CREATE TABLE `veicondu` (
  `CodVeiC` int(11) NOT NULL auto_increment,
  `Notas` varchar(500) default NULL,
  `Quando_Comecou` date default NULL,
  `Quando_Acabou` date default NULL,
  `CodUser` int(11) default NULL,
  `CodVei` int(11) default NULL,
  PRIMARY KEY  (`CodVeiC`),
  KEY `CodUser` (`CodUser`),
  KEY `CodVei` (`CodVei`),
  CONSTRAINT `veicondu_ibfk_1` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`),
  CONSTRAINT `veicondu_ibfk_2` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `veicondu`
--

/*!40000 ALTER TABLE `veicondu` DISABLE KEYS */;
/*!40000 ALTER TABLE `veicondu` ENABLE KEYS */;


--
-- Definition of table `veiculos`
--

DROP TABLE IF EXISTS `veiculos`;
CREATE TABLE `veiculos` (
  `codVei` int(11) NOT NULL auto_increment,
  `Matricula` varchar(50) default NULL,
  `Marca` varchar(50) default NULL,
  `Modelo` varchar(50) default NULL,
  `cor` varchar(50) default NULL,
  `Ano` int(11) default NULL,
  `Proxima_Inspecao` date default NULL,
  `Ultima_Inspecao` date default NULL,
  `CodTipoC` int(11) default NULL,
  `CodTipoV` int(11) default NULL,
  PRIMARY KEY  (`codVei`),
  KEY `CodTipoC` (`CodTipoC`),
  KEY `CodTipoV` (`CodTipoV`),
  CONSTRAINT `veiculos_ibfk_1` FOREIGN KEY (`CodTipoC`) REFERENCES `tipocom` (`CodTipoC`),
  CONSTRAINT `veiculos_ibfk_2` FOREIGN KEY (`CodTipoV`) REFERENCES `tipovei` (`CodTipoV`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `veiculos`
--

/*!40000 ALTER TABLE `veiculos` DISABLE KEYS */;
/*!40000 ALTER TABLE `veiculos` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
