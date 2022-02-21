using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(b => b.IdBook).HasName("Book_pk");
            builder.Property(b => b.Title).IsRequired().HasMaxLength(128);

            IEnumerable<Book> books = new List<Book>
            {
                new Book { IdBook = 1, Title = "Misery"}
            };
            builder.HasData(books);
        }
    }
}
