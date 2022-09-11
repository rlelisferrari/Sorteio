SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE TABLE `combinacoes` (
  `id_loteria` int(11) NOT NULL,
  `extracao_loteria` varchar(380) NOT NULL,
  `loteria_loteria` varchar(380) NOT NULL,
  `data_loteria` DateTime NOT NULL,
  `resultado1_loteria` varchar(380) DEFAULT NULL,
  `resultado2_loteria` varchar(380) DEFAULT NULL,
  `resultado3_loteria` varchar(380) DEFAULT NULL,
  `resultado4_loteria` varchar(380) DEFAULT NULL,
  `resultado5_loteria` varchar(380) DEFAULT NULL,
  `combinacao1` varchar(380) DEFAULT NULL,
  `combinacao2` varchar(380) DEFAULT NULL,
  `combinacao3` varchar(380) DEFAULT NULL,
  `combinacao4` varchar(380) DEFAULT NULL,
  `combinacao5` varchar(380) DEFAULT NULL,
  `combinacao6` varchar(380) DEFAULT NULL,
  `combinacao7` varchar(380) DEFAULT NULL,
  `combinacao8` varchar(380) DEFAULT NULL,
  `combinacao9` varchar(380) DEFAULT NULL,
  `combinacao10` varchar(380) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='TABELA COMBINAÇÕES';

ALTER TABLE `combinacoes`
  ADD PRIMARY KEY (`id_loteria`);

ALTER TABLE `combinacoes`
  MODIFY `id_loteria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;
