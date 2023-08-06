***Eabora por el Ing. Fabian Vargas Tovar***
# Ejecutable WcfServiceUsuario.sl
# AppDigitalBank
En el presente repositorio se crea con el propósito de subir el codigo fuente de la aplicación web AppDigitalBank, Los servcios monitoreoService.Api y WcfServiceUsuario con la siguiente estructura.
***Estructura de la AppDigitalBank***
**1.Capa de presentación** 
•	Controlador
•	Modelo
•	Dtos
•	Vistas
***Estructura de la monitoreoService.Api**
**1.Capa Core:**
•	Models
•	Interfaces 
•	Servicios
•	UnitOfWork
•	Enumerations
**2.Capa Infraestructura:**
•	Data
•	Repositories implementación
•	UnitOfWork
•	Mapping
**3.Capa API:**
•	Controllers
•	Models
•	DTOs (Data Transfer Objects)
•	Program
•	Validaciones
**4.Capa Common**
•	Helpers
•	Extensions
•	Constants
•	Enums
•	Logging
**Estructura del servicio WcfServiceUsuario**
**1.Capa Business**
•	Implementation  
•	Interfaces
**2.Capa Common**
•	Enum
•	Helper
•	Constants
•	Mensaje Error
**3. Capa Data**
•	Implementation  
•	Interfaces
•	Model
•	Dtos
**Paso a seguir para solucionar el problema de la ejecución de servicio WCF en Visual Studio 2022**
1.Para abrir la línea de comandos con privilegios de administrador, sigue estos pasos:

•	Haz clic en el menú Inicio.
•	Escribe "cmd" en la barra de búsqueda.
•	Haz clic derecho en "Símbolo del sistema" o "Command Prompt" en los resultados de búsqueda.
•	Selecciona "Ejecutar como administrador". Esto abrirá una ventana de línea de comandos con privilegios de administrador.
2.Ejecuta el Comando netsh:
Una vez que tengas la ventana de línea de comandos con privilegios de administrador abierta, puedes ejecutar el comando netsh junto con los argumentos necesarios. Asegúrate de reemplazar YOUR_USERNAME con tu nombre de usuario de Windows en el siguiente comando:
netsh http add urlacl url=http://+:8733/UsuarioService/ user=YOUR_USERNAME
3. Presiona Enter:
Luego de ingresar el comando y presionar Enter, deberías ver un mensaje que confirma que la reserva de URL se ha agregado correctamente.
Una vez que hayas ejecutado el comando netsh, deberías poder ejecutar tu servicio WCF en el puerto 8733 sin enfrentar el error de acceso denegado.
Recuerda que ejecutar comandos con privilegios de administrador puede tener implicaciones en la seguridad de tu sistema, así que asegúrate de comprender lo que estás haciendo y por qué lo estás haciendo antes de ejecutar cualquier comando.

**Encriptación y desencriptación conexión String**

Ejecutar la biblioteca ConnectionStringEncryptionConsoleApp para agregarla en la configuración de conexión del appsettings.json o del web.Config
****CitiBank base datos monitoreo*****

Scaffold-DBContext "Server=DESKTOP-776KT05\SQLEXPRESS;Database=DigitalBank;Trusted_Connection=true;MultipleActiveResultSets=true;Application Name=Monitoreo;Microsoft.EntityFrameworkCore.SqlServer;" -OutputDir Data -Force

****CitiBank wcfusario proyecto*****
Data Source=ESKTOP-776KT05\SQLEXPRESS;Initial Catalog=DigitalBank;Integrated Security=true;Application Name=WcfServiceUsuario;


