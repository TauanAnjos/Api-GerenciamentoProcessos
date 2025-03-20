using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/distribuicaoprocesso")]
[ApiController]
public class DistribuicaoProcessoController : ControllerBase
{
    private readonly IDistribuicaoProcessoAppService _distribuicaoProcessoAppService;
    private readonly ILogger<DistribuicaoProcessoController> _logger;

    public DistribuicaoProcessoController(IDistribuicaoProcessoAppService distribuicaoProcessoAppService, ILogger<DistribuicaoProcessoController> logger)
    {
        _distribuicaoProcessoAppService = distribuicaoProcessoAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria uma nova distribuição de processo.
    /// </summary>
    /// <param name="criarDistribuicaoProcessoDto">Objeto contendo os dados necessários para criar a distribuição de processo.</param>
    /// <returns>Retorna a distribuição de processo criada.</returns>
    [HttpPost]
    public IActionResult CriarDistribuicaoProcesso(CriarDistribuicaoProcessoDto criarDistribuicaoProcessoDto)
    {
        _logger.LogInformation("Recebida requisição para criar uma nova distribuição de processo.");
        if (criarDistribuicaoProcessoDto == null)
        {
            _logger.LogWarning("Dados da distribuição de processo não foram fornecidos.");
            return BadRequest("Os dados da distribuição de processo são obrigatorios.");
        }
        try
        {
            _distribuicaoProcessoAppService.CriarDistribuicaoProcesso(criarDistribuicaoProcessoDto);
            _logger.LogInformation("Distribuição de processo criada com sucesso.");
            return Created("api/v1/distribuicaoprocesso", criarDistribuicaoProcessoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar distribuição de processo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Busca uma distribuição de processo pelo ID.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser buscada.</param>
    /// <returns>Retorna a distribuição de processo correspondente ao ID informado.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarDistribuicaoProcessoPorId([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para buscar distribuição de processo com ID {Id}.", id);
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if (distribuicaoExistente == null)
        {
            _logger.LogWarning("Distribuição de processo com ID {Id} não encontrada.", id);
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            _logger.LogInformation("Distribuição de processo encontrada.");
            return Ok(distribuicaoExistente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar distribuição de processo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Lista todas as distribuições de processos cadastradas.
    /// </summary>
    /// <returns>Retorna uma lista de distribuições de processos.</returns>
    [HttpGet]
    public IActionResult ListarDistribuicaoProcesso()
    {
        _logger.LogInformation("Recebida requisição para listar todas as distribuições de processos.");
        try
        {
            var distruibuicoes = _distribuicaoProcessoAppService.ListarDistribuicoesProcesso();
            _logger.LogInformation("Lista de distribuições de processos retornada com sucesso.");
            return Ok(distruibuicoes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar distribuições de processos.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Edita uma distribuição de processo existente.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser editada.</param>
    /// <param name="editarDistribuicaoProcessoDto">Objeto contendo os novos dados da distribuição de processo.</param>
    /// <returns>Retorna a distribuição de processo atualizada.</returns>
    [HttpPut("{id}")]
    public IActionResult EditarDistribuicaoProcesso([FromRoute] Guid id, [FromBody] EditarDistribuicaoProcessoDto editarDistribuicaoProcessoDto)
    {
        _logger.LogInformation("Recebida requisição para editar distribuição de processo com ID {Id}.", id);
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if(distribuicaoExistente == null) 
        {
            _logger.LogWarning("Distribuição de processo com ID {Id} não encontrada.", id);
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            _distribuicaoProcessoAppService.EditarDistribuicaoProcesso(id, editarDistribuicaoProcessoDto);
            var distribuicaoAtualizada = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
            _logger.LogInformation("Distribuição de processo com ID {Id} atualizada com sucesso.", id);
            return Ok(distribuicaoAtualizada);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar distribuição de processo.");
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Deleta uma distribuição de processo pelo ID.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser deletada.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletarDistribuicaoProcesso([FromRoute] Guid id)
    {
        _logger.LogInformation("Recebida requisição para deletar distribuição de processo com ID {Id}.", id);
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if (distribuicaoExistente == null)
        {
            _logger.LogWarning("Distribuição de processo com ID {Id} não encontrada.", id);
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            _distribuicaoProcessoAppService.DeletarDistribuicaoProcesso(id);
            _logger.LogInformation("Distribuição de processo com ID {Id} deletada com sucesso.", id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar distribuição de processo.");
            return BadRequest(ex.Message);
        }
    }
}
