-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 16/07/2025 às 01:38
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `aluguel2`
--
CREATE DATABASE IF NOT EXISTS `aluguel12` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `aluguel12`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `caracteristica`
--

CREATE TABLE `caracteristica` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `contrato`
--

CREATE TABLE `contrato` (
  `id` int(11) NOT NULL,
  `dataInicio` date DEFAULT NULL,
  `dataFim` date DEFAULT NULL,
  `valorMensal` decimal(10,0) DEFAULT NULL,
  `idInquilino` int(11) DEFAULT NULL,
  `idImovel` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `despesa`
--

CREATE TABLE `despesa` (
  `id` int(11) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `valor` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `imovel`
--

CREATE TABLE `imovel` (
  `id` int(11) NOT NULL,
  `descricao` varchar(255) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `valorAluguel` decimal(10,0) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `imovel_caracteristica`
--

CREATE TABLE `imovel_caracteristica` (
  `idImovel` int(11) NOT NULL,
  `idCaracteristica` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `imovel_despesa`
--

CREATE TABLE `imovel_despesa` (
  `idImovel` int(11) NOT NULL,
  `idDespesa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `inquilino`
--

CREATE TABLE `inquilino` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `cpf` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `telefone` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `receita`
--

CREATE TABLE `receita` (
  `id` int(11) NOT NULL,
  `dataReferencia` date DEFAULT NULL,
  `valor` decimal(10,0) DEFAULT NULL,
  `situacao` varchar(255) DEFAULT NULL,
  `idContrato` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `caracteristica`
--
ALTER TABLE `caracteristica`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idInquilino` (`idInquilino`),
  ADD KEY `idImovel` (`idImovel`);

--
-- Índices de tabela `despesa`
--
ALTER TABLE `despesa`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `imovel`
--
ALTER TABLE `imovel`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `imovel_caracteristica`
--
ALTER TABLE `imovel_caracteristica`
  ADD PRIMARY KEY (`idImovel`,`idCaracteristica`),
  ADD KEY `idCaracteristica` (`idCaracteristica`);

--
-- Índices de tabela `imovel_despesa`
--
ALTER TABLE `imovel_despesa`
  ADD PRIMARY KEY (`idImovel`,`idDespesa`),
  ADD KEY `idDespesa` (`idDespesa`);

--
-- Índices de tabela `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `receita`
--
ALTER TABLE `receita`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idContrato` (`idContrato`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `caracteristica`
--
ALTER TABLE `caracteristica`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `contrato`
--
ALTER TABLE `contrato`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `despesa`
--
ALTER TABLE `despesa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `imovel`
--
ALTER TABLE `imovel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `receita`
--
ALTER TABLE `receita`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`idInquilino`) REFERENCES `inquilino` (`id`),
  ADD CONSTRAINT `contrato_ibfk_2` FOREIGN KEY (`idImovel`) REFERENCES `imovel` (`id`);

--
-- Restrições para tabelas `imovel_caracteristica`
--
ALTER TABLE `imovel_caracteristica`
  ADD CONSTRAINT `imovel_caracteristica_ibfk_1` FOREIGN KEY (`idImovel`) REFERENCES `imovel` (`id`),
  ADD CONSTRAINT `imovel_caracteristica_ibfk_2` FOREIGN KEY (`idCaracteristica`) REFERENCES `caracteristica` (`id`),
  ADD CONSTRAINT `imovel_caracteristica_ibfk_3` FOREIGN KEY (`idCaracteristica`) REFERENCES `imovel_caracteristica` (`idImovel`);

--
-- Restrições para tabelas `imovel_despesa`
--
ALTER TABLE `imovel_despesa`
  ADD CONSTRAINT `imovel_despesa_ibfk_1` FOREIGN KEY (`idImovel`) REFERENCES `imovel` (`id`),
  ADD CONSTRAINT `imovel_despesa_ibfk_2` FOREIGN KEY (`idDespesa`) REFERENCES `despesa` (`id`);

--
-- Restrições para tabelas `receita`
--
ALTER TABLE `receita`
  ADD CONSTRAINT `receita_ibfk_1` FOREIGN KEY (`idContrato`) REFERENCES `contrato` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
