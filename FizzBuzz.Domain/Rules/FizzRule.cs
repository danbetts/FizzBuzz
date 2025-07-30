namespace FizzBuzz.Domain.Rules
{
    public class FizzRule : IFizzBuzzRule
    {
        public bool IsMatch(int number) => number % 3 == 0;
        public string GetOutput() => "Fizz";
    }
}