using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IDistribuicaoProcessoAppService
    {
        void CriarDistribuicaoProcesso(CriarDistribuicaoProcessoDto criarDistribuicaoDto);
        void EditarDistribuicaoProcesso(Guid id, EditarDistribuicaoProcessoDto editarDistribuicaoProcessoDto);
        DistribuicaoProcessoDto BuscarDistribuicaoProcessoPorId(Guid id);
        List<DistribuicaoProcessoDto> ListarDistribuicoesProcesso();
        void DeletarDistribuicaoProcesso(Guid id);
    }
}
