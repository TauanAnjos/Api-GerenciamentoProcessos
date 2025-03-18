using GerenciamentoProcessos.Controllers.Dtos;
using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;

[Route("api/v1/processos")]
[ApiController]
public class ProcessosController : ControllerBase
{
    private readonly IProcessosAppService _processosAppService;

    public ProcessosController(IProcessosAppService processosAppService)
    {
        _processosAppService = processosAppService;
    }

    [HttpPost]
    public IActionResult CriarProcesso([FromBody]CriarProcessoDto criarProcessoDto)
    {
        _processosAppService.CriarProcesso(criarProcessoDto);
        return Created("/api/v1/processos", criarProcessoDto);
    }
}
