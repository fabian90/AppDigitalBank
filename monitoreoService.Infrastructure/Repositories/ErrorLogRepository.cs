using monitoreo.Commons.Mapping;
using monitoreo.Commons.Paging;
using monitoreo.Commons.Repository;
using monitoreo.Commons.RequestFilter;
using monitoreo.Commons.Response;
using monitoreo.Core.DTOs.Response;
using monitoreo.Core.Entities;
using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace monitoreo.Infrastructure.Repositories
{
    public class ErrorLogRepository : GenericRepository<ErrorLog, monitoreoDBContext>, IErrorLogRepository
    {
        protected new readonly monitoreoDBContext _context;

        public ErrorLogRepository(monitoreoDBContext context) : base(context) 
        {
            _context = context;
        }

      

        public async Task<RecordsResponse<ErrorLogResponseDTO>> Get(QueryFilter filter)
        {
            var response = await _context.errorLog.OrderBy(x => x.Id).GetPagedAsync(filter.page, filter.take);
            return response.MapTo<RecordsResponse<ErrorLogResponseDTO>>()!;
        }
    }
}
