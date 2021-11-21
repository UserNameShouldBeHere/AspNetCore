using System;
using System.Collections.Generic;
using System.Globalization;

ICollection<string> dutyHistoryList = new List<string>();
string getDutyHistory(int price)
{
    double duty = price > 200 ? (price - 200) * 0.15 : 0;
    string history = $"Размер таможенной пошлины: {duty}€\n\nИстория просмотра:\n";
    foreach (string historyDuty in dutyHistoryList)
        history += historyDuty;
    dutyHistoryList.Add($"Цена: {price}€; Пошлина: {duty}€\n");
    return history;
}

string getDate(string language)
{
    return DateTime.Now.ToString("D", new CultureInfo(language)) + ' ' + DateTime.Now.ToLongTimeString();;
}

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/customs_duty", (int price) => getDutyHistory(price));

app.MapGet("/date", (string language) => getDate(language));

app.Run();