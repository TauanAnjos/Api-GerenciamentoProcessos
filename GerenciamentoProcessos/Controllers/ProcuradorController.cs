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
    /// <summary>
    /// Cria um novo procurador.
    /// </summary>
    /// <param name="criarProcuradorDto">Objeto contendo os dados necessários para criar um procurador.</param>
    /// <returns>Retorna o procurador criado.</returns>
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
    /// <summary>
    /// Busca um procurador pelo ID.
    /// </summary>
    /// <param name="id">ID do procurador.</param>
    /// <returns>Retorna o procurador correspondente ao ID fornecido.</returns>
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
    /// <summary>
    /// Lista todos os procuradores cadastrados.
    /// </summary>
    /// <returns>Retorna uma lista de procuradores.</returns>
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
    /// <summary>
    /// Edita um procurador existente.
    /// </summary>
    /// <param name="id">ID do procurador a ser editado.</param>
    /// <param name="editarProcuradorDto">Objeto contendo os novos dados do procurador.</param>
    /// <returns>Retorna o procurador atualizado.</returns>
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
    /// <summary>
    /// Deleta um procurador pelo ID.
    /// </summary>
    /// <param name="id">ID do procurador a ser deletado.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
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
