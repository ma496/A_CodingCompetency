namespace Rules.Test;

public class RulesEngineTest
{
    [Fact]
    public void GetOutput()
    {
        IRulesEngine rulesEngine = new RulesEngine();
        rulesEngine.AddRule(3, "foo");
        rulesEngine.AddRule(5, "bar");

        var expected = "1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar";
        var actual = rulesEngine.GetOutput(15);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetSpecificNumberOutput()
    {
        IRulesEngine rulesEngine = new RulesEngine();
        rulesEngine.AddRule(3, "foo");
        rulesEngine.AddRule(5, "bar");
        rulesEngine.AddRule(7, "jazz");

        Assert.Equal("foojazz", rulesEngine.GetSpecificNumberOutput(21));
        Assert.Equal("barjazz", rulesEngine.GetSpecificNumberOutput(35));
        Assert.Equal("foobarjazz", rulesEngine.GetSpecificNumberOutput(105));
    }
}