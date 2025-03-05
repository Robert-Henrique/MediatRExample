using MediatRExample.Domain;
using Raven.Client.Documents.Session;

namespace MediatRExample.UseCases.CreateProduct;

public class CreateProductUseCase
{
    private readonly IAsyncDocumentSession _session;

    public CreateProductUseCase(IAsyncDocumentSession session) => _session = session;

    public async Task<string> Execute(string name, decimal price, CancellationToken cancellationToken)
    {
        var product = new Product(name, price);
        await _session.StoreAsync(product, cancellationToken);
        await _session.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}