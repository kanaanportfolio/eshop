using eShop.Application.ViewProductScreen;
using eShop.Core.Models;
using eShop.UseCases.ViewProductScreen; 
using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Pages;

public partial class ProductDetails
{
    [Parameter]
    public int Id { get; set; }

    [Inject] public IViewProductUseCase ViewProductUseCase { get; set; }
    [Inject] public IAddProductToCartUseCase AddProductToCartUseCase { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private Product Product { get; set; }

    protected override void OnParametersSet()
    {
        Product = ViewProductUseCase.GetById(Id);
    }

    private async Task AddToCart()
    {
        await AddProductToCartUseCase.Add(Id);
        NavigationManager.NavigateTo("/products");
    }
}