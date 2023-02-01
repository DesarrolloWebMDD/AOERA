using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class PremiosAuditoriaEntityConfig : IEntityTypeConfiguration<PremiosAuditoria>
    {
        public void Configure(EntityTypeBuilder<PremiosAuditoria> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Premio).WithMany().HasForeignKey(x => x.PremioId);
            builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
