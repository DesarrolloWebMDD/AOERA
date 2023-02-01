using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class MembresiaEntityConfig : IEntityTypeConfiguration<Membresia>
    {
        public void Configure(EntityTypeBuilder<Membresia> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Membresias).HasForeignKey(f => f.UsuarioId);
        }
    }
}
