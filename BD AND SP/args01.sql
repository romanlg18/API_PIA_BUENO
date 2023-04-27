-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-04-2023 a las 08:48:27
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `args01`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_seguros`
--

CREATE TABLE `args_seguros` (
  `IDSEGUROS` int(11) NOT NULL,
  `SEGUROS_TYPE` varchar(45) NOT NULL,
  `SEGURO` varchar(70) NOT NULL,
  `SEGURO_DESC` varchar(45) NOT NULL,
  `ESTATUS` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_seguros`
--

INSERT INTO `args_seguros` (`IDSEGUROS`, `SEGUROS_TYPE`, `SEGURO`, `SEGURO_DESC`, `ESTATUS`) VALUES
(1, 'Seguros Individuales', 'Ahorro', 'Obtén rentabilidad para tu dinero', 1),
(2, 'Seguros Individuales', 'Educación', 'Protege cada etapa escolar de tu hijo', 1),
(3, 'Seguros Individuales', 'Retiro', 'Genera un ahorro para tu retiro', 1),
(4, 'Seguros Individuales', 'Gastos Medicos Mayores', 'Protege a tu familia de cualquier accidente', 1),
(5, 'Seguros Colectivos y Empresariales', 'Gastos Medicos Mayores', 'Protege a tus empleados de cualquier accident', 1),
(6, 'Seguros Colectivos y Empresariales', 'Vida e Incapacidad', 'Protege a tus empleados de incapacidad y ofre', 1),
(7, 'Seguros Colectivos y Empresariales', 'Hombre Clave', 'Nace de la necesidad de salvaguardar el patri', 1),
(8, 'Seguros Colectivos y Empresariales', 'Intersocios', 'Seguro para quien sobreviva a una sociedad, o', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `args_seguros`
--
ALTER TABLE `args_seguros`
  ADD PRIMARY KEY (`IDSEGUROS`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `args_seguros`
--
ALTER TABLE `args_seguros`
  MODIFY `IDSEGUROS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
