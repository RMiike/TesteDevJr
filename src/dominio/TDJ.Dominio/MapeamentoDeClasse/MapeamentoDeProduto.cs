using System.Collections.Generic;
using System.Linq;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.ViewModel;

namespace TDJ.Dominio.MapeamentoDeClasse
{
    public static class MapeamentoDeProduto
    {
        public static IEnumerable<ProdutoViewModel> ConverterProdutoParaModel(this IList<Produto> produtos)
        {
            return new List<ProdutoViewModel>(produtos.Select(p => new ProdutoViewModel(p.Id, p.Nome, p.Ativo)));
        }

        public static ProdutoViewModel ConverterProdutoParaModel(this Produto produto)
        {
            return new ProdutoViewModel(produto.Id, produto.Nome, produto.Ativo);
        }

        public static Produto ConverterModelParaProduto(this CriarProdutoViewModel criarProdutoViewModel)
        {
            return new Produto(criarProdutoViewModel.Nome, criarProdutoViewModel.Ativo);
        }
        public static Produto AtualizarProduto(this Produto produto, CriarProdutoViewModel atualizarProdutoViewModel)
        {
            produto.AlterarNome(atualizarProdutoViewModel.Nome);
            produto.AlterarAtivo(atualizarProdutoViewModel.Ativo);
            return produto;
        }
    }
}
