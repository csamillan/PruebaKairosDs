using KairosDs;
using KairosDs.Persona;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//Creacion la variable de conexion para la base de datos.
builder.Services.AddDbContext<ModelDbContext>(options =>
{
    var connectionStr = builder.Configuration.GetConnectionString("kairosDs") ??
        throw new Exception("Connetion string 'kairosDs' not found");
    options.UseSqlServer(connectionStr);
});

builder.Services.AddAutoMapper(Assembly.Load("KairosDs"));
builder.Services.AddScoped<IPersonaService, PersonaService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ModelDbContext>();
    //context.Database.EnsureDeleted(); //Eliminar Base de datos.
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
