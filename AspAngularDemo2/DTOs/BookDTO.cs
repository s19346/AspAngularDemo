using Backend.Models;

namespace Backend.DTOs
{
    public class BookDTO
    {
        public int IdBook { get; set; }
        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
