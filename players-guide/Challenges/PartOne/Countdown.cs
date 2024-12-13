namespace Challenges.PartOne;

public class Countdown
{
    public void Solution(int startingTime)
    {
        Console.WriteLine(startingTime);
        if (startingTime == 1)
        {
            return;
        }


        Solution(startingTime - 1);
    }

}
