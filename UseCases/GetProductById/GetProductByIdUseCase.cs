using MediatRExample.Domain;
using Raven.Client.Documents.Session;

namespace MediatRExample.UseCases.GetProductById;

public class GetProductByIdUseCase
{
    private readonly IAsyncDocumentSession _session;

    public GetProductByIdUseCase(IAsyncDocumentSession session) => _session = session;

    public async Task<Product> Execute(string id, CancellationToken cancellationToken)
    {
        var productId = $"products/{id}";
        var product = await _session.LoadAsync<Product>(productId, cancellationToken);
        return product;
    }
}