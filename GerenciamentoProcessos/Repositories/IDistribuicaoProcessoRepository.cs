using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IDistribuicaoProcessoRepository
    {
        void CriarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso);
        void EditarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso);
        DistribuicaoProcesso? BuscarDistribuicaoProcessoPorId(Guid id);
        List<DistribuicaoProcesso> ListarDistribuicaoProcesso();
        void DeletarDistribuicaoProcesso(DistribuicaoProcesso distribuicaoProcesso);
    }
}
