using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility.ExtensionHelpers
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page = 1, int per_page = 3){
            var skipNumber = (page - 1) * per_page;
            return query.Skip(skipNumber).Take(per_page); 
        }
    }
}