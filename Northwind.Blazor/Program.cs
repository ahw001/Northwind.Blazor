using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Northwind.Blazor.Components;
using Northwind.Blazor.Model.Cybersource.PayerAuthentication;
using Northwind.Blazor.Services.DIServices;
using Northwind.Blazor.Services.Utilities;
using System;
using System.Net.Http.Headers;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ITransactionJson, TransactionJson>();
builder.Services.AddScoped<ICustomersScoped, CustomersScoped>();
builder.Services.AddScoped<ISessionTransactions, SessionTransactions>();
builder.Services.AddSingleton<ICardService, CardService>();
builder.Services.AddHostedService<CardServiceInitializer>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


var configValues = new ConfigValues(builder.Configuration);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Configure application cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.None;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

builder.Services.Configure<AntiforgeryOptions>(config =>
{
    config.Cookie.SecurePolicy = CookieSecurePolicy.None;
});

builder.Services.Configure<CookieTempDataProviderOptions>(config =>
{
    config.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddHttpClient(name: "Northwind.WebApi.Service",
  configureClient: options =>
  {
      options.BaseAddress = new(configValues.GetServereUrlAddress());
      options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue(
          "application/json", 1.0));
  }
);

var app = builder.Build();

// Additional configurations
var httpClientFactory = app.Services.GetRequiredService<IHttpClientFactory>();
HttpClientHelper.Initialize(httpClientFactory);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.MapPost("/stepup-callback", async (HttpContext http) =>
{
    var form = await http.Request.ReadFormAsync();
    var transactionId = form["TransactionId"].ToString();
    var guid = form["MD"].ToString();
    var redirectUrl = $"/stepup-complete?transactionId={transactionId}&guid={guid}";
    var html = $@"
    <html>
        <head><title>Redirecting...</title></head>
        <body>
            <script>
                window.top.location.href = '{redirectUrl}';
            </script>
        </body>
    </html>";

    return Results.Content(html, "text/html");

})
.DisableAntiforgery();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();
app.UseAntiforgery();

app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] = "frame-ancestors *;";
    await next();
});


app.Run();
