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
}
