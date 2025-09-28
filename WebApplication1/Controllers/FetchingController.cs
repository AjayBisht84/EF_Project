using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/Fetching")]
    [ApiController]
    public class FetchingController : ControllerBase
    {
        private readonly MyDbContext _a;
        public FetchingController(MyDbContext a)
        {
            _a = a;
        }

        [HttpPost("")]
        public IActionResult Insert([FromBody] Book b)
        {
            _a.books.Add(b);
            _a.SaveChanges();
            
            return Ok();
        }

        [HttpGet("find")]
        public IActionResult GetAll()
        {
            var data = _a.books.ToList();
            return Ok(data);
        }
        [HttpGet("find/{id}")]
        public IActionResult GetAll([FromRoute] int id)
        {
            var data = _a.books.Find(id);
            return Ok(data);
        }
        [HttpGet("delete/{id}")]
        public IActionResult delete([FromRoute] int id)
        {
            var data = _a.books.Where(x=>x.ID==id).ExecuteDelete();
            return Ok(data);
        }
        [HttpGet("update/{id}")]
        public IActionResult update([FromRoute] int id)
        {
            var data = _a.books.Where(x=>x.ID==id).ExecuteUpdate(x=>x.SetProperty(p=>p.Name,p=>p.Name+ "--"));
            return Ok(data);
        }
    }
}
