using System.Collections.Generic;
using System.Linq;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.ViewModel;

namespace TDJ.Dominio.MapeamentoDeClasse
{
    public static class MapeamentoDeCliente
    {

        public static IEnumerable<ClienteViewModel> ConverterParaViewModel(this IList<Cliente> cliente)
        {
            return new List<ClienteViewModel>(cliente.Select(c => new ClienteViewModel(c.Id, c.Nome, c.Email, c.CPF, c.IdDoProduto, c.Produto.Nome)));
        }
        public static ClienteViewModel ConverterParaViewModel(this Cliente cliente)
        {
            return new ClienteViewModel(cliente.Id, cliente.Nome, cliente.Email, cliente.CPF, cliente.IdDoProduto, cliente.Produto != null ? cliente.Produto.Nome : null);
        }

        public static Cliente ConverterParaCliente(this CriarClienteViewModel criarClienteViewModel)
        {
            return new Cliente(criarClienteViewModel.Nome, criarClienteViewModel.Email, MascaraCPF(criarClienteViewModel.CPF), criarClienteViewModel.IdDoProduto);
        }
        public static Cliente AtualizarCliente(this Cliente cliente, CriarClienteViewModel criarClienteViewModel)
        {
            cliente.AlterarCPF(MascaraCPF(criarClienteViewModel.CPF));
            cliente.AlterarEmail(criarClienteViewModel.Email);
            cliente.AlterarNome(criarClienteViewModel.Nome);
            return cliente;
        }
        private static string MascaraCPF(string cpf)
        {
            cpf = cpf.Replace(" ", "");
            cpf = cpf.Replace("-", "");
            cpf = cpf.Replace(".", "");
            return cpf;
        }
    }
}
