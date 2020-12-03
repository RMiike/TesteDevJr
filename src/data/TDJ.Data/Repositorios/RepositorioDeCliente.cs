using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDJ.Data.Interfaces;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.Interfaces;
using TDJ.Repositorio.Contexto;

namespace TDJ.Data.Repositorios
{
    public class RepositorioDeCliente : IRepositorioDeCliente
    {

        private readonly TDJDbContext _context;
        public IUnidadeDeServico UnidadeDeServico => _context;
        public RepositorioDeCliente(TDJDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking()
                                          .ToListAsync();
        }
        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _context.Clientes.Where(p => p.Id == id)
                                         .FirstOrDefaultAsync();
        }

        public void Adicionar(Cliente type)
        {
            _context.Clientes.Add(type);
        }

        public void Atualizar(Cliente type)
        {
            _context.Clientes.Update(type);

        }

        public void Dispose()
        {
            _context?.Dispose();
        }


    }
}
