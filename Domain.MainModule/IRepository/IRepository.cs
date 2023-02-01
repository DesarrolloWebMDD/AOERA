using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Core.Pagination;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.CrossCutting.Wrapper;

namespace Domain.MainModule.IRepository
{
    public interface IRepository<TEntity, in TId> where TEntity : class
    {
        Task<TEntity> GetAsync(TId id);

        IQueryable<TEntity> All(bool @readonly = true);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            bool @readonly = true);

        IQueryable<TEntity> FindOrTermi(Expression<Func<TEntity, bool>> predicate,
            string tipo, int page, int size, bool @readonly = true);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task<ValidationResult> AddAsync(TEntity entity, params IValidator<TEntity>[] validaciones);

        Task<ValidationResult> AddAsync(TEntity entity, IValidator<TEntity> validation);

        Task<ValidationResult> UpdateAsync(TEntity entity, params IValidator<TEntity>[] validaciones);

        Task<TEntity> AddAsync(TEntity entity);

        Task<ValidationResult> UpdateAsync(TEntity entity, IValidator<TEntity> validation);

        Task<ValidationResult> DeleteAsync(TEntity entity, params IValidator<TEntity>[] validaciones);

        Task<ValidationResult> DeleteAsync(TEntity entity, IValidator<TEntity> validation);

        Task<ValidationResult> ValidateEntityAsync(TEntity entity, IValidator<TEntity> validation);

        Task<ValidationResult> ValidateEntityAsync(TEntity entity, IEnumerable<IValidator<TEntity>> validations);

        Task<IEnumerable<TDto>> RunSqlQuery<TDto>(string storeProcedure, object parameters = null);

        Task<string> StringResultProcedure(string storeProcedure, object parameters = null);

        Task<ValidationResult> AddEntityAsync(TEntity entity, ValidationResult validationResultEntity);

        Task<PaginationResult<TEntity>> FindAllPagingAsync(PaginationParameters<TEntity> parameters,
            bool @readonly = true);
    }
}