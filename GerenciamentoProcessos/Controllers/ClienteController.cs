using GerenciamentoProcessos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoProcessos.Controllers;
[Route("api/v1/cliente")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteAppService _clienteAppService;

    public ClienteController(IClienteAppService clienteAppService)
    {
        _clienteAppService = clienteAppService;
    }
}
