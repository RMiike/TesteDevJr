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
        public async Task<IList<Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking()
                                 .Select(c => new Cliente(c.Id, c.Nome, c.Email, c.CPF, c.IdDoProduto, c.Produto))
                                 .ToListAsync();
        }
        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _context.Clientes.Where(p => p.Id == id)
                                          .Select(c => new Cliente(c.Id, c.Nome, c.Email, c.CPF, c.IdDoProduto, c.Produto))
                                          .FirstOrDefaultAsync();
        }
        public async Task<Cliente> ObterPorEmail(string email)
        {

            return await _context.Clientes.Where(p => p.Email == email)
                                         .FirstOrDefaultAsync();
        }
        public async Task<Cliente> ObterPorIdDeProduto(Guid idDeProduto)
        {
            return await _context.Clientes.Where(p => p.IdDoProduto == idDeProduto)
                                         .FirstOrDefaultAsync();
        }
        public async Task<Cliente> ObterPorCPF(string cpf)
        {
            return await _context.Clientes.Where(p => p.CPF == cpf)
                                         .FirstOrDefaultAsync();
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            var resultado = await _context.Clientes.AddAsync(cliente);
            _context.Commit();
            return resultado.Entity;
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.Commit();
        }

        public void Deletar(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.Commit();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }


    }
}
