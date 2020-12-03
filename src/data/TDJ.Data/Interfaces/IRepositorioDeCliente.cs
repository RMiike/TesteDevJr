using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioDeCliente : IRepositorioBase<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorId(Guid id);
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
    }
}
