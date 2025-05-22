using A42.Planning.Data.Repositories;
using A42.Planning.Domain.Services;

namespace A42.Planning.WebApp
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRepositories(builder.Configuration.GetConnectionString("Default"));
            builder.Services.AddServices();
            builder.Services.AddRazorPages();

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }

        /// <summary>
        /// Adds all repositories that inherit from <see cref="RepositoryBase"/>
        /// </summary>
        private static IServiceCollection AddRepositories(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string not provided.");

            DataContext dataContext = new DataContext(connectionString);
            services.AddSingleton(dataContext);

            // Register all repositories
            foreach (Type repositoryType in typeof(RepositoryBase).Assembly.GetExportedTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(RepositoryBase))))
                services.AddScoped(repositoryType);

            return services;
        }

        /// <summary>
        /// Adds all services that implement <see cref="IService"/>
        /// </summary>
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register all services
            foreach (Type serviceType in typeof(IService).Assembly.GetExportedTypes().Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IService))))
                services.AddScoped(serviceType);

            return services;
        }
    }
}