using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Budget.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BudgetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetContext") ??
                         throw new InvalidOperationException("Connection string 'BudgetContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();