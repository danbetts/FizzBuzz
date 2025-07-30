using FizzBuzz.Infrastructure;

namespace FizzBuzz.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class FizzBuzzFileTests : FizzBuzzTestsBase<FileOutputWriter>
    {
        private const string OutputPath = "test_output.txt";

        protected override FileOutputWriter CreateWriter() => new(OutputPath);

        [TestInitialize]
        public override void TestInitialize()
        {
            if (File.Exists(OutputPath))
                File.Delete(OutputPath);

            base.TestInitialize();
        }

        [TestMethod]
        public void Run_WritesToFile()
        {
            Service.Run(1, 5);
            var lines = File.ReadAllLines(OutputPath);
            var expected = new string[] { "1", "2", "Fizz", "4", "Buzz" };
            CollectionAssert.AreEqual(expected, lines);
        }

        [TestMethod]
        public async Task RunAsync_WritesToFile()
        {
            await Service.RunAsync(1, 5);
            var lines = File.ReadAllLines(OutputPath);
            var expected = new string[] { "1", "2", "Fizz", "4", "Buzz" };
            CollectionAssert.AreEqual(expected, lines);
        }
    }
}
