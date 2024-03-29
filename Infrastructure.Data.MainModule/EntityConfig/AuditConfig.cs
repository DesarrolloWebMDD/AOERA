﻿using Domain.Core.Auditory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.MainModule.EntityConfig
{
    public class AuditConfig : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.Property(p => p.KeyValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.NewValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.OldValues).HasMaxLength(int.MaxValue);
            builder.Property(p => p.TableName).HasMaxLength(50);
        }
    }
}