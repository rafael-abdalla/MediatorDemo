using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediatorDemo.API.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    private readonly ILogger<ErrorsController> _logger;

    public ErrorsController(ILogger<ErrorsController> logger)
    {
        _logger = logger;
    }

    [Route("error")]
    public IActionResult Error()
    {
        var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = contexto?.Error;

        var errorId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        _logger.LogError("Erro interno do servidor. Id: {errorId} Exception: {exception}", errorId, exception);

        return Problem();
    }
}
