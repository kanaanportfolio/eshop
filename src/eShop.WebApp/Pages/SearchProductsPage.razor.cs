using eShop.Core.Models;
using eShop.UseCases.SearchProductsScreen;
using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Pages;

public partial class SearchProductsPage
{
    [Inject]
    public ISearchProducts SearchProducts { get; set; }

    public IEnumerable<Product> ProductsList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        ProductsList = SearchProducts.Filter(null!);
    }

    private void HandleSearch(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            ProductsList = SearchProducts.Filter(null!);
        }
        ProductsList = SearchProducts.Filter(filter);
    }
}