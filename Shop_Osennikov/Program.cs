using Shop_Osennikov.Data.DataBase;
using Shop_Osennikov.Data.Interfaces;
using Shop_Osennikov.Data.Mocks;
using Shop_Osennikov.Data.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddTransient<ICategorys, DBCategory>();
builder.Services.AddTransient<IItems, DBItems>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();