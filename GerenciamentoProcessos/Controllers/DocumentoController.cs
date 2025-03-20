using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Models;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/documento")]
[ApiController]
public class DocumentoController : ControllerBase
{
    private readonly IDocumentoAppService _documentoAppService;

    public DocumentoController(IDocumentoAppService documentoAppService)
    {
        _documentoAppService = documentoAppService;
    }
    /// <summary>
    /// Cria um novo documento.
    /// </summary>
    /// <param name="criarDocumentoDto">Objeto contendo os dados necessários para criar um documento.</param>
    /// <returns>Retorna o documento criado.</returns>
    [HttpPost]
    public IActionResult CriarDocumento(CriarDocumentoDto criarDocumentoDto)
    {
        if(criarDocumentoDto == null)
        {
            return BadRequest("Os dados do documento são obrigatorios.");
        }
        try
        {
            _documentoAppService.CriarDocumento(criarDocumentoDto);
            return Created("api/v1/documento", criarDocumentoDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Busca um documento pelo ID.
    /// </summary>
    /// <param name="id">ID do documento a ser buscado.</param>
    /// <returns>Retorna o documento encontrado ou um erro caso não exista.</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarDocumentoPorId([FromRoute] Guid id)
    {
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if(documentoExistente == null)
        {
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            return Ok(documentoExistente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Lista todos os documentos.
    /// </summary>
    /// <returns>Retorna uma lista de documentos.</returns>
    [HttpGet]
    public IActionResult ListarDocumento()
    {
        try
        {
            var documentos = _documentoAppService.ListarDocumentos();
            return Ok(documentos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Edita um documento existente.
    /// </summary>
    /// <param name="id">ID do documento a ser editado.</param>
    /// <param name="editarDocumentoDto">Objeto contendo os novos dados do documento.</param>
    /// <returns>Retorna o documento atualizado.</returns>
    [HttpPut("{id}")]
    public IActionResult EditarDocumento([FromRoute] Guid id, [FromBody] EditarDocumentoDto editarDocumentoDto)
    {
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if (documentoExistente == null)
        {
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            _documentoAppService.EditarDocumento(id, editarDocumentoDto);
            var documentoAtualizado = _documentoAppService.BuscarDocumentoPorId(id);
            return Ok(documentoAtualizado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Exclui um documento pelo ID.
    /// </summary>
    /// <param name="id">ID do documento a ser excluído.</param>
    /// <returns>Retorna NoContent caso a exclusão seja bem-sucedida.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteDocumento([FromRoute] Guid id)
    {
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if(documentoExistente == null)
        {
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            _documentoAppService.DeletarDocumento(id);
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
