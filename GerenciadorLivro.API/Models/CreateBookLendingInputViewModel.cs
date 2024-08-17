using GerenciadorLivro.API.Entities;

namespace GerenciadorLivro.API.Models
{
    public class CreateBookLendingInputViewModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
