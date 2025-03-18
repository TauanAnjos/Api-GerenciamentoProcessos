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
}
