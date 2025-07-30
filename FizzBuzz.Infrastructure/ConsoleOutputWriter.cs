using FizzBuzz.Domain.Writers;

namespace FizzBuzz.Infrastructure
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public Task WriteAsync(string value, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(value);
            return Task.CompletedTask;
        }

        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
