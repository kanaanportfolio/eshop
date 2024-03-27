using eShop.Core.Models;

namespace eShop.Application.ViewProductScreen;

public interface IAddProductToCartUseCase
{
    Task Add(int productId);
}