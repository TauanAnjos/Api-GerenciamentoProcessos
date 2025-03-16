using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IDocumentoRepository
    {
        void CriarDocumento(Documento documento);
        void EditarDocumento(Documento documento);
        Documento? BuscarDocumentoPorId(Guid id);
        List<Documento> ListarDocumento();
        void DeletarDocumento(Documento documento);
    }
}
