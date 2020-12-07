using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.MVC.Controllers.API.v1
{
    [Route("v1/cliente-api")]
    public class ClienteAPIController : MainController
    {
        private readonly IServicosDeAPIDeCliente _servicosDeAPIDeCliente;

        public ClienteAPIController(IServicosDeAPIDeCliente servicosDeAPIDeCliente)
        {
            _servicosDeAPIDeCliente = servicosDeAPIDeCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _servicosDeAPIDeCliente.ObterTodos();
            return clientes == null ? NotFound() : RespostaCustomizada(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ClienteDetalhe(Guid id)
        {
            var cliente = await _servicosDeAPIDeCliente.ObterPorId(id);
            return cliente == null ? NotFound() : RespostaCustomizada(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarClienteViewModel clienteViewModel)
        {
            var cliente = await _servicosDeAPIDeCliente.Adicionar(clienteViewModel);
            return cliente == null ? BadRequest() : RespostaCustomizada(cliente);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] CriarClienteViewModel clienteViewModel)
        {
            var cliente = await _servicosDeAPIDeCliente.Atualizar(id, clienteViewModel);
            return cliente == null ? BadRequest() : RespostaCustomizada(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var resultado = await _servicosDeAPIDeCliente.Deletar(id);
            return RespostaCustomizada(resultado);

        }
    }
}
