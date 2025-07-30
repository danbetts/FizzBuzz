namespace FizzBuzz.Application.Services
{
    public interface IFizzBuzzService
    {
        void Run(int start, int end);
        Task RunAsync(int start, int end, CancellationToken cancellationToken = default);
    }
}