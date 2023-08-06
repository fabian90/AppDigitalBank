using monitoreo.Commons.RequestFilter;
using monitoreo.Commons.Response;
using monitoreo.Core.DTOs.Request;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;
namespace monitoreo.Core.Interfaces.Services
{
    public interface IErrorLogService
    {
      
        Task<ApiResponse<ErrorLogResponseDTO>> Guardar(ErrorLogRequestDTO request);
    }
}