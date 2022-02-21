using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AuthorsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            var authors = await _dbService.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthorAsync([FromBody] Author author)
        {
            var added = await _dbService.AddAuthorAsync(author);
            return Ok(added);
        }

        [HttpDelete("{idAuthor}")]
        public async Task<IActionResult> DeleteAuthorAsync(int idAuthor)
        {
            await _dbService.RemoveAuthorAsync(idAuthor);
            return Ok("Removed");
        }

        [HttpPut("{idAuthor}")]
        public async Task<IActionResult> PutAuthorAsync(int idAuthor, [FromBody]Author author)
        {
            await _dbService.UpdateAuthorAsync(idAuthor, author);
            return Ok("Updated");
        }
    }
}
