using MediatR;
using MediatRExample.Domain;

namespace MediatRExample.UseCases.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly GetProductByIdUseCase _useCase;

    public GetProductByIdHandler(GetProductByIdUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _useCase.Execute(request.Id, cancellationToken);
        return product;
    }
}