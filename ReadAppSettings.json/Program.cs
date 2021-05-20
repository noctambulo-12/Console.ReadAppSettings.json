using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ReadAppSettings.json
{
    internal class Program
    {
        public static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("ServerName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("DatabaseName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("UserName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("Password").Value);

            Console.WriteLine(Configuration.GetConnectionString("DataConnection"));

            Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            serviceCollection.AddSingleton(Configuration);
        }
    }
}