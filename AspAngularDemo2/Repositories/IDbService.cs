using Backend.DTOs;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IDbService
    {
        public Task<ICollection<Author>> GetAuthorsAsync();
        public Task<Author> AddAuthorAsync(Author author);
        public Task<bool> RemoveAuthorAsync(int idAuthor);
        public Task<bool> UpdateAuthorAsync(int idAuthor, Author newAuthor);
        public Task<ICollection<BookDTO>> GetBooksAsync();
        public Task<BookDTO> AddBookAsync(BookDTO book);
        public Task<bool> RemoveBookAsync(int idBook);
    }
}
