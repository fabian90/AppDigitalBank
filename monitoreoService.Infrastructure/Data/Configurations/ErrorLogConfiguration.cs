using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using monitoreo.Core.Entities;

namespace monitoreo.Infrastructure.Data.Configurations
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.ToTable("ErrorLog");

            builder.HasKey(e => e.Id);

            builder.Property(r => r.Mensaje)
                .HasMaxLength(200);

            builder.Property(r => r.Detalles)
                .HasMaxLength(500);

            builder.Property(r => r.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
