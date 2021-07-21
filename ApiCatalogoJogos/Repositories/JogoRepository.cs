using ApiCatalogoJogos.Data;
using ApiCatalogoJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoDbContext _context;

        public JogoRepository(JogoDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Jogo jogo)
        {
            _context.Entry(jogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Inserir(Jogo jogo)
        {
            _context.Add(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task<IPagedList<Jogo>> Obter(int pagina, int quantidade)
        {
            return await _context.Jogo.ToPagedListAsync(pagina, quantidade);
        }

        public async Task<Jogo> Obter(Guid id)
        {
            return await _context.Jogo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return await _context.Jogo.Where(x => x.Nome == nome && x.Produtora == produtora).ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            var jogo = await Obter(id);

            _context.Remove(jogo);
            await _context.SaveChangesAsync();
        }

    }
}
