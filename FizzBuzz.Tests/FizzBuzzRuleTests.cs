using FizzBuzz.Domain.Rules;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzRuleTests
    {
        [TestMethod]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(6, true)]
        [DataRow(8, false)]
        public void FizzRule_MatchesMultiplesOf3(int input, bool expected)
        {
            var rule = new FizzRule();
            Assert.AreEqual(expected, rule.IsMatch(input));
        }

        [TestMethod]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(10, true)]
        public void BuzzRule_MatchesMultiplesOf5(int input, bool expected)
        {
            var rule = new BuzzRule();
            Assert.AreEqual(expected, rule.IsMatch(input));
        }

        [TestMethod]
        [DataRow(15, true)]
        [DataRow(12, false)]
        [DataRow(30, true)]
        [DataRow(32, false)]
        public void FizzBuzzRule_MatchesMultiplesOf3And5(int input, bool expected)
        {
            var rule = new FizzBuzzRule();
            Assert.AreEqual(expected, rule.IsMatch(input));
        }
    }
}
