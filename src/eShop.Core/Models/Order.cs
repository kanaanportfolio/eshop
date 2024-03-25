namespace eShop.Core.Models;

public class Order
{
    public Order() 
    {
        LineItems = new();
    }

    public int? OrderId { get; set; }
    public string UniqueId { get; set; }

    public DateTime? DatePlaced { get; set; }
    public DateTime? DateProcessing { get; set; }
    public DateTime? DateProcessed { get; set; }

    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerStateProvince { get; set; }
    public string CustomerCountry { get; set; }

    public string AdminUser { get; set; }

    public List<OrderLineItem> LineItems { get; set; }

    public void AddProduct(int productId, int quantity, double price)
    {
        var existingItem = LineItems.FirstOrDefault(
            i => i.ProductId == productId);

        if (existingItem == null)
        {
            LineItems.Add(new OrderLineItem
            {
                ProductId = productId,
                Price = price,
                Quantity = quantity,
                OrderId = this.OrderId
            });
        }
        else
        {
            existingItem.Quantity += quantity;
        }
    }

    public void RemoveProduct(int productId)
    {
        var item = LineItems.FirstOrDefault(i => i.ProductId == productId);
        
        if (item != null)
        {
            LineItems.Remove(item);
        }
    }
}