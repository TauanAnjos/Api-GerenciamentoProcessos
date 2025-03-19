using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class ProcessosRepository : IProcessosRepository
    {
        private readonly GerenciamentoProcessosContext _context;

        public ProcessosRepository(GerenciamentoProcessosContext context)
        {
            _context = context;
        }

        public Processo? BuscarProcessoPorClientePorId(Guid id)
        {
            return _context.Set<Processo>()
                .Include(x => x.Procurador)
                .Include(x => x.Cliente)
                .FirstOrDefault(x => x.ClienteId == id);
        }

        public Processo? BuscarProcessoPorId(Guid id)
        {
            return _context.Set<Processo>()
                .Include(x => x.DistribuicaoProcessos)
                .Include(x => x.Documentos)
                .Include(x => x.Prazos)
                .Include(x => x.Procurador)
                .FirstOrDefault(x => x.Id == id);
        }

        public void CriarProcesso(Processo processo)
        {
            _context.Processos.Add(processo);
            _context.SaveChanges();
        }

        public void DeletarProcesso(Processo processo)
        {
            _context.Processos.Remove(processo);
            _context.SaveChanges();
        }

        public void EditarProcesso(Processo processo)
        {
            _context.Processos.Update(processo);
            _context.SaveChanges();
        }

        public List<Processo> ListarProcessos()
        {
            return _context.Processos
                 .Include(x => x.DistribuicaoProcessos)
                 .Include(x => x.Documentos)
                 .Include(x => x.Prazos)
                 .Include(x => x.Procurador)
                 .Include(x => x.Cliente)
                 .ToList();
        }
    }
}
