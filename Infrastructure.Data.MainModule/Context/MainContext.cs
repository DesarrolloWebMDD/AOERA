﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Security.Enum;
using Domain.Core.Auditory;
using Domain.Core.Interface;
using Domain.MainModule.Entity;
using Infrastructure.CrossCutting.Helpers;
using Infrastructure.Data.MainModule.EntityConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.MainModule.Context
{
    public class MainContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MainContext(DbContextOptions<MainContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            CurrentUserId = GetCurrentUserId();
        }

        public int? CurrentUserId { get; set; }

        #region DbSet

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<MaestroDetalle> MaestroDetalle { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<CategoriaFutbol> CategoriaFutbol { get; set; }
        public DbSet<DeporteResultados> DeporteResultados { get; set; }
        public DbSet<Deportes> Deportes { get; set; }
        public DbSet<FutbolSubCagoria> FutbolSubCagoria { get; set; }
        public DbSet<Ligas> Ligas { get; set; }
        public DbSet<Membresia> Membresia { get; set; }
        public DbSet<PagoCompras> PagoCompras { get; set; }
        public DbSet<PagosIzipay> PagosIzipay { get; set; }
        public DbSet<Premios> Premios { get; set; }
        public DbSet<PremiosAuditoria> PremiosAuditoria { get; set; }
        public DbSet<PuntosPaquete> PuntosPaquete { get; set; }
        public DbSet<TokenTarjetaPago> TokenTarjetaPago { get; set; }
        public DbSet<UsuarioPunto> UsuarioPunto { get; set; }
        public DbSet<ConfiguracionCorreo> ConfiguracionCorreo { get; set; }
        public DbSet<Aciertos> Aciertos { get; set; }
        public DbSet<DetalleAciertos> DetalleAciertos { get; set; }
       

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UsuarioEntityConfig());
            builder.ApplyConfiguration(new MaestroEntityConfig());
            builder.ApplyConfiguration(new MaestroDetalleEntityConfig());
            builder.ApplyConfiguration(new LogSessionUserConfig());
            builder.ApplyConfiguration(new AuditConfig());
            builder.ApplyConfiguration(new CategoriaFutbolEntityConfig());
            builder.ApplyConfiguration(new DeportesEntityConfig());
            builder.ApplyConfiguration(new FutbolSubCagoriaEntityConfig());
            builder.ApplyConfiguration(new LigasEntityConfig());
            builder.ApplyConfiguration(new DeporteResultadosEntityConfig());
            builder.ApplyConfiguration(new UsuarioPuntoEntityConfig());
            builder.ApplyConfiguration(new PremiosEntityConfig());
            builder.ApplyConfiguration(new PremiosAuditoriaEntityConfig());
            builder.ApplyConfiguration(new MembresiaEntityConfig());
            builder.ApplyConfiguration(new PuntosPaqueteEntityConfig());
            builder.ApplyConfiguration(new TokenTarjetaPagoEntityConfig());
            builder.ApplyConfiguration(new ConfiguracionCorreoEntityConfig());
            builder.ApplyConfiguration(new AciertosEntityConfig());
            builder.ApplyConfiguration(new DetalleAciertosEntityConfig());
        }

        #endregion

        #region OnSaveChanges

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);

            await OnAfterSaveChanges(auditEntries);

            return result;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        #region Private Methods

        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditEntity && (x.State == EntityState.Added
                                                         || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditEntity) entry.Entity;
                DateTime now = CoreHelper.GetDateTimePeru();

                if (entry.State == EntityState.Added)
                {
                    entity.FechaCreacion = now;
                    if (!entity.UsuarioCreacion.HasValue || entity.UsuarioCreacion.Value == 0)
                        entity.UsuarioCreacion = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.FechaCreacion).IsModified = false;
                    base.Entry(entity).Property(x => x.UsuarioCreacion).IsModified = false;

                    entity.FechaModificacion = now;
                    if (!entity.UsuarioModificacion.HasValue || entity.UsuarioModificacion.Value == 0)
                        entity.UsuarioModificacion = CurrentUserId;
                }
            }
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.Entity is LogSessionUser || entry.State == EntityState.Detached ||
                    entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Metadata.GetTableName(),
                    CurrentUserId = CurrentUserId
                };
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }

                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(entry => !entry.HasTemporaryProperties))
            {
                try
                {
                    Audits.Add(auditEntry.ToAudit());
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(entry => entry.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    else
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                }

                try
                {
                    // Save the Audit entry
                    Audits.Add(auditEntry.ToAudit());
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return SaveChangesAsync();
        }

        private int? GetCurrentUserId()
        {
            int? currentUserId = null;

            if (_httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                currentUserId = claimsPrincipal.FindFirst(ClaimType.Id) != null
                    ? Convert.ToInt32(claimsPrincipal.FindFirst(ClaimType.Id)?.Value)
                    : null;
            }

            return currentUserId;
        }

        #endregion
    }
}