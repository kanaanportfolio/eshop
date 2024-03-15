using Microsoft.AspNetCore.Components;

namespace eShop.WebApp.Controls;

public partial class SearchBar
{
    private string filter;

    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    private void HandleSearch(string filter)
    {
        OnSearch.InvokeAsync(filter);
    }
}