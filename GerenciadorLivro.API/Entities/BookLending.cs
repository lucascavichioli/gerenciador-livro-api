namespace GerenciadorLivro.API.Entities
{
    public class BookLending
    {
        public BookLending(int idUser, int idBook, DateTime deadlineDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            LendingDate = DateTime.Now;
            DeadlineDate = deadlineDate;
            ReturnDate = null;
        }

        public int Id { get; set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LendingDate { get; private set; }
        public DateTime DeadlineDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        
        public string ProcessBookReturn() {
            ReturnDate = DateTime.Now;
            if (ReturnDate > DeadlineDate)
                return $"O livro está atrasado";
            else
                return "Livro está em dia";
        }
    }
}
