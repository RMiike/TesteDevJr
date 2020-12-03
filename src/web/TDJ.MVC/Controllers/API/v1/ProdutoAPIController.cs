using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Data.Interfaces;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.ViewModel;

namespace TDJ.MVC.Controllers.API.v1
{
    [Route("v1/produto-api")]
    public class ProdutoAPIController : Controller
    {

        private readonly IRepositorioDeProduto _repositorioDeProduto;

        public ProdutoAPIController(IRepositorioDeProduto repositorioDeProduto)
        {
            _repositorioDeProduto = repositorioDeProduto;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Index()
        {
            var produtos = await _repositorioDeProduto.ObterTodos();
            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            var produto = await _repositorioDeProduto.ObterPorId(id);
            return produto;
        }

        [HttpPost]
        public void Criar(ProdutoViewModel produtoViewModel)
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
