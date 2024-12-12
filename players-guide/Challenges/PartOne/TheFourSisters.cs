
namespace Challenges.PartOne;

public class TheFourSistersAndTheDuckbear
{
    public void Solution()
    {

        int numberOfEggs;
        int eachSisterEggCount;
        int duckbearEggCount;

        Console.Write("Enter the amount of eggs: ");
        while (!int.TryParse(Console.ReadLine(), out numberOfEggs))
        {
            Console.WriteLine("Please enter a valid number");
            Console.Write("Enter the amount of eggs: ");
        }

        eachSisterEggCount = numberOfEggs / 4;
        duckbearEggCount = numberOfEggs % 4;

        Console.WriteLine($"Sisters get {eachSisterEggCount} each");
        Console.WriteLine($"Duckbear gets {duckbearEggCount}");

    }
}
