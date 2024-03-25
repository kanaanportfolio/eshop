using eShop.Core.Models;

namespace eShop.UseCases.SearchProductsScreen;

public interface ISearchProductsUseCase
{
    IEnumerable<Product> Filter(string filter);
}
