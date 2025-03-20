using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/prazo")]
[ApiController]
public class PrazoController : ControllerBase
{
    private readonly IPrazoAppService _prazoAppService;
    private readonly ILogger<PrazoController> _logger;

    public PrazoController(IPrazoAppService prazoAppService, ILogger<PrazoController> logger)
    {
        _prazoAppService = prazoAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria um novo prazo.
    /// </summary>
    /// <param name="criarPrazoDto">Objeto contendo os dados necessários para criar um prazo.</param>
    /// <returns>Retorna o prazo criado.</returns>
    [HttpPost]
    public IActionResult CriarPrazo(CriarPrazoDto criarPrazoDto)
    {
        _logger.LogInformation("Recebida requisição para criar um prazo.");
        if (criarPrazoDto == null)
        {
            _logger.LogWarning("Dados do prazo não foram fornecidos.");
            return BadRequest("Os dados de prazo são obrigatorios.");
        }
        try
        {
            _prazoAppService.CriarPrazo(criarPrazoDto);
            _logger.LogInformation("Prazo criado com sucesso.");
            return Created("api/v1/prazo", criarPrazoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar prazo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Busca um prazo pelo ID.
    /// </summary>
    /// <param name="id">ID do prazo a ser buscado.</param>
    /// <returns>Retorna o prazo correspondente ao ID informado.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPrazoPorId([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para buscar prazo com ID {Id}.", id);
        var prazoExistente = _prazoAppService.BuscarPrazoPorId(id);
        if (prazoExistente == null)
        {
            _logger.LogWarning("Prazo de ID {Id} não encontrado.", id);
            return NotFound($"Prazo de ID {id} não encontrado.");
        }
        try
        {
            _logger.LogInformation("Prazo encontrado.");
            return Ok(prazoExistente);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "Erro ao buscar prazo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Lista todos os prazos cadastrados.
    /// </summary>
    /// <returns>Retorna uma lista de prazos.</returns>
    [HttpGet]
    public IActionResult ListarPrazos()
    {
        _logger.LogInformation("Recebida requisição para listar todos os prazos.");
        try
        {
            var prazos = _prazoAppService.ListarPrazos();
            _logger.LogInformation("Lista de prazos retornada com sucesso.");
            return Ok(prazos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar prazos.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Edita um prazo existente.
    /// </summary>
    /// <param name="id">ID do prazo a ser editado.</param>
    /// <param name="editarPrazoDto">Objeto contendo os novos dados do prazo.</param>
    /// <returns>Retorna o prazo atualizado.</returns>
    [HttpPut("{id}")]
    public IActionResult EditarPrazo([FromRoute]Guid id,[FromBody] EditarPrazoDto editarPrazoDto)
    {
        _logger.LogInformation("Recebida requisição para editar prazo com ID {Id}.", id);
        var prazo = _prazoAppService.BuscarPrazoPorId(id);
        if(prazo == null)
        {
            _logger.LogWarning("Prazo de ID {Id} não encontrado.", id);
            return NotFound($"Prazo de ID{id} não encontrado.");
        }

        try
        {
            _prazoAppService.EditarPrazo(id, editarPrazoDto);
            var prazoAtualizado = _prazoAppService.BuscarPrazoPorId(id);
            _logger.LogInformation("Prazo de ID {Id} atualizado com sucesso.", id);
            return Ok(prazoAtualizado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar prazo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Deleta um prazo pelo ID.
    /// </summary>
    /// <param name="id">ID do prazo a ser deletado.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletePrazo([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para deletar prazo com ID {Id}.", id);
        var prazoExistente = _prazoAppService.BuscarPrazoPorId(id);
        if (prazoExistente == null)
        {
            _logger.LogWarning("Prazo de ID {Id} não encontrado.", id);
            return NotFound($"Prazo de ID {id} não encontrado.");
        }
        try
        {
            _prazoAppService.DeletarPrazo(id);
            _logger.LogInformation("Prazo de ID {Id} deletado com sucesso.", id);
            return NoContent();
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar prazo.");
            return BadRequest(ex.Message);
        }
    }
}
