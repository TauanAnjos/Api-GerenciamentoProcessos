using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IPrazoRepository
    {
        void CriarPrazo(Prazo prazo);
        void EditarPrazo(Prazo prazo);
        Prazo? BuscarPrazoPorId(Guid id);
        List<Prazo> ListarPrazo();
        void DeletarPrazo(Prazo prazo);
    }
}
