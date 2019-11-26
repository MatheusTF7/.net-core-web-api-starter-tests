namespace ProjetoWebVale.Utils
{
    public abstract class GenericFilter<T>
    {
         public long? Id { get; set; } = null;

         public int Page { get; set; } = 1;

         public int PageSize { get; set; } = 5;

         public bool? getAll { get; set; } = false;
    }
}