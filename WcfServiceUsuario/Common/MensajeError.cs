using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Common
{
    public class MensajeError
    {
       public static string mensajePersonalizado(string mensaje, string informacion, string ubicacion)
       {
            var mensajePersonalizado = "Error Mensaje:" + mensaje;
            if(string.IsNullOrEmpty(informacion))
            {
                mensajePersonalizado = mensajePersonalizado + " Inner exception: " + informacion;
            }
            mensajePersonalizado = mensajePersonalizado + " Stack trace:" + ubicacion;

            return (mensajePersonalizado);
       }
    }
}
