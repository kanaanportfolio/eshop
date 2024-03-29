using eShop.Core.Models;

namespace eShop.Application.ShoppingCartScreen;

public interface IViewShoppingCartUseCase
{
    Task<Order> View();
}