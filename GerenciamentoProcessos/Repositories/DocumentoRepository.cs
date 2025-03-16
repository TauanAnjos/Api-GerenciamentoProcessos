using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private GerenciamentoProcessosContext _context;

        public DocumentoRepository(GerenciamentoProcessosContext context) { 
            _context = context;
        }
        public Documento? BuscarDocumentoPorId(Guid id)
        {
            return _context.Set<Documento>()
                .Include(x => x.Processo)
                .FirstOrDefault(d => d.Id == id);
        }

        public void CriarDocumento(Documento documento)
        {
            _context.Documentos.Add(documento);
            _context.SaveChanges();
        }

        public void DeletarDocumento(Documento documento)
        {
            _context.Documentos.Remove(documento);
            _context.SaveChanges();
        }

        public void EditarDocumento(Documento documento)
        {
            _context.Documentos.Update(documento);
            _context.SaveChanges();
        }

        public List<Documento> ListarDocumento()
        {
            return _context.Documentos
                .Include(x => x.Processo)
                .ToList();
        }
    }
}
