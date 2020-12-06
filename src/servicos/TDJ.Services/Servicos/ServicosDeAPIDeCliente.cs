using System;
using System.Threading.Tasks;
using TDJ.Data.Interfaces;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.MapeamentoDeClasse;
using TDJ.Dominio.ViewModel;

namespace TDJ.Servicos.Interfaces
{
    public class ServicosDeAPIDeCliente : IServicosDeAPIDeCliente
    {

        private readonly IRepositorioDeCliente _repositorioDeCliente;
        public ResultadoCustomizado resultado;

        public ServicosDeAPIDeCliente(IRepositorioDeCliente repositorioDeCliente)
        {
            resultado = new ResultadoCustomizado();
            _repositorioDeCliente = repositorioDeCliente;
        }

        public async Task<ResultadoCustomizado> ObterTodos()
        {
            var clientes = await _repositorioDeCliente.ObterTodos();

            if( clientes == null )
            {
                resultado.AdicionarMensagem("Não existem clientes cadastrados.");
                resultado.Sucesso(false);
                return resultado;
            }

            foreach( var cliente in clientes )
            {
                if( !cliente.Valido() )
                {
                    resultado.AdicionarMensagensDeErro(cliente.ErrorMessages);
                }

            }

            if( resultado.Erros.Mensagens.Count < 0 )
            {

                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            resultado.AdicionarMensagem("Clientes encontrado.");
            resultado.AdicionarObjeto(clientes.ConverterParaViewModel());
            resultado.Sucesso(true);
            return resultado;

        }

        public async Task<ResultadoCustomizado> ObterPorId(Guid id)
        {
            var cliente = await _repositorioDeCliente.ObterPorId(id);

            if( cliente == null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Id invalido" });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }
            if( !cliente.Valido() )
            {

                resultado.AdicionarMensagensDeErro(cliente.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }


            resultado.AdicionarMensagem("Cliente encontrado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(cliente.ConverterParaViewModel());
            return resultado;

        }


        public async Task<ResultadoCustomizado> Adicionar(CriarClienteViewModel view)
        {
            var cliente = view.ConverterParaCliente();


            if( !cliente.Valido() )
            {
                resultado.AdicionarMensagensDeErro(cliente.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            var clienteExiste = await _repositorioDeCliente.ObterPorIdDeProduto(view.IdDoProduto);

            if( clienteExiste != null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Id de produto já se encontra em uso." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }
            clienteExiste = await _repositorioDeCliente.ObterPorEmail(view.Email);


            if( clienteExiste != null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Email de cliente já cadastrado." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }
            clienteExiste = await _repositorioDeCliente.ObterPorCPF(cliente.CPF);
            if( clienteExiste != null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "CPF de cliente já cadastrado." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            await _repositorioDeCliente.Adicionar(cliente);

            resultado.AdicionarMensagem("Cliente cadastrado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(cliente.ConverterParaViewModel());
            return resultado;

        }

        public async Task<ResultadoCustomizado> Atualizar(Guid id, CriarClienteViewModel view)
        {
            var cliente = await _repositorioDeCliente.ObterPorId(id);

            if( cliente == null || string.IsNullOrEmpty(view.CPF) || string.IsNullOrEmpty(view.Email) || string.IsNullOrEmpty(view.Nome) )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Dados invalidos." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }


            var clienteExiste = await _repositorioDeCliente.ObterPorEmail(view.Email);
            if( clienteExiste != null && cliente.Email != view.Email )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "Email de cliente já cadastrado." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            clienteExiste = await _repositorioDeCliente.ObterPorCPF(view.CPF);
            if( clienteExiste != null && cliente.CPF != view.CPF )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "CPF de cliente já cadastrado." });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            clienteExiste = await _repositorioDeCliente.ObterPorCPF(cliente.CPF);
            clienteExiste.AtualizarCliente(view);

            if( !clienteExiste.Valido() )
            {
                resultado.AdicionarMensagensDeErro(clienteExiste.ErrorMessages);
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            _repositorioDeCliente.Atualizar(clienteExiste);

            resultado.AdicionarMensagem("Cliente atualizado.");
            resultado.Sucesso(true);
            resultado.AdicionarObjeto(clienteExiste.ConverterParaViewModel());
            return resultado;

        }

        public async Task<ResultadoCustomizado> Deletar(Guid id)
        {

            var cliente = await _repositorioDeCliente.ObterPorId(id);


            if( cliente == null )
            {
                resultado.AdicionarMensagensDeErro(new string[] { "cliente não encontrado" });
                resultado.AdicionarMensagem("Erro encontrado.");
                resultado.Sucesso(false);
                return resultado;
            }

            _repositorioDeCliente.Deletar(cliente);
            resultado.AdicionarMensagem("cliente deletado com sucesso.");
            resultado.Sucesso(true);
            return resultado;
        }
    }
}
