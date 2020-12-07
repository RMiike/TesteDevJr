using System;
using TDJ.Dominio.Interfaces;

namespace TDJ.Dominio.ViewModel
{
    public class ProdutoViewModel : IAggregateRootViewModel
    {

        public ProdutoViewModel(Guid id, string nome, bool ativo)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
    public class CriarProdutoViewModel : IAggregateRootViewModel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } 
    }


}
