using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class DistribuicaoProcessoRepository : IDistribuicaoProcessoRepository
    {
        private readonly GerenciamentoProcessosContext _context;

        public DistribuicaoProcessoRepository(GerenciamentoProcessosContext context)
        {
            _context = context;
        }

        public DistribuicaoProcesso? BuscarDistribuicaoProcessoPorId(Guid id)
        {
            return _context.Set<DistribuicaoProcesso>()
                .Include(x => x.Processo)
                .Include(x => x.ProcuradorDestino)
                .Include(x => x.ProcuradorOrigem)
                .FirstOrDefault(d => d.Id == id);
        }

        public void CriarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso)
        {
            _context.DistribuicaoProcessos.Add(distribuicaoProcesso);
            _context.SaveChanges();
        }

        public void DeletarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso)
        {
            _context.DistribuicaoProcessos.Remove(distribuicaoProcesso);
            _context.SaveChanges();
        }

        public void EditarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso)
        {
            _context.DistribuicaoProcessos.Update(distribuicaoProcesso);
            _context.SaveChanges();
        }

        public List<DistribuicaoProcesso> ListarDistribuicaoProcesso()
        {
            return _context.DistribuicaoProcessos
                .Include(x => x.Processo)
                .Include(x => x.ProcuradorDestino)
                .Include(x => x.ProcuradorOrigem)
                .ToList();
        }
    }
}
