using eShop.Core.Models;

namespace eShop.Application.PluginInterfaces.DataStore;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts(string filter = null!);

    Product? GetProduct(int id);
}