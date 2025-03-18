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
}
