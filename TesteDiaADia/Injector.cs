using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;
using TesteDiaADia.Business;
using TesteDiaADia.Data;
using TesteDiaADia.Models;
using TesteDiaADia.Tools.Malet;

namespace TesteDiaADia
{
    public static class Injector
    {
        private static ServiceCollection _services;

        internal static void Initialize(ServiceCollection services)
        {
            _services = services;

            InjectServices();
        }

        private static void InjectServices()
        {
            InjectTools();
            InjectConfigs();
            InjectDbContext();
            InjectData();
            InjectBusiness();
        }

        private static void InjectBusiness()
        {
            _services.AddTransient<EntityLogic>();
        }

        private static void InjectData()
        {
            _services.AddTransient<Repository<Entity>>();
        }

        private static void InjectDbContext()
        {
            _services.AddScoped<EfContext>();
        }

        private static void InjectConfigs()
        {
            using ServiceProvider serviceProvider = _services.BuildServiceProvider();
            FileTools fileTools = serviceProvider.GetRequiredService<FileTools>();

            string root = fileTools.Root;
            string wfConfigPhisicalPath = $@"{root}\TesteDiaADia\config.json";
            using StreamReader wfConfigStreamReader = new StreamReader(wfConfigPhisicalPath);
            string wfConfigJson = wfConfigStreamReader.ReadToEnd();
            Config config = JsonSerializer.Deserialize<Config>(wfConfigJson);

            _services.AddSingleton(config);
        }

        private static void InjectTools()
        {
            _services.AddTransient<FileTools>();
        }
    }
}
