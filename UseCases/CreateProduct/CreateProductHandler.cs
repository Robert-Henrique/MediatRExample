using MediatR;

namespace MediatRExample.UseCases.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, string>
{
    private readonly CreateProductUseCase _useCase;

    public CreateProductHandler(CreateProductUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken) =>
        await _useCase.Execute(request.Name, request.Price, cancellationToken);
}