using System;
using System.Threading.Tasks;
using TDJ.Dominio.Interfaces;

namespace TDJ.Servicos.Interfaces
{
    public interface IServicoDeAPI<T, V> where T : class where V : IAggregateRootViewModel
    {
        Task<T> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task<T> Adicionar(V view);
        Task<T> Atualizar(Guid id, V view);
        Task<T> Deletar(Guid id);
    }
}
