namespace GerenciadorLivro.API.Models
{
    public class CreateBookInputViewModel
    {
        public string Title { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int YearPublication { get; set; }
    }
}
