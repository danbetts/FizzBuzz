using FizzBuzz.Domain.Writers;

namespace FizzBuzz.Infrastructure
{
    public class FileOutputWriter : IOutputWriter
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public FileOutputWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string value)
        {
            _semaphore.Wait();
            try
            {
                File.AppendAllText(_filePath, value + Environment.NewLine);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task WriteAsync(string value, CancellationToken cancellationToken = default)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                await File.AppendAllTextAsync(_filePath, value + Environment.NewLine, cancellationToken);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
