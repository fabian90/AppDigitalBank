using monitoreo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace monitoreo.Infrastructure.Data
{
    public class monitoreoDBContext : DbContext
    {
        public monitoreoDBContext(DbContextOptions<monitoreoDBContext> options) : base(options)
        {

        }

        public virtual DbSet<ErrorLog> errorLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
