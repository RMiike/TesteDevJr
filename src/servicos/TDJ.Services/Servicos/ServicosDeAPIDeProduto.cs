using System;
using System.Threading.Tasks;
using TDJ.Data.Interfaces;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.MapeamentoDeClasse;
using TDJ.Dominio.ViewModel;
using TDJ.Servicos.Interfaces;

namespace TDJ.Servicos.Servicos
{
    public class ServicosDeAPIDeProduto : IServicosDeAPIDeProduto
    {

        private readonly IRepositorioDeProduto _repository;
        public ResultadoCustomizado resultado;
        public ServicosDeAPIDeProduto(IRepositorioDeProduto repository)
        {
            resultado = new ResultadoCustomizado();
            _repository = repository;
        }
        public async Task<ResultadoCustomizado> ObterTodos()
        {
            var resultado = new ResultadoCustomizado();

            var produtos = await _repository.ObterTodos();

            if( produtos == null )
            {
                resultado.AdicionarMensagem("Não existem produtos cadastrados.");
                resultado.Sucesso(false);
                return resultado;
            }

            foreach( var produto in produtos )
            {
                if( !produto.Valido() )
                {
                    resultado.AdicionarMensagensDeErro(produto.ErrorMessages);
                }

            }

            if( resultado.Erros.Mensagens.Count < 0 )
            {

                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            resultado.AdicionarMensagem("Produtos encontrado.");
            resultado.AdicionarObjeto(produtos.ConverterProdutoParaModel());
            resultado.Sucesso(true);
            return resultado;

        }


        public async Task<ResultadoCustomizado> ObterPorId(Guid id)
        {

            var produto = await _repository.ObterPorId(id);

            if( produto == null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Id invalido" });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }
            if( !produto.Valido() )
            {

                resultado.AdicionarMensagensDeErro(produto.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            resultado.AdicionarMensagem("Produto encontrado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(produto.ConverterProdutoParaModel());
            return resultado;

        }
        public async Task<ResultadoCustomizado> Adicionar(CriarProdutoViewModel view)
        {

            var produto = view.ConverterModelParaProduto();

            if( !produto.Valido() )
            {
                resultado.AdicionarMensagensDeErro(produto.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            await _repository.Adicionar(produto);

            resultado.AdicionarMensagem("Produto cadastrado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(produto.ConverterProdutoParaModel());
            return resultado;

        }
        public async Task<ResultadoCustomizado> Atualizar(Guid id, CriarProdutoViewModel view)
        {

            var produto = await _repository.ObterPorId(id);

            if( produto == null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "produto não encontrado" });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            if( !produto.Valido() )
            {
                resultado.AdicionarMensagensDeErro(produto.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            produto.AtualizarProduto(view);
            _repository.Atualizar(produto);

            resultado.AdicionarMensagem("Produto atualizado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(produto.ConverterProdutoParaModel());
            return resultado;

        }

        public async Task<ResultadoCustomizado> Deletar(Guid id)
        {

            var produto = await _repository.ObterPorId(id);

            if( produto == null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "produto não encontrado" });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            try
            {

                _repository.Deletar(produto);
                resultado.AdicionarMensagem("Produto deletado com sucesso.");
                resultado.Sucesso(true);
                return resultado;
            } catch( Exception e )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Produto vinculado a um cliente.", e.InnerException.Message });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }


        }

    }
}
