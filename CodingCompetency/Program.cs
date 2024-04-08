using Rules;

// Question 1

IRulesEngine rulesEngine = new RulesEngine();
rulesEngine.AddRule(3, "foo");
rulesEngine.AddRule(5, "bar");

Console.WriteLine(rulesEngine.GetOutput(15)); // print: 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar

// Question 2

rulesEngine.AddRule(7, "jazz");

Console.WriteLine(rulesEngine.GetSpecificNumberOutput(21)); // print: foojazz
Console.WriteLine(rulesEngine.GetSpecificNumberOutput(35)); // print: barjazz
Console.WriteLine(rulesEngine.GetSpecificNumberOutput(105)); // print: foobarjazz

// Question 3

// add missing rules
rulesEngine.AddRule(4, "baz");
rulesEngine.AddRule(9, "huzz");

// Question 4

// user can add own rule and see the number output according to rule
while (true)
{
    Console.WriteLine("\nPress r key for add rule.");
    Console.WriteLine("Press n key for enter number.");
    Console.Write("Press q for quit.");
    var keyInfo = Console.ReadKey();

    if (keyInfo.Key == ConsoleKey.Q)
        break;

    if (keyInfo.Key == ConsoleKey.R)
    {
        Console.Write("\nAdd rule formate should be (divisor, output) without parenthesis.");
        var str = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(str))
        {
            ShowError("Invalid format.");
            continue;
        }

        var strSplit = str.Split(",");
        if (strSplit.Length != 2)
        {
            ShowError("Invalid format.");
            continue;
        }

        if (int.TryParse(strSplit[0], out var value))
        {
            if (value < 1)
            {
                ShowError("divisor should be positive number.");
                continue;
            }
            rulesEngine.AddRule(value, strSplit[1]);
            Console.WriteLine("Successfully added rule");
        }
        else
        {
            ShowError("Invalid format.");
            continue;
        }
    }

    if (keyInfo.Key == ConsoleKey.N)
    {
        Console.Write("\nEnter number.");
        var str = Console.ReadLine();

        if (int.TryParse(str, out var value))
        {
            if (value < 1)
            {
                ShowError("number should be positive.");
                continue;
            }
            Console.WriteLine($"Output of {value}: {rulesEngine.GetSpecificNumberOutput(value)}");
            Console.WriteLine($"Output from 1 to {value}: {rulesEngine.GetOutput(value)}");
        }
        else
        {
            ShowError("Invalid number.");
            continue;
        }
    }
}

void ShowError(string error)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(error);
    Console.ForegroundColor = ConsoleColor.White;
}