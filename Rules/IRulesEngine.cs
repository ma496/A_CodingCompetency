namespace Rules;

public interface IRulesEngine
{
    void AddRule(int divisor, string output);
    string GetOutput(int number);
    string GetSpecificNumberOutput(int number);
}
