using System;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.CrossCutting.Enum;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Core.Pagination
{
    public class PaginationParameters<T> where T : class
    {
        public Expression<Func<T, object>> ColumnOrder { get; set; }
        public SortTypeEnum SortType { get; set; }
        public int Start { get; set; }
        public int AmountRows { get; set; }
        public Expression<Func<T, bool>> WhereFilter { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }
    }
}