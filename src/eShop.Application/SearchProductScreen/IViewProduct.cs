using eShop.Core.Models;

namespace eShop.UseCases.SearchProductsScreen;

public interface IViewProduct
{
    Product? GetById(int id);
}
