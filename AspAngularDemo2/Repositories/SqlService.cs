using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class SqlService  : IDbService
    {
        private readonly Context _context;
        private Dictionary<int, int> idBookToNumberOfAuthors;

        public SqlService(Context context)
        {
            _context = context;
            idBookToNumberOfAuthors = _context.Books.Select(b => new { b.IdBook, b.AuthorBooks.Count }).ToDictionary(b => b.IdBook, b => b.Count);
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> RemoveAuthorAsync(int idAuthor)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(a => a.IdAuthor == idAuthor);
            if (author == null)
            {
                return false;
            }
            var authorBooks = await _context.AuthorBooks.Where(a => a.IdAuthor == author.IdAuthor).ToListAsync();
            if (authorBooks.Any())
            {
                var idBooksToRemove = authorBooks.Where(ab => idBookToNumberOfAuthors.GetValueOrDefault(ab.IdBook) == 1).Select(ab => ab.IdBook);
                var booksToRemove = await _context.Books.Where(b => idBooksToRemove.Contains(b.IdBook)).ToListAsync();
                _context.RemoveRange(authorBooks);
                _context.Books.RemoveRange(booksToRemove);
            }
            _context.Remove(author);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAuthorAsync(int idAuthor, Author newAuthor)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(a => a.IdAuthor == idAuthor);
            if (author == null)
            {
                return false;
            }
            author.FirstName = newAuthor.FirstName;
            author.LastName = newAuthor.LastName;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<BookDTO>> GetBooksAsync()
        {
            return await _context.Books
                .Include(b => b.AuthorBooks)
                .ThenInclude(ab => ab.IdAuthorNavigation)
                .Select(b => new BookDTO
                {
                    IdBook = b.IdBook,
                    Title = b.Title,
                    Authors = b.AuthorBooks.Select(a => a.IdAuthorNavigation).ToList()
                }).ToListAsync();
        }

        public async Task<BookDTO> AddBookAsync(BookDTO book)
        {
            ICollection<AuthorBook> newABs = new List<AuthorBook>();
            Book newBook = new Book { Title = book.Title };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            foreach (var author in book.Authors)
            {
                newABs.Add(new AuthorBook { IdAuthor = author.IdAuthor, IdBook = newBook.IdBook });
            }
            await _context.AuthorBooks.AddRangeAsync(newABs);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> RemoveBookAsync(int idBook)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.IdBook == idBook);
            if (book == null)
            {
                return false;
            }
            var authorBooks = await _context.AuthorBooks.Where(a => a.IdBook == book.IdBook).ToListAsync();
            if (authorBooks.Any())
            {
                _context.RemoveRange(authorBooks);
            }
            _context.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
