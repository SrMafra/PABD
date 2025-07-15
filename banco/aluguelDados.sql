-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 16/07/2025 às 01:43
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

--
-- Despejando dados para a tabela `caracteristica`
--

INSERT INTO `caracteristica` (`id`, `nome`) VALUES
(1, 'Garagem'),
(2, 'Piscina'),
(3, 'Academia'),
(4, 'Mobiliado'),
(5, 'Permite Animais'),
(6, 'Garagem'),
(7, 'Piscina'),
(8, 'Academia'),
(9, 'Mobiliado'),
(10, 'Permite Animais');

--
-- Despejando dados para a tabela `contrato`
--

INSERT INTO `contrato` (`id`, `dataInicio`, `dataFim`, `valorMensal`, `idInquilino`, `idImovel`) VALUES
(1, '2025-07-15', '2025-07-15', 30000, 1, 1),
(2, '2025-07-15', '2025-07-15', 1500, 1, 2),
(3, '2025-07-15', '2026-07-15', 2500, 2, 2),
(4, '2025-07-15', '2025-07-15', 2500, 2, 1);

--
-- Despejando dados para a tabela `despesa`
--

INSERT INTO `despesa` (`id`, `descricao`, `valor`) VALUES
(1, 'IPTU Anual', 1200),
(2, 'Condomínio Mensal', 350),
(3, 'Taxa de Lixo', 150),
(4, 'Manutenção Predial', 500),
(5, 'IPTU Anual', 1200),
(6, 'Condomínio Mensal', 350),
(7, 'Taxa de Lixo', 150),
(8, 'Manutenção Predial', 500);

--
-- Despejando dados para a tabela `imovel`
--

INSERT INTO `imovel` (`id`, `descricao`, `endereco`, `valorAluguel`, `status`) VALUES
(1, 'Apartamento aconchegante no centro', 'Rua das Flores, 123, Apto 101, Centro, Cidade Exemplo, SP', 1500, 'DISPONÍVEL'),
(2, 'Casa com quintal grande', 'Avenida Principal, 456, Bairro Verde, Cidade Exemplo, RJ', 2500, 'ALUGADO'),
(3, 'Kitnet mobiliada perto da universidade', 'Rua da Paz, 789, Bloco B, Apto 502, Bairro Estudantil, MG', 950, 'DISPONÍVEL'),
(4, 'Apartamento aconchegante no centro', 'Rua das Flores, 123, Apto 101, Centro, Cidade Exemplo, SP', 1500, 'DISPONÍVEL'),
(5, 'Casa com quintal grande', 'Avenida Principal, 456, Bairro Verde, Cidade Exemplo, RJ', 2500, 'ALUGADO'),
(6, 'Kitnet mobiliada perto da universidade', 'Rua da Paz, 789, Bloco B, Apto 502, Bairro Estudantil, MG', 950, 'DISPONÍVEL'),
(7, 'Kitnet mobiliada perto da Igreja', 'Avenida Principal, 456, Bairro Verde, Cidade Exemplo, RJ', 2500, 'DISPONIVEL'),
(9, 'Casa de Praia', 'Leblon RJ', 3500, 'Disponivel');

--
-- Despejando dados para a tabela `imovel_caracteristica`
--

INSERT INTO `imovel_caracteristica` (`idImovel`, `idCaracteristica`) VALUES
(1, 1),
(2, 1),
(2, 2),
(3, 1),
(5, 1),
(5, 5);

--
-- Despejando dados para a tabela `imovel_despesa`
--

INSERT INTO `imovel_despesa` (`idImovel`, `idDespesa`) VALUES
(1, 2),
(2, 1),
(2, 4);

--
-- Despejando dados para a tabela `inquilino`
--

INSERT INTO `inquilino` (`id`, `nome`, `cpf`, `email`, `telefone`) VALUES
(1, 'João Silva', '111.222.333-44', 'joao.silva@email.com', '11987654321'),
(2, 'Maria Oliveira', '555.666.777-88', 'maria.olivera@email.com', '21912345678'),
(3, 'Pedro Souza', '999.888.777-66', 'pedro.souza@email.com', '31900001111'),
(4, 'João Silva', '111.222.333-44', 'joao.silva@email.com', '11987654321'),
(5, 'Maria Oliveira', '555.666.777-88', 'maria.olivera@email.com', '21912345678'),
(6, 'Pedro Souza', '999.888.777-66', 'pedro.souza@email.com', '31900001111'),
(7, 'Carlos Alberto', '56398236858', 'carlosab@gmail.com', '966699552'),
(8, 'Antonio Auggusto MAfra', '22665896885', 'antonio@gmail.com', '6999665588');

--
-- Despejando dados para a tabela `receita`
--

INSERT INTO `receita` (`id`, `dataReferencia`, `valor`, `situacao`, `idContrato`) VALUES
(1, '2023-01-01', 2500, 'Pago', 1),
(4, '2024-03-15', 950, 'Pago', 2),
(7, '2025-07-15', 1000, 'string', 2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
