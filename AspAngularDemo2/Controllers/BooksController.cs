using Backend.DTOs;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IDbService _dbService;

        public BooksController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _dbService.GetBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> PostBookAsync([FromBody] BookDTO book)
        {
            var added = await _dbService.AddBookAsync(book);
            return Ok(added);
        }

        [HttpDelete("{idBook}")]
        public async Task<IActionResult> DeleteAuthorAsync(int idBook)
        {
            await _dbService.RemoveBookAsync(idBook);
            return Ok("Removed");
        }
    }
}
