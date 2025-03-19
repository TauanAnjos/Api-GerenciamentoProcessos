using GerenciamentoProcessos.Controllers.Dtos;
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

    [HttpPost]
    public IActionResult criarCliente([FromBody] CriarClienteDto clienteDto)
    {
        if (clienteDto == null)
        {
            return BadRequest("Os dados do clientes são obrigatorios.");
        }
        try
        {
            _clienteAppService.CriarCliente(clienteDto);
            return Created("api/v1/cliente", clienteDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
