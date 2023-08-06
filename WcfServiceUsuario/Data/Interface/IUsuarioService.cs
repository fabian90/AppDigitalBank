using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceUsuario.Model;

namespace WcfServiceUsuario.Data.Interface
{
    public interface IUsuarioService 
    {  
        List<Usuario> ObtenerUsuarios();    
        Usuario ObtenerUsuarioPorId(int id);   
        int AgregarUsuario(Usuario Usuario);    
        int ActualizarUsuario(Usuario Usuario);
        int EliminarUsuario(int id);
    }
}
