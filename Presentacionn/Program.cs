using BibliotecaDigital.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Presentacionn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuraci�n de servicios
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            // Agregar servicios de autorizaci�n
            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews(); // Aseg�rate de agregar servicios para MVC o Razor Pages

            var app = builder.Build();

            // Configuraci�n del pipeline de solicitudes
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization(); // Middleware de autorizaci�n

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
