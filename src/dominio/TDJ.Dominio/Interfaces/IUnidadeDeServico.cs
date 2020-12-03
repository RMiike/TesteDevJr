using System.Threading.Tasks;

namespace TDJ.Dominio.Interfaces
{
    public interface IUnidadeDeServico
    {
        Task<bool> Commit();
    }
}
