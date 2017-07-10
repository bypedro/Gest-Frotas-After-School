-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               5.7.14 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for frotas
CREATE DATABASE IF NOT EXISTS `frotas` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `frotas`;

-- Dumping structure for table frotas.cidade
CREATE TABLE IF NOT EXISTS `cidade` (
  `CodCi` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  `Codpais` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodCi`),
  KEY `Codpais` (`Codpais`),
  CONSTRAINT `cidade_ibfk_1` FOREIGN KEY (`Codpais`) REFERENCES `pais` (`Codpais`)
) ENGINE=InnoDB AUTO_INCREMENT=160 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.despesas
CREATE TABLE IF NOT EXISTS `despesas` (
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.fornecedores
CREATE TABLE IF NOT EXISTS `fornecedores` (
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

-- Data exporting was unselected.
-- Dumping structure for table frotas.manutencao
CREATE TABLE IF NOT EXISTS `manutencao` (
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for view frotas.maxbysumuser
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `maxbysumuser` (
	`valor` DECIMAL(32,0) NULL,
	`CodUser` INT(11) NULL
) ENGINE=MyISAM;

-- Dumping structure for view frotas.maxbysumvei
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `maxbysumvei` (
	`valor` DECIMAL(32,0) NULL,
	`codVei` INT(11) NULL
) ENGINE=MyISAM;

-- Dumping structure for table frotas.pais
CREATE TABLE IF NOT EXISTS `pais` (
  `Codpais` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Codpais`)
) ENGINE=InnoDB AUTO_INCREMENT=253 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.photos
CREATE TABLE IF NOT EXISTS `photos` (
  `Codi` int(11) NOT NULL AUTO_INCREMENT,
  `location` varchar(100) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`Codi`),
  KEY `CodUser` (`CodUser`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipocom
CREATE TABLE IF NOT EXISTS `tipocom` (
  `CodTipoC` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `designacao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoC`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipodesp
CREATE TABLE IF NOT EXISTS `tipodesp` (
  `CodTipoD` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoD`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipofor
CREATE TABLE IF NOT EXISTS `tipofor` (
  `CodTipoF` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `teste` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodTipoF`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipomanu
CREATE TABLE IF NOT EXISTS `tipomanu` (
  `CodTipoM` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoM`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipouser
CREATE TABLE IF NOT EXISTS `tipouser` (
  `CodTipoU` int(11) NOT NULL AUTO_INCREMENT,
  `designacao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoU`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.tipovei
CREATE TABLE IF NOT EXISTS `tipovei` (
  `CodTipoV` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CodTipoV`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.utilizador
CREATE TABLE IF NOT EXISTS `utilizador` (
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
  `N_Telemovel` int(10) unsigned zerofill DEFAULT NULL,
  `N_Telefone` int(10) unsigned zerofill DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Notas_contacto` varchar(500) DEFAULT NULL,
  `Notas_Contracto` varchar(500) DEFAULT NULL,
  `CodTipoU` int(11) DEFAULT '2',
  `CodCi` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodUser`),
  KEY `CodTipoU` (`CodTipoU`),
  KEY `CodCi` (`CodCi`),
  CONSTRAINT `utilizador_ibfk_1` FOREIGN KEY (`CodTipoU`) REFERENCES `tipouser` (`CodTipoU`),
  CONSTRAINT `utilizador_ibfk_2` FOREIGN KEY (`CodCi`) REFERENCES `cidade` (`CodCi`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for view frotas.valorbycods
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `valorbycods` (
	`Cod` INT(11) NOT NULL,
	`Valor` INT(11) NULL,
	`CodUser` INT(11) NULL,
	`CodVei` INT(11) NULL
) ENGINE=MyISAM;

-- Dumping structure for view frotas.valormaxbycodveiabast
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `valormaxbycodveiabast` (
	`Codvei` INT(11) NULL,
	`CodUser` INT(11) NULL,
	`valor` DECIMAL(32,0) NULL
) ENGINE=MyISAM;

-- Dumping structure for view frotas.valormaxbycodveidesp
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `valormaxbycodveidesp` (
	`Codvei` INT(11) NULL,
	`CodUser` INT(11) NULL,
	`valor` DECIMAL(32,0) NULL
) ENGINE=MyISAM;

-- Dumping structure for view frotas.valormaxbycodveimanu
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `valormaxbycodveimanu` (
	`Codvei` INT(11) NULL,
	`CodUser` INT(11) NULL,
	`valor` DECIMAL(32,0) NULL
) ENGINE=MyISAM;

-- Dumping structure for table frotas.veiabast
CREATE TABLE IF NOT EXISTS `veiabast` (
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
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.veiacid
CREATE TABLE IF NOT EXISTS `veiacid` (
  `CodAcid` int(11) NOT NULL AUTO_INCREMENT,
  `Data_Acidente` date DEFAULT NULL,
  `Notas` varchar(500) DEFAULT NULL,
  `CodVei` int(11) DEFAULT NULL,
  `CodUser` int(11) DEFAULT NULL,
  PRIMARY KEY (`CodAcid`),
  KEY `CodVei` (`CodVei`),
  KEY `CodUser` (`CodUser`),
  CONSTRAINT `veiacid_ibfk_1` FOREIGN KEY (`CodVei`) REFERENCES `veiculos` (`codVei`),
  CONSTRAINT `veiacid_ibfk_2` FOREIGN KEY (`CodUser`) REFERENCES `utilizador` (`CodUser`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.veicondu
CREATE TABLE IF NOT EXISTS `veicondu` (
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table frotas.veiculos
CREATE TABLE IF NOT EXISTS `veiculos` (
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for view frotas.maxbysumuser
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `maxbysumuser`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `maxbysumuser` AS select sum(`valorbycods`.`Valor`) AS `valor`,`valorbycods`.`CodUser` AS `CodUser` from `valorbycods` group by `valorbycods`.`CodUser`;

-- Dumping structure for view frotas.maxbysumvei
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `maxbysumvei`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `maxbysumvei` AS select sum(`valorbycods`.`Valor`) AS `valor`,`valorbycods`.`CodVei` AS `codVei` from `valorbycods` group by `valorbycods`.`CodVei`;

-- Dumping structure for view frotas.valorbycods
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `valorbycods`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `valorbycods` AS select `despesas`.`CodDesp` AS `Cod`,`despesas`.`Valor` AS `Valor`,`despesas`.`CodUser` AS `CodUser`,`despesas`.`codVei` AS `CodVei` from `despesas` union all select `manutencao`.`CodManu` AS `Cod`,`manutencao`.`Valor` AS `Valor`,`manutencao`.`CodUser` AS `CodUser`,`manutencao`.`CodVei` AS `Codvei` from `manutencao` union all select `veiabast`.`CodVeiAbast` AS `Cod`,`veiabast`.`Valor` AS `Valor`,`veiabast`.`CodUser` AS `CodUser`,`veiabast`.`CodVei` AS `CodVei` from `veiabast`;

-- Dumping structure for view frotas.valormaxbycodveiabast
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `valormaxbycodveiabast`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `valormaxbycodveiabast` AS select `veiabast`.`CodVei` AS `Codvei`,`veiabast`.`CodUser` AS `CodUser`,sum(`veiabast`.`Valor`) AS `valor` from `veiabast` group by `veiabast`.`CodVei`;

-- Dumping structure for view frotas.valormaxbycodveidesp
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `valormaxbycodveidesp`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `valormaxbycodveidesp` AS select `despesas`.`codVei` AS `Codvei`,`despesas`.`CodUser` AS `CodUser`,sum(`despesas`.`Valor`) AS `valor` from `despesas` group by `despesas`.`codVei`;

-- Dumping structure for view frotas.valormaxbycodveimanu
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `valormaxbycodveimanu`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `valormaxbycodveimanu` AS select `manutencao`.`CodVei` AS `Codvei`,`manutencao`.`CodUser` AS `CodUser`,sum(`manutencao`.`Valor`) AS `valor` from `manutencao` group by `manutencao`.`CodVei`;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
