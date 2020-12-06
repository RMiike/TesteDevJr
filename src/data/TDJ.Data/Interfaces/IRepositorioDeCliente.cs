using System;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioDeCliente : IRepositorioBase<Cliente>
    {
        Task<Cliente> ObterPorEmail(string email);
        Task<Cliente> ObterPorCPF(string cpf);
        Task<Cliente> ObterPorIdDeProduto(Guid idDeProduto);

    }
}
