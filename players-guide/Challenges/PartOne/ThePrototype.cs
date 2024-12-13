namespace Challenges.PartOne;

public class ThePrototype
{
    public void Solution()
    {

        int position;
        // Get number target from User 1
        Console.Write("Enter a number between 0 and 100: ");
        while (!int.TryParse(Console.ReadLine(), out position))
        {
            Console.WriteLine("Enter a number between 0 and 100: ");
        }

        int guess;

        // User 2 guesses the number until they get the correct answer
        do
        {
            string instruction = "User 2, guess the number: ";

            guess = AskForNumberInRange(instruction, 0, 100);

            string feedback;
            feedback = guess switch
            {
                _ when guess > position => $"{guess} is too high",
                _ when guess < position => $"{guess} is too low",
                _ => ""
            };

            if (feedback != "")
                Console.WriteLine(feedback);

        } while (guess != position);

        Console.WriteLine("You guessed the number!");

    }

    private int AskForNumberInRange(string text, int min, int max)
    {

        int guess;
        do
        {

            Console.Write(text);
            int.TryParse(Console.ReadLine(), out guess);

        } while (guess > max || guess < min || guess == 0);


        return guess;

    }

}
