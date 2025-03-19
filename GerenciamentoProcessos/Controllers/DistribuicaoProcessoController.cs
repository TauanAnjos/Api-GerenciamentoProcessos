using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/distribuicaoprocesso")]
[ApiController]
public class DistribuicaoProcessoController : ControllerBase
{
    private readonly IDistribuicaoProcessoAppService _distribuicaoProcessoAppService;

    public DistribuicaoProcessoController(IDistribuicaoProcessoAppService distribuicaoProcessoAppService)
    {
        _distribuicaoProcessoAppService = distribuicaoProcessoAppService;
    }

    [HttpPost]
    public IActionResult CriarDistribuicaoProcesso(CriarDistribuicaoProcessoDto criarDistribuicaoProcessoDto)
    {
        if (criarDistribuicaoProcessoDto == null)
        {
            return BadRequest("Os dados da distribuição de processo são obrigatorios.");
        }
        try
        {
            _distribuicaoProcessoAppService.CriarDistribuicaoProcesso(criarDistribuicaoProcessoDto);
            return Created("api/v1/distribuicaoprocesso", criarDistribuicaoProcessoDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult BuscarDistribuicaoProcessoPorId([FromRoute] Guid id)
    {
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if (distribuicaoExistente == null)
        {
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            return Ok(distribuicaoExistente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult ListarDistribuicaoProcesso()
    {
        try
        {
            var distruibuicoes = _distribuicaoProcessoAppService.ListarDistribuicoesProcesso();
            return Ok(distruibuicoes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult EditarDistribuicaoProcesso([FromRoute] Guid id, [FromBody] EditarDistribuicaoProcessoDto editarDistribuicaoProcessoDto)
    {
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if(distribuicaoExistente == null) {
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            _distribuicaoProcessoAppService.EditarDistribuicaoProcesso(id, editarDistribuicaoProcessoDto);
            var distribuicaoAtualizada = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
            return Ok(distribuicaoAtualizada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeletarDistribuicaoProcesso([FromRoute] Guid id)
    {
        var distribuicaoExistente = _distribuicaoProcessoAppService.BuscarDistribuicaoProcessoPorId(id);
        if (distribuicaoExistente == null)
        {
            return NotFound($"Distribuição de ID {id} não encontrada.");
        }
        try
        {
            _distribuicaoProcessoAppService.DeletarDistribuicaoProcesso(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
