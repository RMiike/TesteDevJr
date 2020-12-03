using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Data.Interfaces;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.ViewModel;

namespace TDJ.MVC.Controllers.API.v1
{
    [Route("v1/cliente-api")]
    public class ClienteAPIController : Controller
    {
        private readonly IRepositorioDeCliente _repositorioDeCliente;

        public ClienteAPIController(IRepositorioDeCliente repositorioDeCliente)
        {
            _repositorioDeCliente = repositorioDeCliente;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Index()
        {
            var clientes = await _repositorioDeCliente.ObterTodos();
            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<Cliente> ClienteDetalhe(Guid id)
        {
            var cliente = await _repositorioDeCliente.ObterPorId(id);
            return cliente;
        }

        [HttpPost]
        public void Criar(ClienteViewModel clienteViewModel)
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        public void Atualizar(Guid id)
        {
            throw new NotImplementedException();

        }

        [HttpDelete("{id}")]
        public void Deletar(Guid id)
        {
            throw new NotImplementedException();

        }
    }
}
