using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class ProcessosAppService : IProcessosAppService
    {
        private readonly IProcessosRepository _repository;
        private readonly IMapper _mapper;

        public ProcessosAppService(IProcessosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProcessosDto BuscarProcessoPorId(Guid id)
        {
            var processo = _repository.BuscarProcessoPorId(id);

            if (processo == null)
            {
                throw new KeyNotFoundException("Processo não encontrado.");
            }

            return _mapper.Map<ProcessosDto>(processo);
        }

        public void CriarProcesso(CriarProcessoDto criarProcessoDto)
        {
            if (criarProcessoDto == null)
            {
                throw new ArgumentException("Os dados do processo são obrigatorios.");
            }

            var processo = _mapper.Map<Processo>(criarProcessoDto);
            _repository.CriarProcesso(processo);
        }

        public void DeletarProcesso(Guid id)
        {
            var processo = _repository.BuscarProcessoPorId(id);

            if (processo == null)
            {
                throw new KeyNotFoundException("Processo não encontrado.");
            }

            _repository.DeletarProcesso(processo);
        }

        public void EditarProcesso(Guid id, EditarProcessoDto editarProcessoDto)
        {
            var processo = _repository.BuscarProcessoPorId(id);

            if(processo == null)
            {
                throw new KeyNotFoundException("Processo não encontrado.");
            }

            _mapper.Map(editarProcessoDto, processo);
            _repository.EditarProcesso(processo);
        }

        public List<ProcessosDto> ListarProcessos()
        {
            var processos = _repository.ListarProcessos();

            var processosDtos = _mapper.Map<List<ProcessosDto>>(processos);

            return processosDtos;
        }
    }
}
