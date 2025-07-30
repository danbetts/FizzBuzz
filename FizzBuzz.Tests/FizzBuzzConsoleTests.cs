using FizzBuzz.Infrastructure;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzConsoleTests : FizzBuzzTestsBase<TestOutputWriter>
    {
        protected override TestOutputWriter CreateWriter() => new TestOutputWriter();

        [TestMethod]
        public void Run_PrintsExpectedFizzBuzz()
        {
            Service.Run(1, 5);
            var expected = new string[] { "1", "2", "Fizz", "4", "Buzz" };
            CollectionAssert.AreEqual(expected, OutputWriter.Output);
        }

        [TestMethod]
        public async Task RunAsync_PrintsExpectedFizzBuzz()
        {
            await Service.RunAsync(1, 5);
            var expected = new string[] { "1", "2", "Fizz", "4", "Buzz" };
            CollectionAssert.AreEqual(expected.ToList(), OutputWriter.Output);
        }
    }
}