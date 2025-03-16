using GerenciamentoProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoProcessos.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GerenciamentoProcessosContext _context;

        public ClienteRepository(GerenciamentoProcessosContext context) { 
            _context = context;
        }

        public Cliente? BuscarClientePorId(Guid id)
        {
            return _context.Set<Cliente>()
                .Include(x => x.Processos)
                .FirstOrDefault(c => c.Id == id);
        }

        public void CriarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void DeletarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void EditarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes
                .Include(x => x.Processos)
                .ToList();
        }
    }
}
