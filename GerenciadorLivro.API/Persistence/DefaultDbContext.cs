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
    
                e.HasMany(bl => bl.Lendings)
                    .WithOne(u => u.User)
                    .HasForeignKey(u => u.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);

                e.HasMany(bl => bl.Lendings)
                    .WithOne(b => b.Book)
                    .HasForeignKey(b => b.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<BookLending>(e =>
            {
                e.HasKey(bl => bl.Id);

                e.HasOne(u => u.User)
                    .WithMany(b => b.Lendings)
                    .HasForeignKey(u => u.IdUser);

                e.HasOne(b => b.Book)
                    .WithMany(b => b.Lendings)
                    .HasForeignKey(b => b.IdBook);
            });

            //base.OnModelCreating(builder);

        }
    }
}
