﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Core.Pagination;
using Domain.MainModule.IRepository;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Enum;
using Infrastructure.CrossCutting.Wrapper;
using Infrastructure.Data.MainModule.Context;
using Infrastructure.Data.MainModule.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.MainModule.Repository
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
        where TId : IComparable<TId>
    {
        public GenericRepository(MainContext mainContext)
        {
            MainContext = mainContext;
            DbSet = mainContext.Set<TEntity>();
        }

        public GenericRepository(MainContext mainContext, DbSet<TEntity> dbSet)
        {
            MainContext = mainContext;
            DbSet = dbSet;
        }

        protected MainContext MainContext { get; }
        protected DbSet<TEntity> DbSet { get; set; }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityTracking = await DbSet.AddAsync(entity);

            return entityTracking.Entity;
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).CountAsync();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            bool @readonly = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (@readonly)
                query = query.AsNoTracking();

            return query.Where(predicate);
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            var keyProperty = MainContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties[0];
            var keyId = (int) Convert.ChangeType(id, typeof(int));

            var dbSet = (IQueryable<TEntity>) DbSet;

            return await dbSet.FirstOrDefaultAsync(x => EF.Property<int>(x, keyProperty.Name) == keyId);
        }

        public async Task<ValidationResult> AddAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);
            return await AddEntityAsync(entity, validateEntityResult);
        }

        public async Task<ValidationResult> AddAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            return await AddEntityAsync(entity, validateEntityResult);
        }

        public async Task<ValidationResult> UpdateAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);

            if (validateEntityResult.IsValid)
                MainContext.Update(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> UpdateAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            if (validateEntityResult.IsValid) MainContext.Update(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> DeleteAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);

            if (validateEntityResult.IsValid) MainContext.Remove(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> DeleteAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            if (validateEntityResult.IsValid) MainContext.Remove(entity);
            return validateEntityResult;
        }

        public async Task<ValidationResult> ValidateEntityAsync(TEntity entity, IValidator<TEntity> validation)
        {
            if (validation != null)
            {
                var validationResultEntity = await validation.ValidateAsync(entity);
                return validationResultEntity;
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateEntityAsync(TEntity entity,
            IEnumerable<IValidator<TEntity>> validations)
        {
            if (validations != null)
            {
                var errors = new List<ValidationFailure>();

                foreach (var validation in validations)
                {
                    var currentValidationResult = await validation.ValidateAsync(entity);

                    if (!currentValidationResult.IsValid)
                        errors.AddRange(currentValidationResult.Errors);
                }

                return new ValidationResult(errors);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> AddEntityAsync(TEntity entity, ValidationResult validationResultEntity)
        {
            if (validationResultEntity.IsValid)
                //await DbSet.AddAsync(entity);
                await MainContext.AddAsync(entity);

            return validationResultEntity;
        }

        public async Task<IEnumerable<TDto>> RunSqlQuery<TDto>(string sqlQuery, object parameters = null)
        {
            return await MainContext.FromSqlQueryAsync<TDto>(sqlQuery, parameters);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public async Task<string> StringResultProcedure(string sqlQuery, object parameters = null)
        {
            return await MainContext.StringResultProcedure(sqlQuery, parameters);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public IQueryable<TEntity> FindOrTermi(Expression<Func<TEntity, bool>> predicate, string tipo, int page,
            int size, bool @readonly = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (@readonly)
                query = query.AsNoTracking();

            return query.Where(predicate).Skip(page * size).Take(size);
        }

        public virtual async Task<PaginationResult<TEntity>> FindAllPagingAsync(
            PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            var paging = GetDataWithFilter(parameters, @readonly);
            return await PagingAsync(parameters, paging);
        }

        public async Task<IEnumerable<TDto>> RunStoredProcedure<TDto>(string storeProcedure, object parameteres = null)
        {
            return await MainContext.FromSqlQueryAsync<TDto>(storeProcedure, parameteres);
        }

        public virtual void Update(TEntity entity)
        {
            if (DbSet.Local.All(p => p != entity))
            {
                DbSet.Attach(entity);
                var entry = MainContext.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet.Attach(entity);

            var entry = MainContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        protected IQueryable<TEntity> GetDataWithFilter(PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            var dbSet = parameters.Includes != null ? parameters.Includes(DbSet) : (IQueryable<TEntity>) DbSet;
            return (@readonly ? dbSet.AsNoTracking() : dbSet).Where(parameters.WhereFilter);
        }

        protected async Task<PaginationResult<TNewEntity>> PagingAsync<TNewEntity>(
            PaginationParameters<TNewEntity> parameters, IQueryable<TNewEntity> pagingQuery) where TNewEntity : class
        {
            pagingQuery = parameters.SortType == SortTypeEnum.Ascending
                ? pagingQuery.OrderBy(parameters.ColumnOrder)
                : pagingQuery.OrderByDescending(parameters.ColumnOrder);

            return new PaginationResult<TNewEntity>
            {
                Count = await pagingQuery.CountAsync(),
                Entities = pagingQuery.Skip(parameters.Start).Take(parameters.AmountRows)
            };
        }
    }
}