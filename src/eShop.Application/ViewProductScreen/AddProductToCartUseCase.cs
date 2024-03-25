using eShop.Application.PluginInterfaces.DataStore;
using eShop.Application.PluginInterfaces.UI;
using eShop.Core.Models;

namespace eShop.Application.ViewProductScreen;

public class AddProductToCartUseCase : IAddProductToCartUseCase
{
    private readonly IShoppingCart _cartRepo;
    private readonly IProductRepository _productRepo;

    public AddProductToCartUseCase(
        IShoppingCart cartRepo,
        IProductRepository productRepo)
    {
        _cartRepo = cartRepo;
        _productRepo = productRepo;
    }

    public async Task Add(int productId)
    {
        var match = _productRepo.GetProduct(productId);
        if (match != null)
        {
            await _cartRepo.AddProductAsync(match);
        }
    }
}