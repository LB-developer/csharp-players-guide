namespace Challenges.PartOne;

public class TheDefenceOfConsolas
{
    public void Solution()
    {
        Console.Title = "Defence of Consolas";
        var rand = new Random();

        int row;
        int col;

        Console.WriteLine($"Target Row: {row = rand.Next(1, 8),8}");
        Console.WriteLine($"Target Column: {col = rand.Next(1, 8),5}");

        Console.WriteLine("-- Deploying --");

        Console.BackgroundColor = ConsoleColor.Black;

        Console.WriteLine($"({row + 1}, {col})");
        Console.WriteLine($"({row - 1}, {col})");
        Console.WriteLine($"({row}, {col + 1})");
        Console.WriteLine($"({row}, {col - 1})");

        Console.Beep();

    }

}
