using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class PrazoAppService : IPrazoAppService
    {

        private readonly IPrazoRepository _repository;
        private readonly IMapper _mapper;

        public PrazoAppService(IPrazoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public PrazoDto BuscarPrazoPorId(Guid id)
        {
            var prazo = _repository.BuscarPrazoPorId(id);

            if (prazo == null)
            {
                throw new KeyNotFoundException("Prazo não encontrado.");
            }

            return _mapper.Map<PrazoDto>(prazo);
        }

        public void CriarPrazo(CriarPrazoDto criarPrazoDto)
        {
            if (criarPrazoDto == null) 
            { 
                throw new ArgumentNullException("Os dados do prazo são obrigatorios.");
            }
            var prazo = _mapper.Map<Prazo>(criarPrazoDto);
            _repository.CriarPrazo(prazo);
        }

        public void DeletarPrazo(Guid id)
        {
            var prazo = _repository.BuscarPrazoPorId(id);

            if(prazo == null)
            {
                throw new KeyNotFoundException("Prazo não encontrado.");
            }

            _repository.DeletarPrazo(prazo);
        }

        public void EditarPrazo(Guid id, EditarPrazoDto editarPrazoDto)
        {
            var prazo = _repository.BuscarPrazoPorId(id);

            if (prazo == null)
            {
                throw new KeyNotFoundException("Prazo não encontrado.");
            }

            _mapper.Map(editarPrazoDto, prazo);
            _repository.EditarPrazo(prazo);
        }

        public List<PrazoDto> ListarPrazos()
        {
            var prazos = _repository.ListarPrazo();

            var prazosDto = _mapper.Map<List<PrazoDto>>(prazos);

            return prazosDto;
        }
    }
}
