using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/cliente")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteAppService _clienteAppService;
    private readonly IProcessosAppService _processosAppService;

    public ClienteController(IClienteAppService clienteAppService, IProcessosAppService processosAppService)
    {
        _clienteAppService = clienteAppService;
        _processosAppService = processosAppService;
    }
    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="clienteDto">Objeto contendo os dados necessários para criar um cliente.</param>
    /// <returns>Retorna o cliente criado.</returns>
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
    /// <summary>
    /// Busca um cliente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente a ser buscado.</param>
    /// <returns>Retorna o cliente correspondente ao ID informado.</returns>
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
    /// <summary>
    /// Lista todos os clientes cadastrados.
    /// </summary>
    /// <returns>Retorna uma lista de clientes.</returns>
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
    /// <summary>
    /// Edita um cliente existente.
    /// </summary>
    /// <param name="id">ID do cliente a ser editado.</param>
    /// <param name="editarClienteDto">Objeto contendo os novos dados do cliente.</param>
    /// <returns>Retorna o cliente atualizado.</returns>
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
    /// <summary>
    /// Deleta um cliente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente a ser deletado.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
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

    [HttpGet("BuscarProcessoPorClientePorId{id}")]
    public IActionResult BuscarProcessoPorClientePorId([FromRoute] Guid id)
    {
        var processo = _processosAppService.BuscarProcessoPorClientePorId(id);

        if (processo == null)
        {
            return NotFound($"Processo de ID {id} não encontrado.");
        }
        try
        {
            return Ok(processo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
