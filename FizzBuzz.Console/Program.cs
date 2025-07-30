using FizzBuzz.Application.Services;
using FizzBuzz.Domain.Rules;
using FizzBuzz.Domain.Writers;
using FizzBuzz.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            // Rules added in the order of precedence
            services.AddSingleton<IFizzBuzzRule, FizzBuzzRule>();
            services.AddSingleton<IFizzBuzzRule, FizzRule>();
            services.AddSingleton<IFizzBuzzRule, BuzzRule>();

            services.AddSingleton<IOutputWriter, ConsoleOutputWriter>();
            services.AddSingleton<IFizzBuzzService, FizzBuzzService>();

            var provider = services.BuildServiceProvider();
            var fizzBuzzService = provider.GetRequiredService<IFizzBuzzService>();

            Console.WriteLine("Running Sync:");
            fizzBuzzService.Run(1, 20);

            Console.WriteLine("\nRunning Async:");
            await fizzBuzzService.RunAsync(1, 20);
        }
    }
}

