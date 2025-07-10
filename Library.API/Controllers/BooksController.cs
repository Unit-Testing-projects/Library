using Library.API.Data.Models;
using Library.API.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService bookService)
        {
            _service = bookService;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var item = _service.GetById(id);
            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet]
        // GET: api/<BooksController>
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id, item });
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }
    }
}
