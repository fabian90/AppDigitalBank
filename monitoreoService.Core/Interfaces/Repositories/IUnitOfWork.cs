namespace monitoreo.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IErrorLogRepository ErrorLogRepository { get; }
        void SaveChanges();

        Task SaveChangesAsync();


    }
}
