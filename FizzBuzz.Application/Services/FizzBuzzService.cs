using FizzBuzz.Domain.Rules;
using FizzBuzz.Domain.Writers;

namespace FizzBuzz.Application.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IFizzBuzzRule> _rules;
        private readonly IOutputWriter _writer;

        public FizzBuzzService(IEnumerable<IFizzBuzzRule> rules, IOutputWriter writer)
        {
            _rules = rules;
            _writer = writer;
        }

        public void Run(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                var result = GetOutput(i);
                _writer.Write(result);
            }
        }

        public async Task RunAsync(int start, int end, CancellationToken cancellationToken = default)
        {
            for (int i = start; i <= end; i++)
            {
                var result = GetOutput(i);
                await _writer.WriteAsync(result, cancellationToken);
            }
        }

        private string GetOutput(int index) => _rules.FirstOrDefault(r => r.IsMatch(index))?.GetOutput() ?? index.ToString();
    }
}
