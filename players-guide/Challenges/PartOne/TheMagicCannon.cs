namespace Challenges.PartOne;

public class TheMagicCannon
{

    public void Solution()
    {

        for (int i = 0; i <= 100; i++)
        {

            string result;

            switch (i)
            {
                case int when i % 3 == 0:
                    result = "Fire";
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case int when i % 5 == 0:
                    result = "Electric";
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                default:
                    result = "Normal";
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }

            Console.WriteLine(result);

        }


    }

}
