using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IActorsService, ActorsServices>();
builder.Services.AddScoped<IProducersServices, ProducersServices>();
builder.Services.AddScoped<IMoviesServices, MoviesServices>();
builder.Services.AddScoped<ICinemasService, CinemasServices>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");
AppDbInitializer.Seed(app);

app.Run();
