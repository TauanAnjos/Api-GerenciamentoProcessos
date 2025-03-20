using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;

[Route("api/v1/processos")]
[ApiController]
public class ProcessosController : ControllerBase
{
    private readonly IProcessosAppService _processosAppService;
    private readonly ILogger<ProcuradorController> _logger;

    public ProcessosController(IProcessosAppService processosAppService, ILogger<ProcuradorController> logger)
    {
        _processosAppService = processosAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria um novo processo jurídico.
    /// </summary>
    /// <param name="criarProcessoDto">Objeto contendo os dados necessários para criar um processo.</param>
    /// <returns>Retorna o processo criado.</returns>
    [HttpPost]
    public IActionResult CriarProcesso([FromBody]CriarProcessoDto criarProcessoDto)
    {
        _logger.LogInformation("Recebida requisição para criar um processo.");
        if (criarProcessoDto == null)
        {
            _logger.LogWarning("Dados do processo não foram fornecidos.");
            return BadRequest("Os dados do processo são obrigatorios.");
        }
        try
        {
            _logger.LogInformation("Criando um novo processo.");
            _processosAppService.CriarProcesso(criarProcessoDto);
            _logger.LogInformation("Processo criado com sucesso.");
            return Created("/api/v1/processos", criarProcessoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar processo.");
            return BadRequest(ex.Message);
        }  
    }
    /// <summary>
    /// Lista todos os processos jurídicos cadastrados filtrando dados ou não.
    /// </summary>
    /// <returns>Retorna uma lista de processos.</returns>
    [HttpGet]
    public IActionResult ListarProcessos([FromQuery] ProcessosFiltrosDto processosDto)
    {
        _logger.LogInformation("Recebida requisição para listar todos os processos.");
        try
        {
            _logger.LogInformation("Listando processos.");
            var processos = _processosAppService.ListarProcessos(processosDto);
            _logger.LogInformation("Lista de processos retornada com sucesso.");
            return Ok(processos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar processos.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Busca um processo jurídico pelo ID.
    /// </summary>
    /// <param name="id">ID do processo a ser consultado.</param>
    /// <returns>Retorna os detalhes do processo encontrado.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarProcessoPorId([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para buscar processo com ID {Id}.", id);
        try
        {
            _logger.LogInformation($"Buscando processo com ID {id}");
            var processo = _processosAppService.BuscarProcessoPorId(id);
            if (processo == null)
            {
                _logger.LogWarning($"Processo de ID {id} não encontrado.");
                return NotFound($"Processo com ID {id} não encontrado.");
            }
            return Ok(processo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao buscar processo com ID {id}");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Edita um processo jurídico existente.
    /// </summary>
    /// <param name="id">ID do processo a ser editado.</param>
    /// <param name="editarProcessoDto">Objeto contendo os novos dados do processo.</param>
    /// <returns>Retorna o processo atualizado.</returns>
    [HttpPut("{id}")]
    public IActionResult EditarProcesso([FromRoute] Guid id, [FromBody] EditarProcessoDto editarProcessoDto)
    {
        _logger.LogInformation("Recebida requisição para editar processo com ID {Id}.", id);
        var processoExistente = _processosAppService.BuscarProcessoPorId(id);
        if(processoExistente == null)
        {
            _logger.LogWarning("Processo de ID {Id} não encontrado.", id);
            return NotFound($"Processo com ID {id} não encontrado.");
        }

        try
        {
            _processosAppService.EditarProcesso(id, editarProcessoDto);
            var processoAtualizado = _processosAppService.BuscarProcessoPorId(id);
            _logger.LogInformation($"Processo com ID {id} editado com sucesso.");
            return Ok(processoAtualizado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar processo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Exclui um processo jurídico pelo ID.
    /// </summary>
    /// <param name="id">ID do processo a ser deletado.</param>
    /// <returns>Retorna um status 204 se a exclusão for bem-sucedida.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletarProcesso([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para deletar processo com ID {Id}.", id);
        var processo = _processosAppService.BuscarProcessoPorId(id);
        if( processo == null)
        {
            _logger.LogWarning($"Processo com ID {id} não encontrado para exclusão.");
            return NotFound($"Processo com ID {id} não encontrado.");
        }

        try
        {
            _processosAppService.DeletarProcesso(id);
            _logger.LogInformation($"Processo com ID {id} excluído com sucesso.");
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao excluir processo com ID {id}");
            return BadRequest(ex.Message);
        }
    }

}
