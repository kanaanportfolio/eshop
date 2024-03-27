using System.Reflection.Emit;
using eShop.Application.PluginInterfaces.DataStore;
using eShop.Application.PluginInterfaces.UI;
using eShop.Core.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace eShop.ShoppingCart.Local;

public class ShoppingCart : IShoppingCart
{
    private readonly IJSRuntime _jSRuntime;
    private readonly IProductRepository _productRepository;

    public ShoppingCart(IJSRuntime jSRuntime, IProductRepository ProductRepository)
    {
        _jSRuntime = jSRuntime;
        _productRepository = ProductRepository;
    }

    private async Task<Order> GetOrder()
    {
        Order order = null;

        var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", "eShop.ShoppingCart");

        if (!string.IsNullOrWhiteSpace(strOrder) && !strOrder.Equals("null"))
        {
            order = JsonConvert.DeserializeObject<Order>(strOrder);
        }
        else
        {
            order = new Order();
            await SetOrder(order);
        }
        foreach (var item in order.LineItems)
        {
            item.Product = _productRepository.GetProduct(item.ProductId);
        }
        return order;
    }

    private async Task SetOrder(Order order)
    {
        await _jSRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            "eShop.ShoppingCart",
            JsonConvert.SerializeObject(order));
    }

    public async Task<Order> AddProductAsync(Product product)
    {
        var order = await GetOrder();
        order.AddProduct(product.Id, 1, product.Price);
        await SetOrder(order);
        return order;
    }

    public async Task<Order> DeleteProductAsync(int productId)
    {
        var order = await GetOrder();
        order.RemoveProduct(productId);
        await SetOrder(order);
        return order;
    }

    public async Task<Order> GetOrderAsync()
    {
        return await GetOrder();
    }

    public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
    {
        var order = await GetOrder();

        if (quantity < 0)
        {
            return order;
        }
        else if (quantity == 0)
        {
            return await DeleteProductAsync(productId);
        }

        var item = order.LineItems.SingleOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Quantity = quantity;
        }
        await SetOrder(order);

        return order;
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        await SetOrder(order);
        return order;
    }

    public async Task<Order> PlaceOrderAsync(Order order)
    {
        await SetOrder(order);
        return order;
    }

    public async Task EmptyAsync()
    {
        await SetOrder(null);
    }
}