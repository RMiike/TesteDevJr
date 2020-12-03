using Microsoft.AspNetCore.Mvc;
using System;
using TDJ.Dominio.ViewModel;

namespace TDJ.MVC.Controllers.v1
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("id")]
        public IActionResult ClienteDetalhe(Guid id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
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
