using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { Id = 1, Nome = "Alimento" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { Id = 1, Nome = "Arroz", Preco = 234, Quantidade = 24, CategoriaId = 1 },
                    new Produto { Id = 2, Nome = "Bolacha", Preco = 6, Quantidade = 423, CategoriaId = 1 },
                    new Produto { Id = 3, Nome = "Feijão", Preco = 64, Quantidade = 23, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}