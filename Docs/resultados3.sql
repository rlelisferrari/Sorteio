-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Tempo de geração: 09/09/2022 às 15:44
-- Versão do servidor: 5.7.38-cll-lve
-- Versão do PHP: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `loteria_lotep`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `resultados`
--

CREATE TABLE `resultados` (
  `id_loteria` int(11) NOT NULL,
  `extracao_loteria` varchar(380) NOT NULL,
  `loteria_loteria` varchar(380) NOT NULL,
  `data_loteria` varchar(380) NOT NULL,
  `premio1_loteria` varchar(380) NOT NULL DEFAULT '1º PRÊMIO',
  `logo1_loteria` varchar(360) DEFAULT NULL,
  `resultado1_loteria` varchar(380) DEFAULT NULL,
  `grupo1_loteria` varchar(380) DEFAULT NULL,
  `animal1_loteria` varchar(380) DEFAULT NULL,
  `premio2_loteria` varchar(380) NOT NULL DEFAULT '2º PRÊMIO',
  `logo2_loteria` varchar(360) DEFAULT NULL,
  `resultado2_loteria` varchar(380) DEFAULT NULL,
  `grupo2_loteria` varchar(380) DEFAULT NULL,
  `animal2_loteria` varchar(380) DEFAULT NULL,
  `premio3_loteria` varchar(380) NOT NULL DEFAULT '3º PRÊMIO',
  `logo3_loteria` varchar(360) DEFAULT NULL,
  `resultado3_loteria` varchar(380) DEFAULT NULL,
  `grupo3_loteria` varchar(380) DEFAULT NULL,
  `animal3_loteria` varchar(380) DEFAULT NULL,
  `premio4_loteria` varchar(380) NOT NULL DEFAULT '4º PRÊMIO',
  `logo4_loteria` varchar(360) DEFAULT NULL,
  `resultado4_loteria` varchar(380) DEFAULT NULL,
  `grupo4_loteria` varchar(380) DEFAULT NULL,
  `animal4_loteria` varchar(380) DEFAULT NULL,
  `premio5_loteria` varchar(380) NOT NULL DEFAULT '5º PRÊMIO',
  `logo5_loteria` varchar(360) DEFAULT NULL,
  `resultado5_loteria` varchar(380) DEFAULT NULL,
  `grupo5_loteria` varchar(380) DEFAULT NULL,
  `animal5_loteria` varchar(380) DEFAULT NULL,
  `premio6_loteria` varchar(380) NOT NULL DEFAULT '6º PRÊMIO',
  `logo6_loteria` varchar(360) DEFAULT NULL,
  `resultado6_loteria` varchar(380) DEFAULT NULL,
  `grupo6_loteria` varchar(380) DEFAULT NULL,
  `animal6_loteria` varchar(380) DEFAULT NULL,
  `premio7_loteria` varchar(380) NOT NULL DEFAULT '7º PRÊMIO',
  `logo7_loteria` varchar(360) DEFAULT NULL,
  `resultado7_loteria` varchar(380) DEFAULT NULL,
  `grupo7_loteria` varchar(380) DEFAULT NULL,
  `animal7_loteria` varchar(380) DEFAULT NULL,
  `premio8_loteria` varchar(380) NOT NULL DEFAULT '8º PRÊMIO',
  `logo8_loteria` varchar(360) DEFAULT NULL,
  `resultado8_loteria` varchar(380) DEFAULT NULL,
  `grupo8_loteria` varchar(380) DEFAULT NULL,
  `animal8_loteria` varchar(380) DEFAULT NULL,
  `premio9_loteria` varchar(380) NOT NULL DEFAULT '9º PRÊMIO',
  `logo9_loteria` varchar(360) DEFAULT NULL,
  `resultado9_loteria` varchar(380) DEFAULT NULL,
  `grupo9_loteria` varchar(380) DEFAULT NULL,
  `animal9_loteria` varchar(380) DEFAULT NULL,
  `premio10_loteria` varchar(380) NOT NULL DEFAULT '10º PRÊMIO',
  `logo10_loteria` varchar(360) DEFAULT NULL,
  `resultado10_loteria` varchar(380) DEFAULT NULL,
  `grupo10_loteria` varchar(380) DEFAULT NULL,
  `animal10_loteria` varchar(380) DEFAULT NULL,
  `cod_loteria` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='TABELA RESULTADOS';

--
-- Despejando dados para a tabela `resultados`
--

INSERT INTO `resultados` (`id_loteria`, `extracao_loteria`, `loteria_loteria`, `data_loteria`, `premio1_loteria`, `logo1_loteria`, `resultado1_loteria`, `grupo1_loteria`, `animal1_loteria`, `premio2_loteria`, `logo2_loteria`, `resultado2_loteria`, `grupo2_loteria`, `animal2_loteria`, `premio3_loteria`, `logo3_loteria`, `resultado3_loteria`, `grupo3_loteria`, `animal3_loteria`, `premio4_loteria`, `logo4_loteria`, `resultado4_loteria`, `grupo4_loteria`, `animal4_loteria`, `premio5_loteria`, `logo5_loteria`, `resultado5_loteria`, `grupo5_loteria`, `animal5_loteria`, `premio6_loteria`, `logo6_loteria`, `resultado6_loteria`, `grupo6_loteria`, `animal6_loteria`, `premio7_loteria`, `logo7_loteria`, `resultado7_loteria`, `grupo7_loteria`, `animal7_loteria`, `premio8_loteria`, `logo8_loteria`, `resultado8_loteria`, `grupo8_loteria`, `animal8_loteria`, `premio9_loteria`, `logo9_loteria`, `resultado9_loteria`, `grupo9_loteria`, `animal9_loteria`, `premio10_loteria`, `logo10_loteria`, `resultado10_loteria`, `grupo10_loteria`, `animal10_loteria`, `cod_loteria`) VALUES
(23694, '9:30 AGRESTE', 'AGRESTE', '2022-09-09', '1º PRÊMIO', 'macaco.png', '1168', '17', 'MACACO', '2º PRÊMIO', 'elefante.png', '4645', '12', 'ELEFANTE', '3º PRÊMIO', 'galo.png', '0352', '13', 'GALO', '4º PRÊMIO', 'touro.png', '7984', '21', 'TOURO', '5º PRÊMIO', 'macaco.png', '2766', '17', 'MACACO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 67464),
(23695, '9:30 PB', 'PB', '2022-09-09', '1º PRÊMIO', 'borboleta.png', '7315', '4', 'BORBOLETA', '2º PRÊMIO', 'avestruz.png', '1603', '1', 'AVESTRUZ', '3º PRÊMIO', 'touro.png', '7982', '21', 'TOURO', '4º PRÊMIO', 'galo.png', '5249', '13', 'GALO', '5º PRÊMIO', 'cobra.png', '2936', '9', 'COBRA', '6º PRÊMIO', 'pavao.png', '7175', '19', 'PAVÃƒO', '7º PRÊMIO', 'urso.png', '3692', '23', 'URSO', '8º PRÊMIO', 'touro.png', '1084', '21', 'TOURO', '9º PRÊMIO', 'camelo.png', '5329', '8', 'CAMELO', '10º PRÊMIO', 'macaco.png', '2365', '17', 'MACACO', 73083),
(23696, '9:45 PT PB', 'PT PB', '2022-09-09', '1º PRÊMIO', 'pavao.png', '4176', '19', 'PAVÃƒO', '2º PRÊMIO', 'peru.gif', '2879', '20', 'PERU', '3º PRÊMIO', 'jacare.png', '6560', '15', 'JACARÃ‰', '4º PRÊMIO', 'cavalo.png', '8443', '11', 'CAVALO', '5º PRÊMIO', 'avestruz.png', '1102', '1', 'AVESTRUZ', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 56554),
(23697, '10:30 AGRESTE', 'AGRESTE', '2022-09-09', '1º PRÊMIO', 'peru.gif', '3278', '20', 'PERU', '2º PRÊMIO', 'leao.png', '4862', '16', 'LEÃƒO', '3º PRÊMIO', 'leao.png', '3161', '16', 'LEÃƒO', '4º PRÊMIO', 'aguia.png', '2907', '2', 'ÃGUIA', '5º PRÊMIO', 'burro.png', '3410', '3', 'BURRO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 48674),
(23698, '10:45 LOTEP', 'LOTEP', '2022-09-09', '1º PRÊMIO', 'cobra.png', '9733', '9', 'COBRA', '2º PRÊMIO', 'aguia.png', '3708', '2', 'ÃGUIA', '3º PRÊMIO', 'cabra.png', '4921', '6', 'CABRA', '4º PRÊMIO', 'cavalo.png', '3243', '11', 'CAVALO', '5º PRÊMIO', 'carneiro.png', '5428', '7', 'CARNEIRO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 57120),
(23699, '11:00 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'cachorro.png', '3718', '5', 'CACHORRO', '2º PRÊMIO', 'tigre.png', '2688', '22', 'TIGRE', '3º PRÊMIO', 'cabra.png', '1222', '6', 'CABRA', '4º PRÊMIO', 'macaco.png', '4768', '17', 'MACACO', '5º PRÊMIO', 'coelho.png', '3938', '10', 'COELHO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 12823),
(23700, '11:00 RIO', 'RIO', '2022-09-09', '1º PRÊMIO', 'gato.png', '9953', '14', 'GATO', '2º PRÊMIO', 'borboleta.png', '6615', '4', 'BORBOLETA', '3º PRÊMIO', 'jacare.png', '4559', '15', 'JACARÃ‰', '4º PRÊMIO', 'cabra.png', '9521', '6', 'CABRA', '5º PRÊMIO', 'macaco.png', '5065', '17', 'MACACO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 68155),
(23701, '10:30 LOCAL', 'LOCAL', '2022-09-09', '1º PRÊMIO', 'pavao.png', '9774', '19', 'PAVÃƒO', '2º PRÊMIO', 'leao.png', '9563', '16', 'LEÃƒO', '3º PRÊMIO', 'vaca.png', '2097', '25', 'VACA', '4º PRÊMIO', 'veado.png', '0793', '24', 'VEADO', '5º PRÊMIO', 'burro.png', '6512', '3', 'BURRO', '6º PRÊMIO', 'cachorro.png', '9920', '5', 'CACHORRO', '7º PRÊMIO', 'aguia.png', '7507', '2', 'ÃGUIA', '8º PRÊMIO', 'vaca.png', '7699', '25', 'VACA', '9º PRÊMIO', 'pavao.png', '4373', '19', 'PAVÃƒO', '10º PRÊMIO', 'coelho.png', '8238', '10', 'COELHO', 21971),
(23702, '12hs Local ', 'LOCAL', '2022-09-09', '1º PRÊMIO', 'carneiro.png', '3627', '7', 'CARNEIRO', '2º PRÊMIO', 'borboleta.png', '4816', '4', 'BORBOLETA', '3º PRÊMIO', 'vaca.png', '1297', '25', 'VACA', '4º PRÊMIO', 'cachorro.png', '2020', '5', 'CACHORRO', '5º PRÊMIO', 'veado.png', '5396', '24', 'VEADO', '6º PRÊMIO', 'burro.png', '3412', '3', 'BURRO', '7º PRÊMIO', 'cachorro.png', '6820', '5', 'CACHORRO', '8º PRÊMIO', 'urso.png', '2192', '23', 'URSO', '9º PRÊMIO', 'porco.png', '7670', '18', 'PORCO', '10º PRÊMIO', 'galo.png', '7250', '13', 'GALO', 64519),
(23703, '13:00 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'camelo.png', '7731', '8', 'CAMELO', '2º PRÊMIO', 'porco.png', '1071', '18', 'PORCO', '3º PRÊMIO', 'cobra.png', '1433', '9', 'COBRA', '4º PRÊMIO', 'tigre.png', '1485', '22', 'TIGRE', '5º PRÊMIO', 'touro.png', '6583', '21', 'TOURO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 94095),
(23704, '12:40 AGRESTE', 'AGRESTE', '2022-09-09', '1º PRÊMIO', 'cavalo.png', '9243', '11', 'CAVALO', '2º PRÊMIO', 'burro.png', '0409', '3', 'BURRO', '3º PRÊMIO', 'tigre.png', '6985', '22', 'TIGRE', '4º PRÊMIO', 'coelho.png', '7038', '10', 'COELHO', '5º PRÊMIO', 'cobra.png', '9636', '9', 'COBRA', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 67781),
(23705, '13:00 LOTEP', 'LOTEP', '2022-09-09', '1º PRÊMIO', 'leao.png', '5164', '16', 'LEÃƒO', '2º PRÊMIO', 'borboleta.png', '3314', '4', 'BORBOLETA', '3º PRÊMIO', 'vaca.png', '3199', '25', 'VACA', '4º PRÊMIO', 'porco.png', '9571', '18', 'PORCO', '5º PRÊMIO', 'borboleta.png', '4713', '4', 'BORBOLETA', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 91109),
(23706, '14:00 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'vaca.png', '8598', '25', 'VACA', '2º PRÊMIO', 'avestruz.png', '3302', '1', 'AVESTRUZ', '3º PRÊMIO', 'galo.png', '5451', '13', 'GALO', '4º PRÊMIO', 'cachorro.png', '2418', '5', 'CACHORRO', '5º PRÊMIO', 'aguia.png', '7306', '2', 'ÃGUIA', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 66155),
(23707, '14:00 RIO', 'RIO', '2022-09-09', '1º PRÊMIO', 'avestruz.png', '1904', '1', 'AVESTRUZ', '2º PRÊMIO', 'gato.png', '5655', '14', 'GATO', '3º PRÊMIO', 'porco.png', '6572', '18', 'PORCO', '4º PRÊMIO', 'coelho.png', '9640', '10', 'COELHO', '5º PRÊMIO', 'cabra.png', '4823', '6', 'CABRA', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 80772),
(23708, '16:00 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'tigre.png', '1688', '22', 'TIGRE', '2º PRÊMIO', 'gato.png', '2453', '14', 'GATO', '3º PRÊMIO', 'cavalo.png', '9543', '11', 'CAVALO', '4º PRÊMIO', 'cabra.png', '2921', '6', 'CABRA', '5º PRÊMIO', 'jacare.png', '2160', '15', 'JACARÃ‰', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 49310),
(23709, '15:40 AGRESTE', 'AGRESTE', '2022-09-09', '1º PRÊMIO', 'borboleta.png', '1214', '4', 'BORBOLETA', '2º PRÊMIO', 'leao.png', '2363', '16', 'LEÃƒO', '3º PRÊMIO', 'pavao.png', '6675', '19', 'PAVÃƒO', '4º PRÊMIO', 'urso.png', '3890', '23', 'URSO', '5º PRÊMIO', 'urso.png', '2992', '23', 'URSO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 18505),
(23710, '16:00 LOTEP', 'LOTEP', '2022-09-09', '1º PRÊMIO', 'touro.png', '4384', '21', 'TOURO', '2º PRÊMIO', 'cobra.png', '8636', '9', 'COBRA', '3º PRÊMIO', 'burro.png', '3012', '3', 'BURRO', '4º PRÊMIO', 'carneiro.png', '7626', '7', 'CARNEIRO', '5º PRÊMIO', 'cavalo.png', '4942', '11', 'CAVALO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 88549),
(23711, '16:00 RIO', 'RIO', '2022-09-09', '1º PRÊMIO', 'cabra.png', '8822', '6', 'CABRA', '2º PRÊMIO', 'cachorro.png', '5220', '5', 'CACHORRO', '3º PRÊMIO', 'galo.png', '2652', '13', 'GALO', '4º PRÊMIO', 'cavalo.png', '1642', '11', 'CAVALO', '5º PRÊMIO', 'touro.png', '2482', '21', 'TOURO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 18523),
(23712, '17:00 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'carneiro.png', '7127', '7', 'CARNEIRO', '2º PRÊMIO', 'touro.png', '1284', '21', 'TOURO', '3º PRÊMIO', 'jacare.png', '9560', '15', 'JACARÃ‰', '4º PRÊMIO', 'coelho.png', '1740', '10', 'COELHO', '5º PRÊMIO', 'elefante.png', '8047', '12', 'ELEFANTE', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 15313),
(23713, '18:00 AGRESTE', 'AGRESTE', '2022-09-09', '1º PRÊMIO', 'leao.png', '3861', '16', 'LEÃƒO', '2º PRÊMIO', 'cabra.png', '4421', '6', 'CABRA', '3º PRÊMIO', 'avestruz.png', '9504', '1', 'AVESTRUZ', '4º PRÊMIO', 'galo.png', '2951', '13', 'GALO', '5º PRÊMIO', 'carneiro.png', '3328', '7', 'CARNEIRO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 69317),
(23714, '18:00 LOTEP', 'LOTEP', '2022-09-09', '1º PRÊMIO', 'cabra.png', '6122', '6', 'CABRA', '2º PRÊMIO', 'veado.png', '4194', '24', 'VEADO', '3º PRÊMIO', 'gato.png', '9156', '14', 'GATO', '4º PRÊMIO', 'elefante.png', '5147', '12', 'ELEFANTE', '5º PRÊMIO', 'coelho.png', '7139', '10', 'COELHO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 81452),
(23715, '18hs LOCAL', 'LOCAL', '2022-09-09', '1º PRÊMIO', 'galo.png', '4151', '13', 'GALO', '2º PRÊMIO', 'vaca.png', '2300', '25', 'VACA', '3º PRÊMIO', 'cobra.png', '0936', '9', 'COBRA', '4º PRÊMIO', 'cachorro.png', '7419', '5', 'CACHORRO', '5º PRÊMIO', 'camelo.png', '5230', '8', 'CAMELO', '6º PRÊMIO', 'aguia.png', '4207', '2', 'ÃGUIA', '7º PRÊMIO', 'veado.png', '1394', '24', 'VEADO', '8º PRÊMIO', 'camelo.png', '5031', '8', 'CAMELO', '9º PRÊMIO', 'porco.png', '1069', '18', 'PORCO', '10º PRÊMIO', 'coelho.png', '1737', '10', 'COELHO', 26338),
(23716, '18:00 RIO', 'RIO', '2022-09-09', '1º PRÊMIO', 'pavao.png', '1573', '19', 'PAVÃƒO', '2º PRÊMIO', 'carneiro.png', '0026', '7', 'CARNEIRO', '3º PRÊMIO', 'macaco.png', '0366', '17', 'MACACO', '4º PRÊMIO', 'cobra.png', '4133', '9', 'COBRA', '5º PRÊMIO', 'cavalo.png', '1443', '11', 'CAVALO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 68827),
(23717, '18:30 POPULAR', 'POPULAR', '2022-09-09', '1º PRÊMIO', 'pavao.png', '4573', '19', 'PAVÃƒO', '2º PRÊMIO', 'vaca.png', '7498', '25', 'VACA', '3º PRÊMIO', 'elefante.png', '9246', '12', 'ELEFANTE', '4º PRÊMIO', 'avestruz.png', '4403', '1', 'AVESTRUZ', '5º PRÊMIO', 'cachorro.png', '8520', '5', 'CACHORRO', '6º PRÊMIO', '', '', '', '', '7º PRÊMIO', '', '', '', '', '8º PRÊMIO', '', '', '', '', '9º PRÊMIO', '', '', '', '', '10º PRÊMIO', '', '', '', '', 32423);

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `resultados`
--
ALTER TABLE `resultados`
  ADD PRIMARY KEY (`id_loteria`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `resultados`
--
ALTER TABLE `resultados`
  MODIFY `id_loteria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23718;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
