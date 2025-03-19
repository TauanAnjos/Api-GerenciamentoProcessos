using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/prazo")]
[ApiController]
public class PrazoController : ControllerBase
{
    private readonly IPrazoAppService _prazoAppService;

    public PrazoController(IPrazoAppService prazoAppService)
    {
        _prazoAppService = prazoAppService;
    }

    [HttpPost]
    public IActionResult CriarPrazo(CriarPrazoDto criarPrazoDto)
    {
        if (criarPrazoDto == null)
        {
            return BadRequest("Os dados de prazo são obrigatorios.");
        }
        try
        {
            _prazoAppService.CriarPrazo(criarPrazoDto);
            return Created("api/v1/prazo", criarPrazoDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult BuscarPrazoPorId([FromRoute] Guid id)
    {
        var prazoExistente = _prazoAppService.BuscarPrazoPorId(id);

        if (prazoExistente == null)
        {
            return NotFound($"Prazo de ID {id} não encontrado.");
        }
        try
        {
            return Ok(prazoExistente);
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }

    }
    [HttpGet]
    public IActionResult ListarPrazos()
    {
        try
        {
            var prazos = _prazoAppService.ListarPrazos();
            return Ok(prazos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult EditarPrazo([FromRoute]Guid id,[FromBody] EditarPrazoDto editarPrazoDto)
    {
        var prazo = _prazoAppService.BuscarPrazoPorId(id);

        if(prazo == null)
        {
            return NotFound($"Prazo de ID{id} não encontrado.");
        }

        try
        {
            _prazoAppService.EditarPrazo(id, editarPrazoDto);
            var prazoAtualizado = _prazoAppService.BuscarPrazoPorId(id);
            return Ok(prazoAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePrazo([FromRoute] Guid id)
    {
        var prazoExistente = _prazoAppService.BuscarPrazoPorId(id);

        if (prazoExistente == null)
        {
            return NotFound($"Prazo de ID {id} não encontrado.");
        }
        try
        {
            _prazoAppService.DeletarPrazo(id);
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
