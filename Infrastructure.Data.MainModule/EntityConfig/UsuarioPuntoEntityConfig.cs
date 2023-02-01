using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class UsuarioPuntoEntityConfig : IEntityTypeConfiguration<UsuarioPunto>
    {
        public void Configure(EntityTypeBuilder<UsuarioPunto> builder)
        {
            builder.HasKey(p => p.Id);
            //builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.UsuarioId);
        }
    }
}
