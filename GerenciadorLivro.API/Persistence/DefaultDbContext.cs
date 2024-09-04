using GerenciadorLivro.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.API.Persistence
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLending> BookLendings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
    
                e.HasMany(u => u.Lendings)
                    .WithOne(bl => bl.User)
                    .HasForeignKey(bl => bl.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);

                e.HasMany(b => b.Lendings)
                    .WithOne(bl => bl.Book)
                    .HasForeignKey(bl => bl.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<BookLending>(e =>
            {
                e.HasKey(bl => bl.Id);
            });

            //base.OnModelCreating(builder);

        }
    }
}
