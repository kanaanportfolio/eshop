using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using eShop.WebApp.Data;
using eShop.Application.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductsScreen;
using eShop.UseCases.ViewProductScreen; 
using eShop.DataStore.HardCoded;
using eShop.Application.ViewProductScreen;
using eShop.Application.PluginInterfaces.UI;
using eShop.ShoppingCart.Local;
using eShop.Application.ShoppingCartScreen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductsUseCase, SearchProductsUseCase>();
builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
