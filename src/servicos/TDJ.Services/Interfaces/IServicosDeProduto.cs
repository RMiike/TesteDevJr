using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.ViewModel;

namespace TDJ.Servicos.Interfaces
{
    public interface IServicosDeProduto
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
