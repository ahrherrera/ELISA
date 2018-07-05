# ELISA
ELISA Software 2.0 

## Detalles Tecnicos

* Visual Studio 2017 (o 2015) y .Net Framework 4.5.
* MySQL Server 5+.
* MySQL Connector/NET 6.9.12 **Esta versión específica**.

[Descarga Connector/NET 6.9.12](https://dev.mysql.com/downloads/connector/net/6.9.12.html)

## Restaura la base de datos en MySQL

**Es importante no abrir este archivo usando el Notepad**
* Usando el archivo *ELISAdump.sql* restaura la base de datos desde MySQL CLI.

1. Usando CMD o Powershell navegar hasta los binarios de MySQL en ProgramFiles `C:\Program Files\MySQL\MySQL Server 5.7\bin` _Esta ruta puede cambiar dependiendo de la version de MySQL_
2. Restaurarla usando `mysql.exe --user=|el nombre de usuario| --pass < |path de ELISAdump.sql|` _Editar en los campos rodeados de ||_
3. Ingresar la contraseña del usuario del motor de base de datos.

[Mas informacion sobre la Restauración](https://dev.mysql.com/doc/mysql-backup-excerpt/5.7/en/reloading-sql-format-dumps.html)

**El usuario del motor de base de datos debe tener los privilegios para ejecutar DML(SELECT, INSERT, UPDATE, DELETE)**

Hasta este punto la base de datos, su estructura y parte de los registros deben de estar correctamente restaurados. Tener en cuenta que siempre se usara **localhost** como servidor.

## Configurar el proyecto

La solución de VS2017 contiene todas las dependencias necesarias para ejecutar correctamente el sistema de información, Sin embargo, hay que hacer unas pequeñas configuraciones para que la aplicación se conecte con tu servidor de base de datos local.

![alt text](https://i.imgur.com/XQ5glzN.png "Imagen 1")
* Navegar desde el _Explorador de Soluciones_ de VS o desde los ficheros para abrir *App.config*
* Editar la linea 11 y cambiar con el usuario y contraseña correspondiente al de tu servidor

`<add name="elisaEntities2" connectionString="metadata=res://*/ElisaDB.csdl|res://*/ElisaDB.ssdl|res://*/ElisaDB.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=localhost;user id=|tu usuario|;password=|tu contraseña|;persistsecurityinfo=True;database=elisa&quot;" providerName="System.Data.EntityClient" /></connectionStrings>` _Editar los campos rodeados de |_

* Guardar y compilar la solución 

## Alternativa

La solución contiene una version compilada en modo Debug lista para ejecutar directamente, siempre y cuando tengas instalado .Net Framework 4.5.

* Dirigirse a `bin/debug` y editar el archivo `ELISA.exe.config` usando bloc de notas o algun otro editor, y editar la linea 11 como el paso anterior, cambiar el nombre de usuario y contraseña, y guardar.

* Ejecutar **ELISA.exe** y si la conexion a la base de datos es exitosa, se habilitará el Login.

### Usuarios y Contraseñas de acceso al Sistema

Usuario: Administrador
Contraseña: adminE


