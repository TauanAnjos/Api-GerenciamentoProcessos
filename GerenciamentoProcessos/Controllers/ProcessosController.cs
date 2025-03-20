using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;

[Route("api/v1/processos")]
[ApiController]
public class ProcessosController : ControllerBase
{
    private readonly IProcessosAppService _processosAppService;

    public ProcessosController(IProcessosAppService processosAppService)
    {
        _processosAppService = processosAppService;
    }
    /// <summary>
    /// Cria um novo processo jurídico.
    /// </summary>
    /// <param name="criarProcessoDto">Objeto contendo os dados necessários para criar um processo.</param>
    /// <returns>Retorna o processo criado.</returns>
    [HttpPost]
    public IActionResult CriarProcesso([FromBody]CriarProcessoDto criarProcessoDto)
    {
        if (criarProcessoDto == null)
        {
            return BadRequest("Os dados do processo são obrigatorios.");
        }
        try
        {
            _processosAppService.CriarProcesso(criarProcessoDto);
            return Created("/api/v1/processos", criarProcessoDto);
        }
        catch (Exception ex)
        {
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
        try
        {
            var processos = _processosAppService.ListarProcessos(processosDto);
            return Ok(processos);
        }
        catch (Exception ex)
        {
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
        try
        {
            var processo = _processosAppService.BuscarProcessoPorId(id);
            if (processo == null)
            {
                return NotFound($"Processo com ID {id} não encontrado.");
            }

            return Ok(processo);

        }
        catch (Exception ex)
        {
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
        var processoExistente = _processosAppService.BuscarProcessoPorId(id);

        if(processoExistente == null)
        {
            return NotFound($"Processo com ID {id} não encontrado.");
        }

        try
        {
            _processosAppService.EditarProcesso(id, editarProcessoDto);
            var processoAtualizado = _processosAppService.BuscarProcessoPorId(id);
            return Ok(processoAtualizado);
        }
        catch (Exception ex)
        {
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
        var processo = _processosAppService.BuscarProcessoPorId(id);

        if( processo == null)
        {
            return NotFound($"Processo com ID {id} não encontrado.");
        }

        try
        {
            _processosAppService.DeletarProcesso(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
