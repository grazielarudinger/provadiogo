using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/forma")]
    public class FormaController : ControllerBase
    {
        private readonly DataContext _context;
        public FormaController(DataContext context)
        {
            _context = context;
        }

        //POST: api/forma/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormaPagamento forma)
        {
            _context.FormasPagamento.Add(forma);
            _context.SaveChanges();
            return Created("", forma);
        }

        //GET: api/forma/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.FormasPagamento.ToList());

    }
}