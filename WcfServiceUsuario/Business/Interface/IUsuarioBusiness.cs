using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceUsuario.Common;
using WcfServiceUsuario.Dtos;

namespace WcfServiceUsuario.Business.Interface
{
    [ServiceContract]
    public interface IUsuarioBusiness
    {
        [OperationContract]
        BusinessResultado<List<UsuarioDto>> Consultar();

        [OperationContract]
        BusinessResultado<UsuarioDto> ObtenerUsuarioPorId(int id);

        [OperationContract]
        BusinessResultado<int> Guardar(UsuarioDto usuarioDto);

        [OperationContract]
        BusinessResultado<int> Actualizar(UsuarioDto usuarioDto);

        [OperationContract]
        BusinessResultado<int> Eliminar(int id);
    }
}
