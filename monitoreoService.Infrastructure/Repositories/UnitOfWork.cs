using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Infrastructure.Data;

namespace monitoreo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly monitoreoDBContext _context;
        private readonly IErrorLogRepository _errorLogRepository;
        //private readonly IAuthenticateRepository _authenticateRepository;
        
        public UnitOfWork(monitoreoDBContext context)
        {
            _context = context;
        }

        public IErrorLogRepository ErrorLogRepository => _errorLogRepository ?? new ErrorLogRepository(_context);
        //public IAuthenticateRepository AuthenticateRepository => _authenticateRepository ?? new AuthenticateRepository(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
