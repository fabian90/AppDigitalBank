Solucion problema Http adress

1.Abre la Línea de Comandos con Privilegios de Administrador:

Para abrir la línea de comandos con privilegios de administrador, sigue estos pasos:

Haz clic en el menú Inicio.
Escribe "cmd" en la barra de búsqueda.
Haz clic derecho en "Símbolo del sistema" o "Command Prompt" en los resultados de búsqueda.
Selecciona "Ejecutar como administrador". Esto abrirá una ventana de línea de comandos con privilegios de administrador.
2.Ejecuta el Comando netsh:

Una vez que tengas la ventana de línea de comandos con privilegios de administrador abierta, puedes ejecutar el comando netsh junto con los argumentos necesarios. Asegúrate de reemplazar YOUR_USERNAME con tu nombre de usuario de Windows en el siguiente comando:

netsh http add urlacl url=http://+:8733/UsuarioService/ user=YOUR_USERNAME

3. Presiona Enter:

Luego de ingresar el comando y presionar Enter, deberías ver un mensaje que confirma que la reserva de URL se ha agregado correctamente.

Una vez que hayas ejecutado el comando netsh, deberías poder ejecutar tu servicio WCF en el puerto 8733 sin enfrentar el error de acceso denegado.

Recuerda que ejecutar comandos con privilegios de administrador puede tener implicaciones en la seguridad de tu sistema, así que asegúrate de comprender lo que estás haciendo y por qué lo estás haciendo antes de ejecutar cualquier comando.

****CitiBank base datos monitoreo*****
Scaffold-DBContext "Server=DESKTOP-776KT05\SQLEXPRESS;Database=DigitalBank;Trusted_Connection=true;MultipleActiveResultSets=true;Application Name=Monitoreo;Microsoft.EntityFrameworkCore.SqlServer;" -OutputDir Data -Force
****CitiBank wcfusario proyecto*****
Data Source=ESKTOP-776KT05\SQLEXPRESS;Initial Catalog=DigitalBank;Integrated Security=true;Application Name=WcfServiceUsuario;