using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;

ConcurrentBag<Product> productList = new ConcurrentBag<Product>();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDate, CurrentDate>();
var app = builder.Build();
var date = app.Services.GetService<IDate>();

string ShowProducts(IDate date)
{
    string products = "";
    if (date.GetDate().DayOfWeek == DayOfWeek.Saturday || date.GetDate().DayOfWeek == DayOfWeek.Sunday)
    {
        foreach (Product product in productList)
        {
            products += $"Type: {product.Type}; Name: {product.Name}; Price: {product.Price * (decimal)1.5}\n";
        }
    }
    else
    {
        foreach (Product product in productList)
        {
            products += $"Type: {product.Type}; Name: {product.Name}; Price: {product.Price}\n";
        }
    }

    return products;
}

productList.Add(new Product("Еда", "Молоко", 1000));
productList.Add(new Product("Еда", "Яблоко", 1200));
productList.Add(new Product("Хоз. товары", "Мыло", 150));
productList.Add(new Product("Техника", "Телевизор", 60000));
productList.Add(new Product("Техника", "Кофеварка", 8000));

app.MapGet("/catalog", () => ShowProducts(new CurrentDate()));

app.Run();