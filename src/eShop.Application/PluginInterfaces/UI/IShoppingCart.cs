using System.Reflection.Emit;
using eShop.Core.Models;

namespace eShop.Application.PluginInterfaces.UI;

public interface IShoppingCart
{
    Task<Order> GetOrderAsync();
    Task<Order> AddProductAsync(Product product);
    Task<Order> DeleteProductAsync(int productId);
    Task<Order> UpdateQuantityAsync(int productId, int quantity);
    Task<Order> UpdateOrderAsync(Order order);
    Task<Order> PlaceOrderAsync(Order order);
    Task EmptyAsync();
}