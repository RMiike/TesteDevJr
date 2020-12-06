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
    public class RepositorioDeProduto : IRepositorioDeProduto
    {

        private readonly TDJDbContext _context;
        public IUnidadeDeServico UnidadeDeServico => _context;
        public RepositorioDeProduto(TDJDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Produto>> ObterTodos()
        {
            return await _context.Produtos.Where(p => p.Ativo == true)
                                          .AsNoTracking()
                                          .ToListAsync();
        }
        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.Where(p => p.Ativo == true && p.Id == id)
                                          .FirstOrDefaultAsync();
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            var resultado = await _context.Produtos.AddAsync(produto);
            _context.Commit();

            return resultado.Entity;
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.Commit();
        }
        public void Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.Commit();

        }
        public void Dispose()
        {
            _context?.Dispose();
        }


    }
}
