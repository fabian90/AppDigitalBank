using monitoreo.Commons.Repository;
using monitoreo.Core.Entities;
using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Infrastructure.Data;

namespace Identity.Infrastructure.Repositories
{
    public class AuthenticateRepository : GenericRepository<User, monitoreoDBContext>, IAuthenticateRepository
    {
        protected readonly monitoreoDBContext _context;

        public AuthenticateRepository(monitoreoDBContext context) : base(context)
        {
            _context = context;
        }     
    }
}

