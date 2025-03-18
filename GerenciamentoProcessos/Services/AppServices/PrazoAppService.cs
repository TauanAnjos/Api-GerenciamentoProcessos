using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
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
            throw new NotImplementedException();
        }

        public void CriarPrazo(CriarPrazoDto criarPrazoDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarPrazo(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarPrazo(Guid id, EditarPrazoDto editarPrazoDto)
        {
            throw new NotImplementedException();
        }

        public List<PrazoDto> ListarPrazos()
        {
            throw new NotImplementedException();
        }
    }
}
