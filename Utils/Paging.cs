using System.Collections.Generic;
using System.Linq;
using ProjetoWebVale.Utils;

namespace ProjetoWebVale.Utils
{
    public static class Paging
    {
        public static List<T> ApplyPaging<T>(this List<T> query, GenericFilter<T> filter)
        {
            if (filter.Page <= 0)
                filter.Page = 1;

            if (filter.PageSize <= 0)
                filter.PageSize = 10;

            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, GenericFilter<T> filter)
        {
            if (filter.Page <= 0)
                filter.Page = 1;

            if (filter.PageSize <= 0)
                filter.PageSize = 10;

            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}