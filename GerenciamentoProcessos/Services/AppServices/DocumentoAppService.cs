using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class DocumentoAppService : IDocumentoAppService
    {
        private readonly IDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public DocumentoAppService(IDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DocumentoDto BuscarDocumentoPorId(Guid id)
        {
            var documento = _repository.BuscarDocumentoPorId(id);

            if (documento == null){
                throw new KeyNotFoundException("Documento não encontrado.");
            }

            return _mapper.Map<DocumentoDto>(documento);
        }

        public void CriarDocumento(CriarDocumentoDto criarDocumentoDto)
        {
            if (criarDocumentoDto == null)
            {
                throw new ArgumentNullException("Os dados do documento são obrigatorios.");
            }

            var documento = _mapper.Map<Documento>(criarDocumentoDto);
            _repository.CriarDocumento(documento);
        }

        public void DeletarDocumento(Guid id)
        {
            var documento = _repository.BuscarDocumentoPorId(id);

            if (documento == null)
            {
                throw new KeyNotFoundException("Documento não encontrado.");
            }

            _repository.DeletarDocumento(documento);
        }

        public void EditarDocumento(Guid id, EditarDocumentoDto editarDocumentoDto)
        {
            var documento = _repository.BuscarDocumentoPorId(id);

            if(documento == null)
            {
                throw new KeyNotFoundException("Documento não encontrado.");
            }
            _mapper.Map(editarDocumentoDto, documento);
            _repository.EditarDocumento(documento);
        }

        public List<DocumentoDto> ListarDocumentos()
        {
            var documentos = _repository.ListarDocumento();

            var documentosDtos = _mapper.Map<List<DocumentoDto>>(documentos);

            return documentosDtos;
        }
    }
}
