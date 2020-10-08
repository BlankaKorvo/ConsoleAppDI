using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ConsoleAppDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("log.txt")
                .CreateLogger();

            var builder = new ConfigurationBuilder().AddJsonFile("mySettings.json");
            IConfiguration configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

            serviceCollection.AddSingleton<MyClass>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var myClassFromDI = serviceProvider.GetRequiredService<MyClass>();

            myClassFromDI.DoSometing();
        }        
    }
}
