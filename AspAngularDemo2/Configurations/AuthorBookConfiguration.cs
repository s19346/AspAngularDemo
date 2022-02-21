using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.ToTable("Author_Book");

            builder.HasKey(ab => new { ab.IdAuthor, ab.IdBook }).HasName("AuthorBook_pk");
            builder.HasOne(ab => ab.IdAuthorNavigation)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Author_AuthorBook");
            builder.HasOne(ab => ab.IdBookNavigation)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Book_AuthorBook");

            IEnumerable<AuthorBook> authorBooks = new List<AuthorBook>
            {
                new AuthorBook { IdAuthor = 1, IdBook = 1 }
            };
            builder.HasData(authorBooks);
        }
    }
}
