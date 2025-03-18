using GerenciamentoProcessos.Controllers.Dtos;

namespace GerenciamentoProcessos.Services.Interfaces
{
    public interface IClienteAppService
    {
        void CriarCliente(CriarClienteDto criarClienteDto);
        void EditarCliente(Guid id, EditarClienteDto editarClienteDto);
        ClienteDto BuscarClientePorId(Guid id);
        List<ClienteDto> ListarClientes();
        void DeletarCliente(Guid id);
    }
}
