using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/cliente")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteAppService _clienteAppService;

    public ClienteController(IClienteAppService clienteAppService)
    {
        _clienteAppService = clienteAppService;
    }

    [HttpPost]
    public IActionResult CriarCliente([FromBody] CriarClienteDto clienteDto)
    {
        if (clienteDto == null)
        {
            return BadRequest("Os dados do clientes são obrigatorios.");
        }
        try
        {
            _clienteAppService.CriarCliente(clienteDto);
            return Created("api/v1/cliente", clienteDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult BuscarClientePorId([FromRoute] Guid id)
    {
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);

        if (clienteExistente == null)
        {
            return NotFound($"Cliente de ID {id} não encontrado.");
        }
        try
        {
            return Ok(clienteExistente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        } 
    }
    [HttpGet]
    public IActionResult ListarClientes()
    {
        try
        {
            var clientes = _clienteAppService.ListarClientes();
            return Ok(clientes);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult EditarCliente([FromRoute] Guid id, [FromBody] EditarClienteDto editarClienteDto)
    {
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);

        if(clienteExistente == null)
        {
            return NotFound($"Cliente de ID{id} não encontrado.");
        }
        try
        {
            _clienteAppService.EditarCliente(id, editarClienteDto);
            var clienteAtualizado = _clienteAppService.BuscarClientePorId(id);
            return Ok(clienteAtualizado);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeletarCliente([FromRoute] Guid id)
    {
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);

        if (clienteExistente == null)
        {
            return NotFound($"Cliente de ID {id} não encontrado.");
        }
        try
        {
            _clienteAppService.DeletarCliente(id);
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
