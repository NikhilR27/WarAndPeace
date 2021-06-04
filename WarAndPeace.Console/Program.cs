using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarAndPeace.Application.Interface;
using WarAndPeace.Infrastructure.IoC;

namespace WarAndPeace.Console
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IBookReaderService bookReader = _serviceProvider.GetService<IBookReaderService>();
            var allWords = bookReader.GetWords();

            System.Console.WriteLine($"In total there are {allWords.Count} words");
            System.Console.WriteLine($"Top 50 words  {allWords.Count}");
            System.Console.WriteLine($"Top 50 words longer than 6 characters {allWords.Count}");

            DisposeServices();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            var configuration = InitConfig();

            _serviceProvider = DependencyContainer.RegisterServices(services, configuration).BuildServiceProvider();
        }

        private static IConfiguration InitConfig()
        {
            IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            return Configuration;
        }
    }
}
