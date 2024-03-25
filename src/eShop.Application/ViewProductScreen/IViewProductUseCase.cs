using eShop.Core.Models;

namespace eShop.UseCases.ViewProductScreen;

public interface IViewProductUseCase
{
    Product? GetById(int id);
}
