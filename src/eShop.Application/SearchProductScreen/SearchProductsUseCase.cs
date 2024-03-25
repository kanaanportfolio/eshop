using eShop.Application.PluginInterfaces.DataStore;
using eShop.Core.Models;

namespace eShop.UseCases.SearchProductsScreen;

public class SearchProductsUseCase : ISearchProductsUseCase
{
    private readonly IProductRepository _repository;

    public SearchProductsUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> Filter(string filter)
    {
        return _repository.GetProducts(filter);
    }
}