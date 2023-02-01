using Domain.MainModule.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class LogSessionUserConfig : IEntityTypeConfiguration<LogSessionUser>
    {
        public void Configure(EntityTypeBuilder<LogSessionUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        }
    }
}