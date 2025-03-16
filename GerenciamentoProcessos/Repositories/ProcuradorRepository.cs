using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class ProcuradorRepository : IProcuradorRepository
    {

        private readonly GerenciamentoProcessosContext _context;

        public ProcuradorRepository(GerenciamentoProcessosContext context) {
            _context = context;
        }

        public Procurador? BuscarProcuradorPorId(Guid id)
        {
            return _context.Set<Procurador>()
                .Include(x => x.DistribuicaoProcessoProcuradorDestinos)
                .Include(x => x.DistribuicaoProcessoProcuradorOrigems)
                .Include(x => x.Processos
                )
                .FirstOrDefault(p => p.Id == id);
        }

        public void CriarProcurador(Procurador procurador)
        {
            _context.Procuradors.Add(procurador);
            _context.SaveChanges();
        }

        public void DeletarProcurador(Procurador procurador)
        {
            _context.Procuradors.Remove(procurador);
            _context.SaveChanges();
        }

        public void EditarProcurador(Procurador procurador)
        {
            _context.Procuradors.Update(procurador);
            _context.SaveChanges();
        }

        public List<Procurador> ListarProcuradores()
        {
            return _context.Procuradors
                .Include(x => x.DistribuicaoProcessoProcuradorDestinos)
                .Include(x => x.DistribuicaoProcessoProcuradorOrigems)
                .Include(x => x.Processos)
                .ToList();
        }
    }
}
