using System.Collections.Generic;

namespace ProjetoWebVale.Utils
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public PagingData PagingData { get; set; } = new PagingData();
        public IEnumerable<T> Items { get; set; }
    }

    public class PagingData
    {
        public int TotalItems { get; set; }
        public int PageItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}