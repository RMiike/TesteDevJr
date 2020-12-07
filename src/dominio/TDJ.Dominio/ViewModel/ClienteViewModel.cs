using System;
using TDJ.Dominio.Interfaces;

namespace TDJ.Dominio.ViewModel
{
    public class ClienteViewModel : IAggregateRootViewModel
    {
        public ClienteViewModel(Guid id, string nome, string email, string cPF, Guid idDoProduto, string nomeDoProduto)
        {
            Id = id;
            Nome = nome;
            Email = email;
            CPF = cPF;
            IdDoProduto = idDoProduto;
            NomeDoProduto = nomeDoProduto;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Guid IdDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
    }
    public class CriarClienteViewModel : IAggregateRootViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Guid IdDoProduto { get; set; }
    }
}