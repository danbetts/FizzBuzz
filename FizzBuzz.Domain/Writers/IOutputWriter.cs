namespace FizzBuzz.Domain.Writers
{
    public interface IOutputWriter
    {
        Task WriteAsync(string value, CancellationToken cancellationToken = default);
        void Write(string value);
    }
}
