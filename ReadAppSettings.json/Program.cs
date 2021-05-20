using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ReadAppSettings.json
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("ServerName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("DatabaseName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("UserName").Value);
            Console.WriteLine(Configuration.GetSection("DbConnectionConfig").GetSection("Password").Value);

            Console.WriteLine(Configuration.GetConnectionString("DataConnection"));

            Console.WriteLine(Configuration.GetValue<string>("DbConnectionConfig:ServerName"));

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            await serviceProvider.GetService<OtherClass>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            serviceCollection.AddSingleton(Configuration);

            serviceCollection.AddTransient<OtherClass>();
        }
    }

    public class OtherClass
    {
        private readonly IConfigurationRoot _config;

        public OtherClass(IConfigurationRoot config)
        {
            _config = config;
        }

        public async Task Run()
        {
            List<string> contactEmails = _config.GetSection("ContactEmails").Get<List<string>>();
            foreach (var email in contactEmails)
            {
                Console.WriteLine(email);
            }
        }

    }
}