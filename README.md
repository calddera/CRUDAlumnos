# CRUDAlumnos

El la raíz del repositorio está el archivo Schema_CRUDAlumnos.sql 
el cual contiene el script para crear la base de datos con sus respectivas tablas en un Motor de MYSQL.

Se usó la versión  5.7.34 de MYSQL Server.

Favor de configurar el archivo Web.conf con los datos correctos de la cadena de conexión una vez que se haya generado la base de datos en el servidor de Mysql

server=[HOST];user id=[USER];password=[PASSWORD];database=[SCHEMA]

Acrtualmente el proyecto tiene terminado el CRUD para la entidad ALUMNO, sin embargo, ya está la capa de datos para CRUD en Profesores y Grado
