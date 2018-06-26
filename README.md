# ELISA
ELISA Software 2.0 

## Detalles Tecnicos

* Visual Studio 2017 (o 2015) y .Net Framework 4.6.1.
* MySQL Server 5+.

## Restaura la base de datos en MySQL

**Es importante no abrir este archivo usando el Notepad**
* Usando el archivo *ELISAdump.sql* restaura la base de datos desde MySQL CLI.

1. Usando CMD o Powershell navegar hasta los binarios de MySQL en ProgramFiles `C:\Program Files\MySQL\MySQL Server 5.7\bin` _Esta ruta puede cambiar dependiendo de la version de MySQL_
2. Restaurarla usando `mysql.exe --user=|el nombre de usuario| --pass < |path de ELISAdump.sql|` _Editar en los campos rodeados de ||_
3. Ingresar la contraseña del usuario del motor de base de datos.

