using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class PrazoRepository : IPrazoRepository
    {
        private readonly GerenciamentoProcessosContext _context;

        public PrazoRepository(GerenciamentoProcessosContext context)
        {
            _context = context;
        }

        public Prazo? BuscarPrazoPorId(Guid id)
        {
           return _context.Set<Prazo>()
                .Include(x => x.Processo)
                .FirstOrDefault(x => x.Id == id);
        }

        public void CriarPrazo(Prazo prazo)
        {
            _context.Prazos.Add(prazo);
            _context.SaveChanges();
        }

        public void DeletarPrazo(Prazo prazo)
        {
            _context.Prazos.Remove(prazo);
            _context.SaveChanges();
        }

        public void EditarPrazo(Prazo prazo)
        {
            _context.Prazos.Update(prazo);
            _context.SaveChanges();
        }

        public List<Prazo> ListarPrazo()
        {
            return _context.Prazos
                .Include(x => x.Processo)
                .ToList();
        }
    }
}
