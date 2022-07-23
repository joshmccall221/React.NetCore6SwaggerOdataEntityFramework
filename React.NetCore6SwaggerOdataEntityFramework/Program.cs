using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using React.NetCore6SwaggerOdataEntityFramework;
using React.NetCore6SwaggerOdataEntityFramework.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReactNetCore6SwaggerOdataEntityFrameworkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReactNetCore6SwaggerOdataEntityFrameworkContext") ?? throw new InvalidOperationException("Connection string 'ReactNetCore6SwaggerOdataEntityFrameworkContext' not found.")));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<WeatherForecast>("WeatherForecasts");
    return builder.GetEdmModel();
}
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();