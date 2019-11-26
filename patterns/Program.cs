using patterns.DependencyInjection;
using printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();

            var services = new DiServiceCollection();            

            services.RegisterTransient<RandomGuidGenerator>();

            services.RegisterSingleton<ISomeExternalService, SomeExternalServiceOne>();
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();

            var container = services.GenerateContainer();

            var randomGuidGeneratorServiceFirst = container.GetService<RandomGuidGenerator>();
            var randomGuidGeneratorServiceSecond = container.GetService<RandomGuidGenerator>();            

            var someServiceFirst = container.GetService<ISomeExternalService>();
            var someServiceSecond = container.GetService<ISomeExternalService>();

            printer.WriteLine("Only service registered transient:");
            printer.WriteLine(randomGuidGeneratorServiceFirst.RandomGuid.ToString());
            printer.WriteLine(randomGuidGeneratorServiceSecond.RandomGuid.ToString());

            printer.WriteLine("\nService and implementation registered singleton:");
            printer.WriteLine(someServiceFirst.PrintSomething());
            printer.WriteLine(someServiceSecond.PrintSomething());

            printer.ReadLine();
        }
    }
}
