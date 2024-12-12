namespace Challenges.PartOne;

public class RepairingTheClockTower
{
    public void Solution()
    {

        int number;
        Console.Write("Enter a number for the clock: ");
        int.TryParse(Console.ReadLine(), out number);

        if (number % 2 == 0)
        {
            Console.WriteLine("Tick");
        }
        else
        {
            Console.WriteLine("Tock");
        }



    }

}
