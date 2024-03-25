using eShop.Core.Models;

namespace eShop.Core.Services;

public class OrderService : IOrderService
{
    public bool ValidateOrderUpdate(Order order)
    {
        if (order == null) return false;
        if (!order.OrderId.HasValue) return false;
        if (order.LineItems == null || order.LineItems.Count < 1) return false;
        if (order.DateProcessed.HasValue) return false;
        if (order.DateProcessing.HasValue) return false;
        return true;
    }
}