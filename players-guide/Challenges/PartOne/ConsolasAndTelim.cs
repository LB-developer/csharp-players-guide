
namespace Challenges.PartOne;

public class ConsolasAndTelim
{
    public void Solution()
    {

        string name;
        string greeting = "Hello, there";
        string question = "What is your name?";
        string acknowledgement = "Hello there ";

        Console.WriteLine(greeting);
        Console.WriteLine(question);
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
        {

            Console.WriteLine("Please enter a valid name");

        }
        Console.WriteLine(acknowledgement + name);

    }

}
