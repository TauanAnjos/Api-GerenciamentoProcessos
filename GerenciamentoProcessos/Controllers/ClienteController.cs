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
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(IClienteAppService clienteAppService, IProcessosAppService processosAppService, ILogger<ClienteController> logger)
    {
        _clienteAppService = clienteAppService;
        _processosAppService = processosAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="clienteDto">Objeto contendo os dados necessários para criar um cliente.</param>
    /// <returns>Retorna o cliente criado.</returns>
    [HttpPost]
    public IActionResult CriarCliente([FromBody] CriarClienteDto clienteDto)
    {
        _logger.LogInformation("Recebida requisição para criar um cliente.");
        if (clienteDto == null)
        {
            _logger.LogWarning("Dados do cliente não foram fornecidos.");
            return BadRequest("Os dados do clientes são obrigatorios.");
        }
        try
        {
            _clienteAppService.CriarCliente(clienteDto);
            _logger.LogInformation("Cliente criado com sucesso.");
            return Created("api/v1/cliente", clienteDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar cliente.");
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
        _logger.LogInformation("Recebida requisição para buscar cliente com ID {Id}.", id);
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);
        if (clienteExistente == null)
        {
            _logger.LogWarning("Cliente de ID {Id} não encontrado.", id);
            return NotFound($"Cliente de ID {id} não encontrado.");
        }
        try
        {
            _logger.LogInformation("Cliente encontrado.");
            return Ok(clienteExistente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar cliente.");
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
        _logger.LogInformation("Recebida requisição para listar todos os clientes.");
        try
        {
            var clientes = _clienteAppService.ListarClientes();
            _logger.LogInformation("Lista de clientes retornada com sucesso.");
            return Ok(clientes);
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar clientes.");
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
        _logger.LogInformation("Recebida requisição para editar cliente com ID {Id}.", id);
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);
        if(clienteExistente == null)
        {
            _logger.LogWarning("Cliente de ID {Id} não encontrado.", id);
            return NotFound($"Cliente de ID{id} não encontrado.");
        }
        try
        {
            _clienteAppService.EditarCliente(id, editarClienteDto);
            var clienteAtualizado = _clienteAppService.BuscarClientePorId(id);
            _logger.LogInformation("Cliente de ID {Id} atualizado com sucesso.", id);
            return Ok(clienteAtualizado);
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar cliente.");
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
        _logger.LogInformation("Recebida requisição para deletar cliente com ID {Id}.", id);
        var clienteExistente = _clienteAppService.BuscarClientePorId(id);
        if (clienteExistente == null)
        {
            _logger.LogWarning("Cliente de ID {Id} não encontrado.", id);
            return NotFound($"Cliente de ID {id} não encontrado.");
        }
        try
        {
            _clienteAppService.DeletarCliente(id);
            _logger.LogInformation("Cliente de ID {Id} deletado com sucesso.", id);
            return NoContent();
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar cliente.");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("BuscarProcessoPorClientePorId{id}")]
    public IActionResult BuscarProcessoPorClientePorId([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para buscar processo por cliente com ID {Id}.", id);
        var processo = _processosAppService.BuscarProcessoPorClientePorId(id);

        if (processo == null)
        {
            _logger.LogWarning("Processo de ID {Id} não encontrado.", id);
            return NotFound($"Processo de ID {id} não encontrado.");
        }
        try
        {
            _logger.LogInformation("Processo encontrado para o cliente de ID {Id}.", id);
            return Ok(processo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar processo do cliente.");
            return BadRequest(ex.Message);
        }
    }
}
