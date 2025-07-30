using FizzBuzz.Domain.Writers;

namespace FizzBuzz.Infrastructure
{
    public class TestOutputWriter : IOutputWriter
    {
        public List<string> Output { get; } = new();

        public Task WriteAsync(string value, CancellationToken cancellationToken = default)
        {
            Output.Add(value);
            return Task.CompletedTask;
        }

        public void Write(string value)
        {
            Output.Add(value);
        }
    }
}
