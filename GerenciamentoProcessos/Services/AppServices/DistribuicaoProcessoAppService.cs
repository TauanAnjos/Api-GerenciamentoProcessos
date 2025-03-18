
using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class DistribuicaoProcessoAppService : IDistribuicaoProcessoAppService
    {
        private readonly IDistribuicaoProcessoRepository  _repository;
        private readonly IMapper _mapper;

        public DistribuicaoProcessoAppService(IDistribuicaoProcessoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public DistribuicaoProcessoDto BuscarDistribuicaoProcessoPorId(Guid id)
        {
            var distribuicao = _repository.BuscarDistribuicaoProcessoPorId(id);

            if (distribuicao == null)
            {
                throw new KeyNotFoundException("Distribuição de processo não encontrada.");
            }

            return _mapper.Map<DistribuicaoProcessoDto>(distribuicao);
        }

        public void CriarDistribuicaoProcesso(CriarDistribuicaoProcessoDto criarDistribuicaoDto)
        {
            if (criarDistribuicaoDto == null)
            { 
                throw new ArgumentNullException("Os dados da distribuição de processo são obrigatorios.");
            }

            var distribuicao = _mapper.Map<DistribuicaoProcesso>(criarDistribuicaoDto);
            _repository.CriarDistribuicaoProcesso(distribuicao);
        }

        public void DeletarDistribuicaoProcesso(Guid id)
        {
            var distribuicao = _repository.BuscarDistribuicaoProcessoPorId(id);

            if(distribuicao == null)
            {
                throw new KeyNotFoundException("Distribuição de processo não encontrada.");
            }

            _repository.DeletarDistribuicaoProcesso(distribuicao);
        }

        public void EditarDistribuicaoProcesso(Guid id, EditarDistribuicaoProcessoDto editarDistribuicaoProcessoDto)
        {
            var distribuicao = _repository.BuscarDistribuicaoProcessoPorId(id);

            if(distribuicao == null)
            {
                throw new KeyNotFoundException("Distribuição de processo não encontrada.");
            }
            
            _mapper.Map(editarDistribuicaoProcessoDto, distribuicao);
            _repository.EditarDistribuicaoProcesso(distribuicao);
        }

        public List<DistribuicaoProcessoDto> ListarDistribuicoesProcesso()
        {
            var distribuicoes = _repository.ListarDistribuicaoProcesso();

            var distribuicoesDto = _mapper.Map<List<DistribuicaoProcessoDto>>(distribuicoes);

            return distribuicoesDto;
        }
    }
}
