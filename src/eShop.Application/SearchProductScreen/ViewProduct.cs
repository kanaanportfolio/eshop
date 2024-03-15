using eShop.Application.PluginInterfaces.DataStore;
using eShop.Core.Models;

namespace eShop.UseCases.SearchProductsScreen;


public class ViewProduct : IViewProduct
{
    private readonly IProductRepository _repository;

    public ViewProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product? GetById(int id)
    {
        return _repository.GetProduct(id);
    }
}