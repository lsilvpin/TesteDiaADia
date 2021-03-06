using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TesteDiaADia.Models;

namespace TesteDiaADia.Data
{
    public class EfContext : DbContext
    {
        private readonly Config _config = GetConfig();

        public virtual DbSet<Entity> Entities { get; set; }

        public EfContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool isConfigured = optionsBuilder.IsConfigured;

            if (!isConfigured)
            {
                string connectionString = _config.ConnectionString;
                ConfigureDbContext(optionsBuilder, connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().ToTable("Entities");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


        #region :: Private methods
        private static Config GetConfig()
        {
            ServiceCollection services = new ServiceCollection();
            Injector.Initialize(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Config config = serviceProvider.GetRequiredService<Config>();

            return config;
        }

        private static void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("TesteDiaADia"));
        }
        #endregion
    }
}
