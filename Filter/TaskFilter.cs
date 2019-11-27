using ProjetoWebVale.Models;
using ProjetoWebVale.Utils;

namespace ProjetoWebVale.Filter
{
    public class TaskFilter : GenericFilter<Task>
    {
        public long? AccountId { get; set; }

        public long? UserId { get; set; }
    }
}