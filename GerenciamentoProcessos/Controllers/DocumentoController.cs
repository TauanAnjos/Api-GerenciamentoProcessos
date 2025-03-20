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
    private readonly ILogger<DocumentoController> _logger;

    public DocumentoController(IDocumentoAppService documentoAppService, ILogger<DocumentoController> logger)
    {
        _documentoAppService = documentoAppService;
        _logger = logger;
    }
    /// <summary>
    /// Cria um novo documento.
    /// </summary>
    /// <param name="criarDocumentoDto">Objeto contendo os dados necessários para criar um documento.</param>
    /// <returns>Retorna o documento criado.</returns>
    [HttpPost]
    public IActionResult CriarDocumento(CriarDocumentoDto criarDocumentoDto)
    {
        _logger.LogInformation("Recebida requisição para criar um documento.");
        if (criarDocumentoDto == null)
        {
            _logger.LogWarning("Dados do documento não foram fornecidos.");
            return BadRequest("Os dados do documento são obrigatorios.");
        }
        try
        {
            _documentoAppService.CriarDocumento(criarDocumentoDto);
            _logger.LogInformation("Documento criado com sucesso.");
            return Created("api/v1/documento", criarDocumentoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar documento.");
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
        _logger.LogInformation("Recebida requisição para buscar documento com ID {Id}.", id);
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if(documentoExistente == null)
        {
            _logger.LogWarning("Documento de ID {Id} não encontrado.", id);
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            _logger.LogInformation("Documento encontrado.");
            return Ok(documentoExistente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar documento.");
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
        _logger.LogInformation("Recebida requisição para listar todos os documentos.");
        try
        {
            var documentos = _documentoAppService.ListarDocumentos();
            _logger.LogInformation("Lista de documentos retornada com sucesso.");
            return Ok(documentos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar documentos.");
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
        _logger.LogInformation("Recebida requisição para editar documento com ID {Id}.", id);
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if (documentoExistente == null)
        {
            _logger.LogWarning("Documento de ID {Id} não encontrado.", id);
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            _documentoAppService.EditarDocumento(id, editarDocumentoDto);
            var documentoAtualizado = _documentoAppService.BuscarDocumentoPorId(id);
            _logger.LogInformation("Documento de ID {Id} atualizado com sucesso.", id);
            return Ok(documentoAtualizado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao editar documento.");
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
        _logger.LogInformation("Recebida requisição para deletar documento com ID {Id}.", id);
        var documentoExistente = _documentoAppService.BuscarDocumentoPorId(id);
        if(documentoExistente == null)
        {
            _logger.LogWarning("Documento de ID {Id} não encontrado.", id);
            return NotFound($"Documento de ID {id} não encontrado.");
        }
        try
        {
            _documentoAppService.DeletarDocumento(id);
            _logger.LogInformation("Documento de ID {Id} deletado com sucesso.", id);
            return NoContent();
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao deletar documento.");
            return BadRequest(ex.Message);
        }
    }
}
