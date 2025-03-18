using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class DocumentoAppService : IDocumentoAppService
    {
        public DocumentoDto BuscarDocumentoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CriarDocumento(CriarDocumentoDto criarDocumentoDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarDocumento(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarDocumento(Guid id, EditarDocumentoDto editarDocumentoDto)
        {
            throw new NotImplementedException();
        }

        public List<DocumentoDto> ListarDocumentos()
        {
            throw new NotImplementedException();
        }
    }
}
