using FizzBuzz.Application.Services;
using FizzBuzz.Domain.Rules;
using FizzBuzz.Domain.Writers;

namespace FizzBuzz.Tests
{
    public abstract class FizzBuzzTestsBase<TWriter> where TWriter : IOutputWriter
    {
        protected TWriter OutputWriter { get; private set; }
        protected FizzBuzzService Service { get; private set; }

        [TestInitialize]
        public virtual void TestInitialize()
        {
            OutputWriter = CreateWriter();
            var rules = new List<IFizzBuzzRule> { new FizzBuzzRule(), new FizzRule(), new BuzzRule() };
            Service = new FizzBuzzService(rules, OutputWriter);
        }

        protected abstract TWriter CreateWriter();
    }
}
