using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.MVC.Controllers.API.v1
{
    [Route("v1/produto-api")]
    public class ProdutoAPIController : MainController
    {

        private readonly IServicosDeAPIDeProduto _servicosDeAPIDeProduto;

        public ProdutoAPIController(IServicosDeAPIDeProduto servicosDeAPIDeProduto)
        {
            _servicosDeAPIDeProduto = servicosDeAPIDeProduto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var resultado = await _servicosDeAPIDeProduto.ObterTodos();

            return RespostaCustomizada(resultado);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var resultado = await _servicosDeAPIDeProduto.ObterPorId(id);
            return RespostaCustomizada(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoViewModel produtoViewModel)
        {
            var cliente = await _servicosDeAPIDeProduto.Adicionar(produtoViewModel);
            return cliente == null ? BadRequest() : RespostaCustomizada(cliente);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] CriarProdutoViewModel produtoViewModel)
        {
            var cliente = await _servicosDeAPIDeProduto.Atualizar(id, produtoViewModel);
            return cliente == null ? BadRequest() : RespostaCustomizada(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var resultado = await _servicosDeAPIDeProduto.Deletar(id);
            return RespostaCustomizada(resultado);

        }

    }
}
