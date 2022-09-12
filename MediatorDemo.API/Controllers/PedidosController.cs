using MediatorDemo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly IPedidoRepository _repository;

    public PedidosController(IPedidoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var retorno = await _repository.BuscarTodos();
        return Ok(retorno);
    }
}
