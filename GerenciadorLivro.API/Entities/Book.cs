namespace GerenciadorLivro.API.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string autor, string iSBN, int yearPublication)
            : base()
        {
            Title = title;
            Autor = autor;
            ISBN = iSBN;
            YearPublication = yearPublication;
        }

        public string Title { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublication { get; private set; }
    }
}
