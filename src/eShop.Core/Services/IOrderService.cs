using eShop.Core.Models;

namespace eShop.Core.Services;

public interface IOrderService
{
    bool ValidateOrderUpdate(Order order);
}