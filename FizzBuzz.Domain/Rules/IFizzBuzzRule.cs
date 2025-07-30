namespace FizzBuzz.Domain.Rules
{
    public interface IFizzBuzzRule
    {
        bool IsMatch(int number);
        string GetOutput();
    }
}
