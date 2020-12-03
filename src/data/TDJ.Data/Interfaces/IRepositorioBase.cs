using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDJ.Dominio.Interfaces;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioBase<T> : IDisposable where T : IAggregateRoot
    {
       
    }
}
