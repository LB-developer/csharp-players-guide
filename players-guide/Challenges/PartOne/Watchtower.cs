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

}
