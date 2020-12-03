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
        public void Criar([FromBody] ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto( produtoViewModel.Nome);
            _repositorioDeProduto.Adicionar(produto);
        }


        [HttpPut("{id}")]
        public async Task<Produto> Atualizar( Guid id, [FromBody] ProdutoViewModel produtoViewModel)
        {
           var produto = await _repositorioDeProduto.ObterPorId(id);
            produto.Nome = produtoViewModel.Nome;
            _repositorioDeProduto.Atualizar(produto);
            return produto;

        }

        [HttpDelete("{id}")]
        public async Task<Produto> Deletar(Guid id)
        {
            var produto = await _repositorioDeProduto.ObterPorId(id);
            produto.Ativo = false;
            _repositorioDeProduto.Atualizar(produto);
            return produto;


        }

    }
}
