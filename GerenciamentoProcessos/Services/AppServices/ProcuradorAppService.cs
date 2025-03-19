using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class ProcuradorAppService : IProcuradorAppService
    {

        private readonly IProcuradorRepository _repository;
        private readonly IMapper _mapper;

        public ProcuradorAppService(IProcuradorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProcuradorDto BuscarProcuradorPorId(Guid id)
        {
            var procurador = _repository.BuscarProcuradorPorId(id);

            if (procurador == null)
            {
                throw new KeyNotFoundException("Procurador não encontrado.");
            }

            return _mapper.Map<ProcuradorDto>(procurador);
        }

        public void CriarProcurador(CriarProcuradorDto criarProcuradorDto)
        {
            if (criarProcuradorDto == null)
            { 
                throw new ArgumentNullException("Os dados do procurador são obrigatorios.");
            }

            var procurador = _mapper.Map<Procurador>(criarProcuradorDto);
            _repository.CriarProcurador(procurador);
        }

        public void DeletarProcurador(Guid id)
        {
            var procurador = _repository.BuscarProcuradorPorId(id);

            if(procurador == null)
            {
                throw new KeyNotFoundException("Procurador não encontrado.");
            }

            _repository.DeletarProcurador(procurador);
        }

        public void EditarProcurador(Guid id, EditarProcuradorDto editarProcuradorDto)
        {
            var procurador = _repository.BuscarProcuradorPorId(id);

            if (procurador == null)
            {
                throw new KeyNotFoundException("Procurador não encontrado.");
            }
            _mapper.Map(editarProcuradorDto, procurador);
            _repository.EditarProcurador(procurador);
        }

        public List<ProcuradorDto> ListarProcuradores()
        {
            var procuradores = _repository.ListarProcuradores();

            var procuradoresDto = _mapper.Map<List<ProcuradorDto>>(procuradores);

            return procuradoresDto;
        }
    }
}
