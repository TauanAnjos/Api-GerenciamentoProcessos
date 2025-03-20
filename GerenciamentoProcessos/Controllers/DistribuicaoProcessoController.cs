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
    /// <summary>
    /// Cria uma nova distribuição de processo.
    /// </summary>
    /// <param name="criarDistribuicaoProcessoDto">Objeto contendo os dados necessários para criar a distribuição de processo.</param>
    /// <returns>Retorna a distribuição de processo criada.</returns>
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
    /// <summary>
    /// Busca uma distribuição de processo pelo ID.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser buscada.</param>
    /// <returns>Retorna a distribuição de processo correspondente ao ID informado.</returns>
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
    /// <summary>
    /// Lista todas as distribuições de processos cadastradas.
    /// </summary>
    /// <returns>Retorna uma lista de distribuições de processos.</returns>
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
    /// <summary>
    /// Edita uma distribuição de processo existente.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser editada.</param>
    /// <param name="editarDistribuicaoProcessoDto">Objeto contendo os novos dados da distribuição de processo.</param>
    /// <returns>Retorna a distribuição de processo atualizada.</returns>
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
    /// <summary>
    /// Deleta uma distribuição de processo pelo ID.
    /// </summary>
    /// <param name="id">ID da distribuição de processo a ser deletada.</param>
    /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
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
