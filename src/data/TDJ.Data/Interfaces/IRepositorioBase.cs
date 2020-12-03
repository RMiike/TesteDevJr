using System;
using TDJ.Dominio.Interfaces;

namespace TDJ.Data.Interfaces
{
    public interface IRepositorioBase<T> : IDisposable where T : IAggregateRoot
    {

    }
}
