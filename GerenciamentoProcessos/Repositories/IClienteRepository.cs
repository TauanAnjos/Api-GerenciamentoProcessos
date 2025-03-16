using GerenciamentoProcessos.Models;

namespace GerenciamentoProcessos.Repositories
{
    public interface IClienteRepository
    {
        void CriarCliente(Cliente cliente);
        void EditarCliente(Cliente cliente);
        Cliente? BuscarClientePorId(Guid id);
        List<Cliente> ListarClientes();
        void DeletarCliente(Cliente cliente);

    }
}
