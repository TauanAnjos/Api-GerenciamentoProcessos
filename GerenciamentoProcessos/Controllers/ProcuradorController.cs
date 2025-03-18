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
}
