using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IProcessosRepository
    {
        void CriarProcesso(Processo processo);
        void EditarProcesso(Processo processo);
        Processo? BuscarProcessoPorId(Guid id);
        List<Processo> ListarProcessos();
        void DeletarProcesso(Processo processo);

    }
}
