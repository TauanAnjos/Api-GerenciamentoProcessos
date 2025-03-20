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
