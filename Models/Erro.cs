namespace ProjetoWebVale.Models
{
    public class Erro
    {
        public Erro () {}

        public Erro (string message)
        {
            this.message = message;
        }

        public string message { get; set; }
    }
}