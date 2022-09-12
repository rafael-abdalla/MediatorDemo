using MediatorDemo.Domain.Commands;
using MediatorDemo.Domain.Entities;
using MediatorDemo.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProdutoRepository _repository;

    public ProdutosController(IMediator mediator, IProdutoRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarTodos()
    {
        var retorno = await _repository.BuscarTodos();
        return Ok(retorno);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        var retorno = await _repository.BucarPorId(id);
        return Ok(retorno);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Inserir([FromBody] InserirProdutoCommand command)
    {
        var retorno = await _mediator.Send(command);
        return CreatedAtAction(nameof(BuscarPorId), new { id = retorno.Id }, retorno);
    }
}
