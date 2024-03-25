using eShop.Application.PluginInterfaces.DataStore;
using eShop.Core.Models;

namespace eShop.UseCases.ViewProductScreen;

public class ViewProductUseCase : IViewProductUseCase
{
    private readonly IProductRepository _repository;

    public ViewProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product? GetById(int id)
    {
        return _repository.GetProduct(id);
    }
}