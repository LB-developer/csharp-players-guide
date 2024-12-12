namespace Challenges.PartOne;

public class TheDominionOfKings
{
    public void Solution()
    {

        int estate;
        int duchy;
        int province;

        int.TryParse(Console.ReadLine(), out estate);
        int.TryParse(Console.ReadLine(), out duchy);
        int.TryParse(Console.ReadLine(), out province);

        Console.WriteLine($"Total Points: {estate + duchy * 3 + province * 6}");

    }

}
