using MediatR;
using MediatRExample.UseCases.CreateProduct;
using MediatRExample.UseCases.GetProductById;
using Microsoft.AspNetCore.Mvc;

namespace MediatRExample.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return Created($"/api/products/{id}", id);
    }
}