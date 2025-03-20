using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/procurador")]
[ApiController]
public class ProcuradorController : ControllerBase
{
    private readonly IProcuradorAppService _procuradorAppService;
    private readonly ILogger<ProcuradorController> _logger;

    public ProcuradorController(IProcuradorAppService procuradorAppService, ILogger<ProcuradorController> logger)
    {
        _procuradorAppService = procuradorAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria um novo procurador.
    /// </summary>
    /// <param name="criarProcuradorDto">Objeto contendo os dados necessários para criar um procurador.</param>
    /// <returns>Retorna o procurador criado.</returns>
    [HttpPost]
    public IActionResult criarProcurador([FromBody] CriarProcuradorDto procuradorDto)
    {
        _logger.LogInformation("Recebida requisição para criar um procurador.");
        if (procuradorDto == null)
        {
            _logger.LogWarning("Dados do procurador não foram fornecidos.");
            return BadRequest("Os dados do procurador são obrigatorios.");
        }
        try
        {
            _procuradorAppService.CriarProcurador(procuradorDto);
            _logger.LogInformation("Procurador criado com sucesso.");
            return Created("api/v1/procurador", procuradorDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar procurador.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Busca um procurador pelo ID.
    /// </summary>
    /// <param name="id">ID do procurador.</param>
    /// <returns>Retorna o procurador correspondente ao ID fornecido.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarProcuradorPorId([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para buscar procurador com ID {Id}.", id);
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);
        if (procuradorExistente == null)
        {
            _logger.LogWarning("Procurador de ID {Id} não encontrado.", id);
            return NotFound($"Procurador de ID {id} não encontrado.");
        }

        try
        {
            _logger.LogInformation("Procurador encontrado.");
            return Ok(procuradorExistente);

        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar procurador.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Lista todos os procuradores cadastrados.
    /// </summary>
    /// <returns>Retorna uma lista de procuradores.</returns>
    [HttpGet]
    public IActionResult ListarProcuradores()
    {
        _logger.LogInformation("Recebida requisição para listar todos os procuradores.");
        try
        {
            var procuradores = _procuradorAppService.ListarProcuradores();
            return Ok(procuradores);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar procuradores.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Edita um procurador existente.
    /// </summary>
    /// <param name="id">ID do procurador a ser editado.</param>
    /// <param name="editarProcuradorDto">Objeto contendo os novos dados do procurador.</param>
    /// <returns>Retorna o procurador atualizado.</returns>
    [HttpPut("{id}")]
    public IActionResult EditarProcurador([FromRoute] Guid id, [FromBody] EditarProcuradorDto editarProcuradorDto)
    {
        _logger.LogInformation("Recebida requisição para editar procurador com ID {Id}.", id);
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);
        if (procuradorExistente == null)
        {
            _logger.LogWarning("Procurador de ID {Id} não encontrado.", id);
            return NotFound($"Procurador de ID {id} não encontrado.");
        }

        try
        {
            _procuradorAppService.EditarProcurador(id, editarProcuradorDto);
            var procuradorAtualizado = _procuradorAppService.BuscarProcuradorPorId(id);
            _logger.LogInformation("Procurador de ID {Id} atualizado com sucesso.", id);
            return Ok(procuradorAtualizado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar procurador.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Deleta um procurador pelo ID.
    /// </summary>
    /// <param name="id">ID do procurador a ser deletado.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteProcurador([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para deletar procurador com ID {Id}.", id);
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);
        if(procuradorExistente == null)
        {
            _logger.LogWarning("Procurador de ID {Id} não encontrado.", id);
            return NotFound($"Procurador de ID {id} não encontrado.");
        }
        try
        {
            _procuradorAppService.DeletarProcurador(id);
            _logger.LogInformation("Procurador de ID {Id} deletado com sucesso.", id);
            return NoContent();
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar procurador.");
            return BadRequest(ex.Message);
        }
    }
}
