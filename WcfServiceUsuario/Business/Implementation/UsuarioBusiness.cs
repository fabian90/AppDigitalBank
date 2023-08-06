using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfServiceUsuario.Business.Interface;
using WcfServiceUsuario.Common;
using WcfServiceUsuario.Common.Helper;
using WcfServiceUsuario.Data.Implementation;
using WcfServiceUsuario.Data.Interface;
using WcfServiceUsuario.Dtos;
using WcfServiceUsuario.Model;

namespace WcfServiceUsuario.Business.Implementation
{
    public class UsuarioBusiness : IUsuarioBusiness
    {

        //public UsuarioBusiness(IUsuarioService usuarioService)
        //{
        //    _usuarioService = usuarioService;
        //}
        ErrorLogDto errorLog = new ErrorLogDto();
        MonitoreoServiceApI monitoreoServiceApI = new MonitoreoServiceApI();
        public  BusinessResultado<UsuarioDto> ObtenerUsuarioPorId(int Id)
        {
            UsuarioDto usuarioDto = new UsuarioDto();        
            try
            {
                var usuarioBusiness = new UsuarioService();
                usuarioDto = ConfiguracionMapper<Usuario, UsuarioDto>.Convert(usuarioBusiness.ObtenerUsuarioPorId(Id));
                errorLog.Mensaje = "Exitos";
                errorLog.Detalles = "ObtenerUsuarioPorId";
                _=monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<UsuarioDto>.Success(usuarioDto, Constants.SUCCESS);
            }
            catch (Exception ex)
            {
                errorLog.Mensaje = ex.Message;
                errorLog.Detalles = ex.StackTrace;
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<UsuarioDto>.Error(usuarioDto, ex.Message, ex);
            }
        }

        public BusinessResultado<List<UsuarioDto>> Consultar()
        {
            List<UsuarioDto> usuarioDto = new List<UsuarioDto>();
            try
            {
                var usuarioBusiness = new UsuarioService();
                usuarioDto = ConfiguracionMapper<Usuario, UsuarioDto>.ConvertList(usuarioBusiness.ObtenerUsuarios());
                errorLog.Mensaje = "Exitos";
                errorLog.Detalles = "Consultar";
                _=monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<List<UsuarioDto>>.Success(usuarioDto, Constants.SUCCESS);
            }
            catch (Exception ex)
            {
                errorLog.Mensaje = ex.Message;
                errorLog.Detalles = ex.StackTrace;
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<List<UsuarioDto>>.Error(usuarioDto, ex.Message, ex);
            }
        }
        public BusinessResultado<int>Guardar(UsuarioDto usuarioDto)
        {
            int respuesta = 0;
            try
            {
                var usuarioBusiness = new UsuarioService();
                respuesta = usuarioBusiness.AgregarUsuario( ConfiguracionMapper<UsuarioDto, Usuario>.Convert(usuarioDto));
                errorLog.Mensaje = "Exitos";
                errorLog.Detalles = "Guardar";
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Success(respuesta, Constants.SUCCESS);
            }
            catch (Exception ex)
            {
                errorLog.Mensaje = ex.Message;
                errorLog.Detalles = ex.StackTrace;
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Error(respuesta, ex.Message, ex);
            }

        }

        public BusinessResultado<int> Actualizar(UsuarioDto usuarioDto)
        {
            int respuesta = 0;

            try
            {
                var usuarioBusiness = new UsuarioService();
                respuesta = usuarioBusiness.ActualizarUsuario(ConfiguracionMapper<UsuarioDto, Usuario>.Convert(usuarioDto));
                errorLog.Mensaje = "Exitos";
                errorLog.Detalles = "Guardar";
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Success(respuesta, Constants.SUCCESS);
            }
            catch (Exception ex)
            {
                errorLog.Mensaje = ex.Message;
                errorLog.Detalles = ex.StackTrace;
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Error(respuesta, ex.Message, ex);
            }

        }

        public BusinessResultado<int> Eliminar(int Id)
        {
            int respuesta = 0;
            try
            {
                var usuarioBusiness = new UsuarioService();
                respuesta = usuarioBusiness.EliminarUsuario(Id);
                errorLog.Mensaje = "Exitos";
                errorLog.Detalles = "Eliminar";
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Success(respuesta, Constants.SUCCESS);
            }
            catch (Exception ex)
            {
                errorLog.Mensaje = ex.Message;
                errorLog.Detalles = ex.StackTrace;
                _ = monitoreoServiceApI.AgregarErrorLog(errorLog);
                return BusinessResultado<int>.Error(respuesta, ex.Message, ex);
            }
        }
    }
}
