using eShop.Core.Models;

namespace eShop.UseCases.SearchProductsScreen;

public interface ISearchProducts
{
    IEnumerable<Product> Filter(string filter);
}
