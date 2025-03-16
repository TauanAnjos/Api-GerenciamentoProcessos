using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IProcuradorRepository
    {
        void CriarProcurador(Procurador procurador);
        void EditarProcurador(Procurador procurador);
        Procurador? BuscarProcuradorPorId(Guid id);
        List<Procurador> ListarProcuradores();
        void DeletarProcurador(Procurador procurador);
    }
}
