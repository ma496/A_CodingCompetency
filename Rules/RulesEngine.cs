using System.Text;

namespace Rules;

public class RulesEngine : IRulesEngine
{
    private readonly Dictionary<int, string> _rules;

    public RulesEngine()
    {
        _rules = [];
    }

    public void AddRule(int divisor, string output)
    {
        if (divisor < 1)
            throw new ArgumentOutOfRangeException(nameof(divisor));
        if (string.IsNullOrEmpty(output))
            throw new ArgumentNullException(nameof(output));

        _rules[divisor] = output;
    }

    public string GetOutput(int number)
    {
        var output = new StringBuilder();
        for (var seq = 1; seq <= number; seq++)
        {
            output.Append(GetSpecificNumberOutput(seq) + (seq < number ? ", " : ""));
        }

        return output.ToString();
    }

    public string GetSpecificNumberOutput(int number)
    {
        var output = new StringBuilder();

        foreach (var rule in _rules)
        {
            if (number % rule.Key == 0)
                output.Append(rule.Value);
        }

        if (output.ToString() == string.Empty)
        {
            output.Clear();
            output.Append(number);
        }

        return output.ToString();
    }
}
