using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IDocumentoAppService
    {
        void CriarDocumento(CriarDocumentoDto criarDocumentoDto);
        void EditarDocumento(Guid id);
        DocumentoDto BuscarDocumentoPorId(Guid id);
        List<DocumentoDto> ListarDocumentos();
        void DeletarDocumento(Guid id);
    }
}
