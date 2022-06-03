-- Schema CRUDAlumnos
CREATE DATABASE `crudalumnos`;

CREATE TABLE `crudalumnos`.`alumno` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(80) NOT NULL,
  `Apellidos` VARCHAR(80) NOT NULL,
  `GeneroId` INT NOT NULL,
  `FechaNac` DATE NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `crudalumnos`.`profesor` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(80) NOT NULL,
  `Apellidos` VARCHAR(80) NOT NULL,
  `GeneroId` INT NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `crudalumnos`.`grado` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(80) NOT NULL,
  `ProfesorId` INT NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `crudalumnos`.`alumno_grado` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `AlumnoId` INT NOT NULL,
  `GradoId` INT NOT NULL,
  `SeccionId` INT NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `crudalumnos`.`genero` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `crudalumnos`.`seccion` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`Id`));

  ALTER TABLE `alumno` ADD FOREIGN KEY (`GeneroId`) REFERENCES `genero`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 
  ALTER TABLE `profesor` ADD FOREIGN KEY (`GeneroId`) REFERENCES `genero`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 
  ALTER TABLE `grado` ADD FOREIGN KEY (`ProfesorId`) REFERENCES `profesor`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 
  ALTER TABLE `alumno_grado` ADD FOREIGN KEY (`AlumnoId`) REFERENCES `alumno`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 
  ALTER TABLE `alumno_grado` ADD FOREIGN KEY (`GradoId`) REFERENCES `grado`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 
  ALTER TABLE `alumno_grado` ADD FOREIGN KEY (`SeccionId`) REFERENCES `seccion`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 


  INSERT INTO `genero` (`Id`, `Nombre`) VALUES ('1', 'Mujer'), ('2', 'Hombre');
  INSERT INTO `seccion` (`Id`, `Nombre`) VALUES ('1', 'A'), ('2', 'B'), ('3', 'C'), ('4', 'D');
