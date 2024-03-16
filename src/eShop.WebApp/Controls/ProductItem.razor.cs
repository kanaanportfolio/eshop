using eShop.Core.Models;
using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Controls;

public partial class ProductItem
{
    [Parameter]
    public Product Product { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
}