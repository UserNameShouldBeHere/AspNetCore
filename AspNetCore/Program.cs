using System;
using System.Collections.Generic;
using System.Globalization;

ICollection<string> dutyHistoryList = new List<string>();

decimal GetDuty(decimal price)
{
    return price > 200 ? (price - 200) * (decimal) 0.15 : 0;
}

string GetDutyHistory(decimal price)
{
    decimal duty = GetDuty(price);
    string history = $"Размер таможенной пошлины: {duty}€\n\nИстория просмотра:\n";
    foreach (string historyDuty in dutyHistoryList)
        history += historyDuty;
    dutyHistoryList.Add($"Цена: {price}€; Пошлина: {duty}€\n");
    return history;
}

string GetDate(string language)
{
    return DateTime.Now.ToString("D", new CultureInfo(language)) + ' ' + DateTime.Now.ToLongTimeString();;
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/customs_duty", (decimal price) => GetDutyHistory(price));

app.MapGet("/date", (string language) => GetDate(language));

app.Run();