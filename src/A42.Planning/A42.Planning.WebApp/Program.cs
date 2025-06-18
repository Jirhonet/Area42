using A42.Planning.Data.Abstractions;
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
        /// Adds all services
        /// </summary>
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPlanningService, PlanningService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ILocationService, LocationService>();

            return services;
        }
    }
}