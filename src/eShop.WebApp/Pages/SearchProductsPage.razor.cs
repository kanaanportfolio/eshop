using eShop.Core.Models;
using eShop.UseCases.SearchProductsScreen;
using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Pages;

public partial class SearchProductsUseCasePage
{
    [Inject]
    public ISearchProductsUseCase SearchProductsUseCase { get; set; }

    public IEnumerable<Product> ProductsList { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        ProductsList = SearchProductsUseCase.Filter(null!);
    }

    private void HandleSearch(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            ProductsList = SearchProductsUseCase.Filter(null!);
        }
        ProductsList = SearchProductsUseCase.Filter(filter);
    }
}