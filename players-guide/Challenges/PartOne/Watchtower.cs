namespace Challenges.PartOne;

public class WatchTower
{

    public void Solution()
    {

        Console.Write("Input X coordinate: ");
        int.TryParse(Console.ReadLine(), out int x);
        Console.Write("Input Y coordinate: ");
        int.TryParse(Console.ReadLine(), out int y);

        if (x == 0 && y == 0)
            Console.WriteLine("Behind you bruh");
        else
        {

            string enemyLocation = "";
            switch (y)
            {
                case > 0:
                    enemyLocation += "N";
                    break;
                case < 0:
                    enemyLocation += "S";
                    break;
            }

            switch (x)
            {
                case < 0:
                    enemyLocation += "W";
                    break;

                case > 0:
                    enemyLocation += "E";
                    break;
            }

            Console.WriteLine($"Enemy is in the {enemyLocation} direction");
        }


    }

    public void SolutionTwo()
    {

        Console.Write("Input X coordinate: ");
        int.TryParse(Console.ReadLine(), out int x);
        Console.Write("Input Y coordinate: ");
        int.TryParse(Console.ReadLine(), out int y);

        string direction = "";

        direction = y switch
        {
            < 0 => "S",
            > 0 => "N",
            _ => ""
        };

        direction += x switch
        {
            < 0 => "W",
            > 0 => "E",
            _ => ""
        };

        if (direction != "")
            Console.WriteLine($"Enemy is in the {direction} direction");
        else
        {
            Console.WriteLine("Behind you bruh");
        }

    }
}
