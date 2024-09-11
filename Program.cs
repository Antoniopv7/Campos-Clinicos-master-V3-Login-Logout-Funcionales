using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Campos_Clinicos.Data; // Reemplaza con el nombre correcto de tu espacio de nombres
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Registra servicios en el contenedor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 2. Registra AuthService y CustomAuthStateProvider para la inyección de dependencias
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// 3. Habilita la autenticación
builder.Services.AddAuthorizationCore();

// 4. Registra tu DbContext con PostgreSQL (Npgsql)
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CamposClinicos")));

var app = builder.Build();

// 5. Configura la canalización de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 6. Mapea las rutas de Blazor y fallback para la página principal
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// 7. Ejecuta la aplicación
app.Run();

