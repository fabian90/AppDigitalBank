using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Common
{
    public class Constants
    {
        public const string SUCCESS = "SUCCESS";
        public const string ERROR = "ERROR";
        public const string mensajeProductoExistente = "El producto {0} ya existe, es decir ya se encuentra registrado en base datos";
        public const string mensajeClienteExistente = "El cliente {0} ya existe, es decir ya se encuentra registrado en base datos ";
        public const string mensajeGuardar = "La información se guardó correctamente";
        public const string mensajeEliminar = "El registro se elimino correctamente";
        public const string mensajeEliminarError = "Error al eliminar el registro";
        public const string mensajeErrorCantidadEntrada = "Error al actualizar la cantidad del producto en el inventario, es decir cantidad tiene que ser mayor o igual a la cantidad de la ventas";
        public const int PageItems = 9;
    }
}
