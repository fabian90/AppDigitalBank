using monitoreo.Commons.Repository.Interfaces;
using monitoreo.Commons.RequestFilter;
using monitoreo.Commons.Response;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;

namespace monitoreo.Core.Interfaces.Repositories
{
    public interface IErrorLogRepository : IGenericRepository<ErrorLog>
    {
        Task<RecordsResponse<ErrorLogResponseDTO>> Get(QueryFilter filter);

    }
}
