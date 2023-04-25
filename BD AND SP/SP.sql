-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-04-2023 a las 23:43:31
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

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `ADDINSURANCE` (IN `SegurosP` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000), IN `EstautsP` INT(1))   BEGIN
	INSERT INTO args01.ARGS_SEGUROS( SEGUROS_TYPE, SEGUROS_DESC, ESTATUS) VALUES ( SegurosP, SegurosDesP, EstautsP);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarSeguro` (IN `SegurosP` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000), IN `EstautsP` INT(1))   BEGIN
	INSERT INTO args01.ARGS_SEGUROS(SEGUROS_TYPE, SEGURO_DESC, ESTATUS) VALUES (SegurosP, SegurosDesP, EstautsP);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_CLIENT` (IN `idClienteP` INT)   BEGIN
	DELETE FROM ARGS_CLIENTES WHERE idCliente = idClienteP;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_INSURANCE` (IN `idSegurosP` INT)   BEGIN
	DELETE FROM ARGS_SEGUROS WHERE idSeguros = idSegurosP;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_update_client` (IN `idClienteP` INT, IN `EstatusCLP` INT)   BEGIN
		UPDATE ARGS_clientes
		SET  EstatusCL = EstatusCLP
		WHERE IdCliente = idClienteP;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECTCLIENTS` ()   BEGIN
	SELECT * FROM ARGS_CLIENTES
    WHERE EstatusCL NOT IN (0);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectDetailsSeguros` (IN `idSegurosP` INT)   BEGIN
	SELECT SEGUROS_TYPE, SEGURO_DESC, ESTATUS FROM ARGS_SEGUROS 
    WHERE idSeguros = idSegurosP;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_MULTIPLE_ENSURANCE` ()   BEGIN
    select CONCAT(A1.CL_NOMBRES, ' ' , A1.CL_APELLIDOS) AS NOMBRE_COMPLETO,
	B1.SEGUROS_TYPE,B1.SEGURO_DESC, A1.CL_CORREO, A1.CL_NUMERO
	from args_clientes A1
	INNER JOIN ARGS_SEGUROS B1 ON B1.IDSEGUROS = A1.IDSEGUROS;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_ONE_ENSURANCE` (IN `idSegurosP` INT)   BEGIN
	SELECT SEGUROS_TYPE, SEGUROS_DESC, ESTATUS FROM ARGS_SEGUROS 
    WHERE ESTATUS NOT IN (0);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_SEGUROS` ()   BEGIN
	select * from args_seguros
    where estatus not in(0);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_INSURANCE` (IN `idSegurosP` INT, IN `SegurosP` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000), IN `EstautsP` INT(1))   BEGIN
	UPDATE ARGS_SEGUROS 
    SET SEGUROS_TYPE = SegurosP,SEGURO_DESC = SegurosDesP ,Estatus = EstautsP 
    WHERE idSeguros = idSegurosP;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_clientes`
--

CREATE TABLE `args_clientes` (
  `IdCliente` int(11) NOT NULL,
  `CL_NOMBRES` varchar(45) NOT NULL,
  `CL_APELLIDOS` varchar(45) NOT NULL,
  `CL_Numero` bigint(50) NOT NULL,
  `CL_Correo` varchar(60) NOT NULL,
  `IDSEGUROS` int(11) NOT NULL,
  `SEGURO_INT` varchar(60) NOT NULL,
  `ESTATUSCL` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_clientes`
--

INSERT INTO `args_clientes` (`IdCliente`, `CL_NOMBRES`, `CL_APELLIDOS`, `CL_Numero`, `CL_Correo`, `IDSEGUROS`, `SEGURO_INT`, `ESTATUSCL`) VALUES
(2, 'Daniela Alejandra', 'Vieyra Caballero', 8120741154, 'daniela@uanl.edu.mx', 2, '', 1),
(3, 'Alder Adad', 'Portillo Silva', 8120741155, 'alder@uanl.edu.mx', 1, '', 1),
(5, 'Román', 'Leyva Garza', 8120741152, 'romanleyva269@gmail.com', 3, 'Seguro de Retiro', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_prospectos`
--

CREATE TABLE `args_prospectos` (
  `idProspecto` int(40) NOT NULL,
  `Nombres(s)` varchar(100) NOT NULL,
  `Apellidos(s)` varchar(100) NOT NULL,
  `Telefono` bigint(50) NOT NULL,
  `Correo` varchar(60) NOT NULL,
  `SegurosTipo` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_prospectos`
--

INSERT INTO `args_prospectos` (`idProspecto`, `Nombres(s)`, `Apellidos(s)`, `Telefono`, `Correo`, `SegurosTipo`) VALUES
(1, 'Román', 'Leyva Garza', 8120741152, 'romanleyva269@gmail.com', 'Seguro de Retiro');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_seguros`
--

CREATE TABLE `args_seguros` (
  `IDSEGUROS` int(11) NOT NULL,
  `SEGUROS_TYPE` varchar(45) NOT NULL,
  `SEGURO_DESC` varchar(45) NOT NULL,
  `ESTATUS` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_seguros`
--

INSERT INTO `args_seguros` (`IDSEGUROS`, `SEGUROS_TYPE`, `SEGURO_DESC`, `ESTATUS`) VALUES
(1, 'Médico', 'Protege cada etapa de tu vida', 0),
(2, 'Seguro de retiro', 'El seguro del retiro es un producto financier', 1),
(3, 'Seguro de daños', 'Protege el patrimonio o negocio de los asegur', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `args_clientes`
--
ALTER TABLE `args_clientes`
  ADD PRIMARY KEY (`IdCliente`),
  ADD KEY `IDSEGUROS_idx` (`IDSEGUROS`);

--
-- Indices de la tabla `args_prospectos`
--
ALTER TABLE `args_prospectos`
  ADD PRIMARY KEY (`idProspecto`);

--
-- Indices de la tabla `args_seguros`
--
ALTER TABLE `args_seguros`
  ADD PRIMARY KEY (`IDSEGUROS`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `args_clientes`
--
ALTER TABLE `args_clientes`
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `args_prospectos`
--
ALTER TABLE `args_prospectos`
  MODIFY `idProspecto` int(40) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `args_seguros`
--
ALTER TABLE `args_seguros`
  MODIFY `IDSEGUROS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `args_clientes`
--
ALTER TABLE `args_clientes`
  ADD CONSTRAINT `IDSEGUROS` FOREIGN KEY (`IDSEGUROS`) REFERENCES `args_seguros` (`IDSEGUROS`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
