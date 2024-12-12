namespace Challenges.PartOne;

public class TheTriangleFarmer
{

    public int Solution()
    {

        int _base;
        int height;

        Console.Write("Enter base: ");
        _base = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter height: ");
        height = Convert.ToInt32(Console.ReadLine());


        return (_base * height) / 2;

    }

}
