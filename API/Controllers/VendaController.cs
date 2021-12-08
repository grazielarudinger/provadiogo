using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        //POST: api/venda/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
			//Primeira forma
            // List<ItemVenda> itensBanco = new List<ItemVenda>();
            // foreach (var item in venda.Itens)
            // {
            //     itensBanco.Add(new ItemVenda
            //     {
            //         ProdutoId = item.ProdutoId,
            //         Quantidade = item.Quantidade,
            //         Preco = item.Preco,
            //         Produto = _context.Produtos.FirstOrDefault(x => x.Id == item.ProdutoId)
            //     });
            // }
			//Segunda forma
            venda.Itens = _context.ItensVenda
                .Include(item => item.Produto.Categoria)
                .Where(item => item.CarrinhoId == venda.CarrinhoId).ToList();
            venda.Forma = _context.FormasPagamento.FirstOrDefault(x => x.Id == venda.FormaId);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_context.Vendas.
                Include(f => f.Forma).
                Include(i => i.Itens).
                ThenInclude(p => p.Produto.Categoria).
                ToList());
        }
    }
}