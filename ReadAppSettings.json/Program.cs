using System;
using Microsoft.Extensions.DependencyInjection;

namespace ReadAppSettings.json
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            new Startup().ConfigureServices(serviceCollection);

            ExecuteOnceOtherClass(serviceCollection);

            Console.ReadLine();
        }

        private static void ExecuteOnceOtherClass(IServiceCollection serviceCollection)
        {
            serviceCollection.BuildServiceProvider().GetService<OtherClass>()?.Run();
        }
    }
}