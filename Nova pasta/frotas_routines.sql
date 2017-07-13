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
-- Temporary view structure for view `valormaxbycodveiabast`
--

DROP TABLE IF EXISTS `valormaxbycodveiabast`;
/*!50001 DROP VIEW IF EXISTS `valormaxbycodveiabast`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `valormaxbycodveiabast` AS SELECT 
 1 AS `Codvei`,
 1 AS `CodUser`,
 1 AS `valor`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `veiculomaiorcusto`
--

DROP TABLE IF EXISTS `veiculomaiorcusto`;
/*!50001 DROP VIEW IF EXISTS `veiculomaiorcusto`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `veiculomaiorcusto` AS SELECT 
 1 AS `valor`,
 1 AS `Codvei`,
 1 AS `Veiculo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `valormaxbycodveidesp`
--

DROP TABLE IF EXISTS `valormaxbycodveidesp`;
/*!50001 DROP VIEW IF EXISTS `valormaxbycodveidesp`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `valormaxbycodveidesp` AS SELECT 
 1 AS `Codvei`,
 1 AS `CodUser`,
 1 AS `valor`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `maxbysumvei`
--

DROP TABLE IF EXISTS `maxbysumvei`;
/*!50001 DROP VIEW IF EXISTS `maxbysumvei`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `maxbysumvei` AS SELECT 
 1 AS `valor`,
 1 AS `codVei`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `maxbysumuser`
--

DROP TABLE IF EXISTS `maxbysumuser`;
/*!50001 DROP VIEW IF EXISTS `maxbysumuser`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `maxbysumuser` AS SELECT 
 1 AS `valor`,
 1 AS `CodUser`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `valorbycods`
--

DROP TABLE IF EXISTS `valorbycods`;
/*!50001 DROP VIEW IF EXISTS `valorbycods`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `valorbycods` AS SELECT 
 1 AS `Cod`,
 1 AS `Valor`,
 1 AS `CodUser`,
 1 AS `CodVei`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `valormaxbycodveimanu`
--

DROP TABLE IF EXISTS `valormaxbycodveimanu`;
/*!50001 DROP VIEW IF EXISTS `valormaxbycodveimanu`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `valormaxbycodveimanu` AS SELECT 
 1 AS `Codvei`,
 1 AS `CodUser`,
 1 AS `valor`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `utilizadormaiorvalor`
--

DROP TABLE IF EXISTS `utilizadormaiorvalor`;
/*!50001 DROP VIEW IF EXISTS `utilizadormaiorvalor`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `utilizadormaiorvalor` AS SELECT 
 1 AS `valor`,
 1 AS `coduser`,
 1 AS `Utilizador`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `valormaxbycodveiabast`
--

/*!50001 DROP VIEW IF EXISTS `valormaxbycodveiabast`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `valormaxbycodveiabast` AS select `veiabast`.`CodVei` AS `Codvei`,`veiabast`.`CodUser` AS `CodUser`,sum(`veiabast`.`Valor`) AS `valor` from `veiabast` group by `veiabast`.`CodVei` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `veiculomaiorcusto`
--

/*!50001 DROP VIEW IF EXISTS `veiculomaiorcusto`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `veiculomaiorcusto` AS select `t`.`valor` AS `valor`,`t`.`codVei` AS `Codvei`,concat(`frotas`.`veiculos`.`Marca`,' ',`frotas`.`veiculos`.`Modelo`,' ',`frotas`.`veiculos`.`Ano`,' ',`frotas`.`veiculos`.`Matricula`) AS `Veiculo` from (`frotas`.`veiculos` join (select sum(`valorbycods`.`Valor`) AS `valor`,`valorbycods`.`CodVei` AS `codVei` from `frotas`.`valorbycods` group by `valorbycods`.`CodVei`) `t`) where (`t`.`codVei` = `frotas`.`veiculos`.`codVei`) order by `t`.`valor` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `valormaxbycodveidesp`
--

/*!50001 DROP VIEW IF EXISTS `valormaxbycodveidesp`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `valormaxbycodveidesp` AS select `despesas`.`codVei` AS `Codvei`,`despesas`.`CodUser` AS `CodUser`,sum(`despesas`.`Valor`) AS `valor` from `despesas` group by `despesas`.`codVei` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `maxbysumvei`
--

/*!50001 DROP VIEW IF EXISTS `maxbysumvei`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `maxbysumvei` AS select sum(`valorbycods`.`Valor`) AS `valor`,`valorbycods`.`CodVei` AS `codVei` from `valorbycods` group by `valorbycods`.`CodVei` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `maxbysumuser`
--

/*!50001 DROP VIEW IF EXISTS `maxbysumuser`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `maxbysumuser` AS select sum(`valorbycods`.`Valor`) AS `valor`,`valorbycods`.`CodUser` AS `CodUser` from `valorbycods` group by `valorbycods`.`CodUser` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `valorbycods`
--

/*!50001 DROP VIEW IF EXISTS `valorbycods`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `valorbycods` AS select `despesas`.`CodDesp` AS `Cod`,`despesas`.`Valor` AS `Valor`,`despesas`.`CodUser` AS `CodUser`,`despesas`.`codVei` AS `CodVei` from `despesas` union all select `manutencao`.`CodManu` AS `Cod`,`manutencao`.`Valor` AS `Valor`,`manutencao`.`CodUser` AS `CodUser`,`manutencao`.`CodVei` AS `Codvei` from `manutencao` union all select `veiabast`.`CodVeiAbast` AS `Cod`,`veiabast`.`Valor` AS `Valor`,`veiabast`.`CodUser` AS `CodUser`,`veiabast`.`CodVei` AS `CodVei` from `veiabast` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `valormaxbycodveimanu`
--

/*!50001 DROP VIEW IF EXISTS `valormaxbycodveimanu`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `valormaxbycodveimanu` AS select `manutencao`.`CodVei` AS `Codvei`,`manutencao`.`CodUser` AS `CodUser`,sum(`manutencao`.`Valor`) AS `valor` from `manutencao` group by `manutencao`.`CodVei` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `utilizadormaiorvalor`
--

/*!50001 DROP VIEW IF EXISTS `utilizadormaiorvalor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `utilizadormaiorvalor` AS select `maxbysumuser`.`valor` AS `valor`,`maxbysumuser`.`CodUser` AS `coduser`,concat(`utilizador`.`Nome_Proprio`,' ',`utilizador`.`Apelido`) AS `Utilizador` from (`maxbysumuser` join `utilizador`) where (`utilizador`.`CodUser` = `maxbysumuser`.`CodUser`) order by `maxbysumuser`.`valor` desc limit 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-13 16:25:03
