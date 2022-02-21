namespace Backend.Models
{
    public class AuthorBook
    {
        public int IdAuthor { get; set; }
        public int IdBook { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Book IdBookNavigation { get; set; }
    }
}
