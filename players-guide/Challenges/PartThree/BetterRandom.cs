
public static class RandomExtensions
{
    public static int NextDouble()
    {
        var random = new Random();
        var choice = random.Next(0, 10 + 1);
        return choice;
    }

    public static string NextString(params string[] text)
    {
        var random = new Random();
        var choice = random.Next(0, 4);

        return text[choice];
    }

    public static bool CoinToss(double frequency = 0.5)
    {
        var random = new Random();
        var choice = random.NextDouble();

        if (choice <= frequency)
        {
            return false;
        }

        return true;
    }
}
