using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;
using System.Diagnostics;

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

        public ProcessosDto BuscarProcessoPorClientePorId(Guid clienteId)
        {
            var processo = _repository.BuscarProcessoPorClientePorId(clienteId);
            
           return _mapper.Map<ProcessosDto>(processo);
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

        public List<ProcessosDto> ListarProcessos(ProcessosFiltrosDto processosDto)
        {
            var processos = _repository.ListarProcessos();

            var processosList = FiltrarProcessos(processosDto, processos);

            return processosList;
        }

        private List<ProcessosDto> FiltrarProcessos(ProcessosFiltrosDto processosDto, List<Processo> processosDtoLista)
        {
            if (processosDto.Numero != null)
            {
                processosDtoLista = (List<Processo>)processosDtoLista.Where(x => x.Numero == processosDto.Numero).ToList();
            }
            if (processosDto.OrgaoResponsavel != null)
            {
                processosDtoLista = (List<Processo>)processosDtoLista.Where(x => x.OrgaoResponsavel == processosDto.OrgaoResponsavel).ToList();
            }
            if (processosDto.Assunto != null)
            {
                processosDtoLista = (List<Processo>)processosDtoLista.Where(x => x.Assunto == processosDto.Assunto).ToList();
            }

            var processosDtos = _mapper.Map<List<ProcessosDto>>(processosDtoLista);
            return processosDtos;
        }
    }
}
