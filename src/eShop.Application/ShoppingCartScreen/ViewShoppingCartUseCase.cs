using eShop.Application.PluginInterfaces.UI;
using eShop.Core.Models;

namespace eShop.Application.ShoppingCartScreen;

public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
{
    private readonly IShoppingCart _cartRepo;

    public ViewShoppingCartUseCase(IShoppingCart cartRepo)
    {
        _cartRepo = cartRepo;
    }
    public async Task<Order> View()
    {
        return await _cartRepo.GetOrderAsync();
    }
}