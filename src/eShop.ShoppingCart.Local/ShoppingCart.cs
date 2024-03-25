using eShop.Application.PluginInterfaces.DataStore;
using eShop.Core.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace eShop.ShoppingCart.Local;

public class ShoppingCart : IShoppingCart
{
    private readonly IJSRuntime _jSRuntime;
    private readonly IProductRepository _productRepository;
    private const string cstrShoppingCart = "eShop.ShoppingCart";

    public ShoppingCart(IJSRuntime jSRuntime, IProductRepository ProductRepository)
    {
        _jSRuntime = jSRuntime;
        _productRepository = ProductRepository;
    }
    private async Task<Order> GetOrder()
    {
        Order order = null;

        var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
        
        if (!string.IsNullOrWhiteSpace(strOrder))
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
            cstrShoppingCart,
            JsonConvert.SerializeObject(order));
    }
}