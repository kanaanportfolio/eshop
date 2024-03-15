using eShop.Core.Models;
using eShop.UseCases.SearchProductsScreen;
using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Pages;

public partial class ProductDetails
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IViewProduct ViewProduct { get; set; }

    private Product Product { get; set; }

    protected override void OnParametersSet()
    {
        Product = ViewProduct.GetById(Id);
    }
}