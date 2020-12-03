using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TDJ.Servicos.Interfaces;

namespace TDJ.MVC.Controllers.v1
{
    [Route("v1/produto")]
    public class ProdutoController : Controller
    {

        private readonly IServicosDeProduto _servicosDeProduto;

        public ProdutoController(IServicosDeProduto servicosDeProduto)
        {
            _servicosDeProduto = servicosDeProduto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _servicosDeProduto.ObterTodos();
            return View(produtos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var produto = await _servicosDeProduto.ObterPorId(id);
            return View(produto);
        }
    }
}
