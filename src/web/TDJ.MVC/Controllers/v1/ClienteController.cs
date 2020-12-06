using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.MVC.Controllers.v1
{
    [Route("v1/cliente")]
    public class ClienteController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IServicosDeCliente _servicosDeCliente)
        {
            var clientes = await _servicosDeCliente.ObterTodos();
            return View(clientes);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ClienteDetalhe(Guid id,
                                                        [FromServices] IServicosDeCliente _servicosDeCliente)
        {
            var cliente = await _servicosDeCliente.ObterPorId(id);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult Criar(ClienteViewModel clienteViewModel)
        {
            return View();
        }

        [HttpPut("id")]
        public IActionResult Atualizar(Guid id)
        {
            return View();
        }

        [HttpDelete("id")]
        public IActionResult Deletar(Guid id)
        {
            return View();
        }
    }
}
