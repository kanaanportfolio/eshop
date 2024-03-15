namespace eShop.Core.Models;

public class Product
{
    public int Id { get; set; }

    public string Brand { get; set; } = default!;

    public string Name { get; set; } = default!;

    public double Price { get; set; }

    public string ImageLink { get; set; } = default!;

    public string Description { get; set; } = default!;
}
