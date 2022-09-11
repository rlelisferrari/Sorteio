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
