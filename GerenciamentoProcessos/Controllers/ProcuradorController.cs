using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/procurador")]
[ApiController]
public class ProcuradorController : ControllerBase
{
    private readonly IProcuradorAppService _procuradorAppService;

    public ProcuradorController(IProcuradorAppService procuradorAppService)
    {
        _procuradorAppService = procuradorAppService;
    }

    [HttpPost]
    public IActionResult criarProcurador([FromBody] CriarProcuradorDto procuradorDto)
    {
        if (procuradorDto == null)
        {
            return BadRequest("Os dados do procurador são obrigatorios.");
        }
        try
        {
            _procuradorAppService.CriarProcurador(procuradorDto);
            return Created("api/v1/procurador", procuradorDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult BuscarProcuradorPorId([FromRoute] Guid id)
    {
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);

        if (procuradorExistente == null)
        {
            return NotFound($"Procurador de ID {id} não encontrado.");
        }

        try
        {
            return Ok(procuradorExistente);

        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public IActionResult ListarProcuradores()
    {
        try
        {
            var procuradores = _procuradorAppService.ListarProcuradores();
            return Ok(procuradores);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult EditarProcurador([FromRoute] Guid id, [FromBody] EditarProcuradorDto editarProcuradorDto)
    {
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);

        if (procuradorExistente == null)
        {
            return NotFound($"Procurador de ID {id} não encontrado.");
        }

        try
        {
            _procuradorAppService.EditarProcurador(id, editarProcuradorDto);
            var procuradorAtualizado = _procuradorAppService.BuscarProcuradorPorId(id);
            return Ok(procuradorAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProcurador([FromRoute] Guid id)
    {
        var procuradorExistente = _procuradorAppService.BuscarProcuradorPorId(id);

        if(procuradorExistente == null)
        { 
            return NotFound($"Procurador de ID {id} não encontrado.");
        }

        try
        {
            _procuradorAppService.DeletarProcurador(id);
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
