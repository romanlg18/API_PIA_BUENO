-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-05-2023 a las 07:27:31
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `ADDINSURANCE` (IN `SegurosP` VARCHAR(10000), IN `SegurosPINT` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000), IN `EstautsP` INT(1))   BEGIN
	INSERT INTO args01.ARGS_SEGUROS( SEGUROS_TYPE,SEGURO, SEGUROS_DESC, ESTATUS) VALUES ( SegurosP, SegurosPINT,SegurosDesP, EstautsP);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddSituation` (IN `NombreP` VARCHAR(70), IN `CorreoP` VARCHAR(100), IN `AsuntoP` VARCHAR(80), IN `MensajeP` LONGTEXT)   BEGIN
	INSERT INTO args01.args_contactos( Nombre,Correo, Asunto, Mensaje) VALUES ( NombreP, CorreoP, AsuntoP, MensajeP);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarCliente` (IN `NombresP` VARCHAR(10000), IN `ApellidosP` VARCHAR(10000), IN `NumeroP` BIGINT(50), IN `CorreoP` VARCHAR(10000), IN `IdSegurosP` INT(10), IN `FECHAP` VARCHAR(10000))   BEGIN
	INSERT INTO args01.args_clientes(CL_NOMBRES, CL_APELLIDOS, CL_NUMERO, CL_CORREO, IDSEGUROS, FECHA_ALTA) VALUES (NombresP, ApellidosP, NumeroP, CorreoP, IdSegurosP, FECHAP );
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarSeguro` (IN `SegurosP` VARCHAR(10000), IN `SegurosPT` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000))   BEGIN
	INSERT INTO args01.ARGS_SEGUROS(SEGUROS_TYPE, SEGURO,SEGURO_DESC) VALUES (SegurosP, SegurosPT,SegurosDesP);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `BuzonDudas` ()   BEGIN
	select * from args_contactos;
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `LOGIN` ()   BEGIN
	select Usuario, Password from args_credenciales;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECTCLIENTS` ()   BEGIN
	select A1.IdCliente, A1.CL_NOMBRES, A1.CL_APELLIDOS, A1.CL_NUMERO
    , A1.CL_CORREO, A1.IDSEGUROS
    ,CASE 
       WHEN A1.ESTATUScl = 1 THEN "Activo"
       WHEN A1.ESTATUScl = 0 THEN "Inactivo"
       ELSE "Null"
       END ESTATUS
       , B1.SEGURO,date_format(FECHA_ALTA, "%D/%M/%Y") FECHA_ALTA
	FROM ARGS_CLIENTES A1
    INNER JOIN ARGS_SEGUROS B1 ON B1.IDSEGUROS = A1.IDSEGUROS;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectDetailsSeguros` (IN `idSegurosP` INT)   BEGIN
	SELECT SEGUROS_TYPE, SEGURO,SEGURO_DESC, ESTATUS FROM ARGS_SEGUROS 
    WHERE idSeguros = idSegurosP;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_MULTIPLE_ENSURANCE` ()   BEGIN
    select CONCAT(A1.CL_NOMBRES, ' ' , A1.CL_APELLIDOS) AS NOMBRE_COMPLETO,
	B1.SEGUROS_TYPE,B1.SEGURO_DESC, A1.CL_CORREO, A1.CL_NUMERO
	from args_clientes A1
	INNER JOIN ARGS_SEGUROS B1 ON B1.IDSEGUROS = A1.IDSEGUROS;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_ONE_ENSURANCE` (IN `idSegurosP` INT)   BEGIN
	SELECT * FROM ARGS_SEGUROS 
    WHERE ESTATUS NOT IN (0);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_SEGUROS` ()   BEGIN
	select * from args_seguros
    where estatus not in(0);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_INSURANCE` (IN `idSegurosP` INT, IN `SegurosP` VARCHAR(10000), IN `SegurosPT` VARCHAR(10000), IN `SegurosDesP` VARCHAR(10000), IN `EstautsP` INT(1))   BEGIN
	UPDATE ARGS_SEGUROS 
    SET SEGUROS_TYPE = SegurosP, Seguro = SegurosPT,SEGURO_DESC = SegurosDesP ,Estatus = EstautsP 
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
  `SEGURO_INT` varchar(60) DEFAULT NULL,
  `ESTATUSCL` int(11) NOT NULL DEFAULT 1,
  `FECHA_ALTA` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_clientes`
--

INSERT INTO `args_clientes` (`IdCliente`, `CL_NOMBRES`, `CL_APELLIDOS`, `CL_Numero`, `CL_Correo`, `IDSEGUROS`, `SEGURO_INT`, `ESTATUSCL`, `FECHA_ALTA`) VALUES
(1, 'Roman', 'Leyva Garza', 8120741152, 'romanleyva269@gmail.com', 1, NULL, 0, '2000-03-18'),
(2, 'Daniela Alejandra', 'Vieyra Caballero', 8120741153, 'danielaVieyra@gmail.com', 5, NULL, 1, '2002-11-14'),
(3, 'Roman', 'Leyva Garza', 8120741152, 'romanleyva269@gmail.com', 2, NULL, 1, '2000-03-18');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_contactos`
--

CREATE TABLE `args_contactos` (
  `IdContacto` int(11) NOT NULL,
  `Nombre` varchar(70) NOT NULL,
  `Correo` varchar(100) NOT NULL,
  `Asunto` varchar(45) NOT NULL,
  `Mensaje` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_contactos`
--

INSERT INTO `args_contactos` (`IdContacto`, `Nombre`, `Correo`, `Asunto`, `Mensaje`) VALUES
(1, 'Roman Leyva Garza', 'romanleyva269@gmail.com', 'Fondo de ahorro', '¡Necesito ayuda!'),
(2, 'Daniela Alejandra', 'daniela@gmail.com', 'Fondo de ahorro', '¡Necesito ayuda!'),
(3, 'Roman Leyva Garza', 'romanleyva269@gmail.com', 'Fondo de ahorro', 'Ayuda! ');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `args_credenciales`
--

CREATE TABLE `args_credenciales` (
  `IDUser` int(11) NOT NULL,
  `Usuario` varchar(45) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `args_credenciales`
--

INSERT INTO `args_credenciales` (`IDUser`, `Usuario`, `Password`) VALUES
(1, 'admin', 'tKRHO3p8%07dlDSf#B^k');

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
-- Indices de la tabla `args_clientes`
--
ALTER TABLE `args_clientes`
  ADD PRIMARY KEY (`IdCliente`),
  ADD KEY `IDSEGUROS_idx` (`IDSEGUROS`);

--
-- Indices de la tabla `args_contactos`
--
ALTER TABLE `args_contactos`
  ADD PRIMARY KEY (`IdContacto`);

--
-- Indices de la tabla `args_credenciales`
--
ALTER TABLE `args_credenciales`
  ADD PRIMARY KEY (`IDUser`);

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
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `args_contactos`
--
ALTER TABLE `args_contactos`
  MODIFY `IdContacto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `args_seguros`
--
ALTER TABLE `args_seguros`
  MODIFY `IDSEGUROS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

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
