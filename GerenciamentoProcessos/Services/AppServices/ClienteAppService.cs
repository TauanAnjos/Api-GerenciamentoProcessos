using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        public ClienteDto BuscarClientePorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CriarCliente(CriarClienteDto criarClienteDto)
        {
            throw new NotImplementedException();
        }

        public void DeletarCliente(Guid id)
        {
            throw new NotImplementedException();
        }

        public void EditarCliente(Guid id, EditarClienteDto editarClienteDto)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDto> ListarClientes()
        {
            throw new NotImplementedException();
        }
    }
}
