using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.HasKey(a => a.IdAuthor).HasName("Author_pk");
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(48);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(48);

            IEnumerable<Author> authors = new List<Author>
            {
                new Author
                {
                    IdAuthor = 1,
                    FirstName = "Stephen",
                    LastName = "King"
                }
            };
            builder.HasData(authors);
        }
    }
}
