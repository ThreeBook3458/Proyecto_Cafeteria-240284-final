var builder = WebApplication.CreateBuilder(args);

// Agrega servicios
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // ?? habilita la sesión

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // ?? activa la sesión

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();




