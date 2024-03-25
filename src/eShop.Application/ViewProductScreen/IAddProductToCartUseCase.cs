using eShop.Core.Models;

namespace eShop.Application.ViewProductScreen;

public interface IAddProductToCartUseCase
{
    public Task Add(int productId);
}