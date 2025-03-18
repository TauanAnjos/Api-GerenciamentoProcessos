using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
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
            throw new NotImplementedException();
        }

        public void CriarProcurador(CriarProcuradorDto criarProcuradorDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarProcurador(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarProcurador(Guid id, EditarProcuradorDto editarProcuradorDto)
        {
            throw new NotImplementedException();
        }

        public List<ProcuradorDto> ListarProcuradores()
        {
            throw new NotImplementedException();
        }
    }
}
