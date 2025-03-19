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
    /// Cria um processo jurídico.
    /// </summary>
    /// <param name="criarProcessoDto">Campos para criar um processo.</param>
    /// <returns>Cria um processo jurídico.</returns>
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

    [HttpGet]
    public IActionResult ListarProcessos()
    {
        try
        {
            var processos = _processosAppService.ListarProcessos();
            return Ok(processos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
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
