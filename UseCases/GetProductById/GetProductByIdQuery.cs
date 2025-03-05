using MediatR;
using MediatRExample.Domain;

namespace MediatRExample.UseCases.GetProductById;

public class GetProductByIdQuery : IRequest<Product>
{
    public string Id { get; }

    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}