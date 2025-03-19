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
}
