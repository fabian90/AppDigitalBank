using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceUsuario.Dtos;
using WcfServiceUsuario.Model;

namespace WcfServiceUsuario.Data.Interface
{
    public interface IMonitoreoServiceApI
    {
        Task AgregarErrorLog(ErrorLogDto errorLog);
    }
}
