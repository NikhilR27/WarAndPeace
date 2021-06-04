using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarAndPeace.Application;
using WarAndPeace.Application.Interface;
using WarAndPeace.Infrastructure.Data;
using WarAndPeace.Infrastructure.Data.Interface;

namespace WarAndPeace.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDataReader>(s => new TextFileReader(configuration.GetSection("DataSource")["FileName"]));
            services.AddSingleton<IBookReaderService, BookReaderService>();
            return services;
        }
    }
}
