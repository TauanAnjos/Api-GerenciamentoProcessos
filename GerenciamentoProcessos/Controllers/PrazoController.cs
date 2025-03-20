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
    /// <summary>
    /// Cria um novo prazo.
    /// </summary>
    /// <param name="criarPrazoDto">Objeto contendo os dados necessários para criar um prazo.</param>
    /// <returns>Retorna o prazo criado.</returns>
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
    /// <summary>
    /// Busca um prazo pelo ID.
    /// </summary>
    /// <param name="id">ID do prazo a ser buscado.</param>
    /// <returns>Retorna o prazo correspondente ao ID informado.</returns>
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
    /// <summary>
    /// Lista todos os prazos cadastrados.
    /// </summary>
    /// <returns>Retorna uma lista de prazos.</returns>
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
    /// <summary>
    /// Edita um prazo existente.
    /// </summary>
    /// <param name="id">ID do prazo a ser editado.</param>
    /// <param name="editarPrazoDto">Objeto contendo os novos dados do prazo.</param>
    /// <returns>Retorna o prazo atualizado.</returns>
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
    /// <summary>
    /// Deleta um prazo pelo ID.
    /// </summary>
    /// <param name="id">ID do prazo a ser deletado.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
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
