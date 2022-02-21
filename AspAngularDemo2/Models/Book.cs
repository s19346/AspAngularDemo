namespace Backend.Models
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public Book()
        {
            AuthorBooks = new List<AuthorBook>();
        }
    }
}
