using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioDeProduto : IRepositorioBase<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }

}
