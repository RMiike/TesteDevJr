using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.Interfaces;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioBase<T> : IDisposable where T : IAggregateRoot
    {
        Task<IList<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);

        Task<T> Adicionar(T tipo);
        void Atualizar(T tipo);
        void Deletar(T tipo);
    }
}
