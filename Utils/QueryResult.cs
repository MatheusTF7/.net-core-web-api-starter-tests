using System.Collections.Generic;

namespace ProjetoWebVale.Utils
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}