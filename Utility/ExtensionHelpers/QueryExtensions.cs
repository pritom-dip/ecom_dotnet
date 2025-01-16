using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Utility.ExtensionHelpers
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page = 1, int per_page = 3){
            int skipNumber = (page - 1) * per_page;
            return query.Skip(skipNumber).Take(per_page); 
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, string sortBy = "id", string sortOrder = "desc")
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

            if (sortOrder.ToLower() == "asc"){
                return query.OrderBy(lambda);
            }
            return query.OrderByDescending(lambda);
        }
    }
}