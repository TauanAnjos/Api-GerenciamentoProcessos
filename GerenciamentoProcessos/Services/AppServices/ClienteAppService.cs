using AutoMapper;
using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Repositories;
using GerenciamentoProcessos.Services.Interfaces;

namespace GerenciamentoProcessos.Services.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public ClienteDto BuscarClientePorId(Guid id)
        {
            var cliente = _repository.BuscarClientePorId(id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado");
            }

            return _mapper.Map<ClienteDto>(cliente);
        }

        public void CriarCliente(CriarClienteDto criarClienteDto)
        {
            if (criarClienteDto == null)
            {
                throw new ArgumentNullException("Os dados do cliente são obrigatorios.");
            }

            var cliente = _mapper.Map<Cliente>(criarClienteDto);
            _repository.CriarCliente(cliente);
        }

        public void DeletarCliente(Guid id)
        {
            var cliente = _repository.BuscarClientePorId(id);

            if(cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }

            _repository.DeletarCliente(cliente);
        }

        public void EditarCliente(Guid id, EditarClienteDto editarClienteDto)
        {
            var cliente = _repository.BuscarClientePorId(id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }
            _mapper.Map(editarClienteDto, cliente);
            _repository.EditarCliente(cliente);

        }

        public List<ClienteDto> ListarClientes()
        {
            var clientes = _repository.ListarClientes();

            var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);

            return clientesDto;
        }
    }
}
