namespace Challenges.PartOne;

public class TheReplicatorOfDTo
{
    public void Solution()
    {

        int[] userNumbers = new int[5];

        int AskForNumber(string text)
        {
            int response;
            Console.WriteLine(text);
            int.TryParse(Console.ReadLine(), out response);
            return response;
        }
        for (int i = 0; i < 5; i++)
        {

            int userGivenNumber;

            string instruction = "Enter a number:";

            userGivenNumber = AskForNumber(instruction);

            userNumbers[i] = userGivenNumber;

        }

        int[] nextUserNumbers = new int[5];

        for (int i = 0; i < userNumbers.Length; i++)
        {
            Console.WriteLine(userNumbers[i]);
            nextUserNumbers[i] = userNumbers[i];
        }


        for (int i = 0; i < userNumbers.Length; i++)
        {
            Console.WriteLine(nextUserNumbers[i]);
        }

    }

}
