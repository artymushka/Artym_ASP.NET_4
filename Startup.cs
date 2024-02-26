
namespace Library
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Добавляем сервисы для контроллеров
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Library", async context =>
                {
                    await context.Response.WriteAsync("Welcome to our Library!!!!");
                });

                endpoints.MapGet("/Library/Books", async context =>
                {
                    string booksData = await System.IO.File.ReadAllTextAsync("books.json");
                    await context.Response.WriteAsync(booksData);
                });

                endpoints.MapControllerRoute(
                    name: "LibraryProfile",
                    pattern: "Library/Profile/{id?}",
                    defaults: new { controller = "Profile", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
