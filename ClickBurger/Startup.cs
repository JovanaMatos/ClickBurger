using ClickBurger.Context;
using ClickBurger.Models;
using ClickBurger.Repositories;
using ClickBurger.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickBurger;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<IHamburguerRepository, HamburguerRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));//a cada request e instancia diferente

        services.AddControllersWithViews();

        services.AddMemoryCache();
        services.AddSession();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
       
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Hamburguer/{action}/{categoria?}",
                defaults: new { Controller = "Hamburguer", action = "List"});

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}