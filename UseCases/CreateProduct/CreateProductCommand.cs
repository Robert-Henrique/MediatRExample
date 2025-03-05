using MediatR;

namespace MediatRExample.UseCases.CreateProduct;

public class CreateProductCommand : IRequest<string>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}