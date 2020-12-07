using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.Entidades;

namespace TDJ.Servicos.Interfaces
{
    public interface IServicosDeCliente
    {
        Task<ResultadoCustomizado> ObterTodos();
        Task<ResultadoCustomizado> ObterPorId(Guid id);
    }
}
