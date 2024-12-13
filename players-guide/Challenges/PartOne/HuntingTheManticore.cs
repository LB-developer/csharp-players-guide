namespace Challenges.PartOne;

public class TheManticore
{
    public void Solution()
    {
        int cityHealth = 15;
        int manticoreHealth = 10;
        int manticoreLocation = GetManticoreLocation();
        int round = 0;

        Console.WriteLine("Player 2, it is your turn");
        Console.WriteLine("--------------------------------------------------");
        do
        {
            round++;

            int playerLocationGuess;
            int expectedCannonDamage = GetCannonDamage(round);

            Console.WriteLine($"STATUS:  Round {round}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");
            Console.WriteLine($"The cannon is expected to do {expectedCannonDamage} damage this round.");
            playerLocationGuess = GetCannonShotLocation();
            Console.WriteLine(GetShotDistanceFeedback(manticoreLocation, playerLocationGuess));
            Console.WriteLine("--------------------------------------------------");

            if (playerLocationGuess == manticoreLocation)
                manticoreHealth -= expectedCannonDamage;
            cityHealth--;

        } while (cityHealth > 0 && manticoreHealth > 0);

        if (cityHealth == 0)
            Console.WriteLine("The Manticore destroyed the city of Consolas.");
        else
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");

    }

    private int GetManticoreLocation()
    {
        int guess;
        do
        {
            Console.Write("Enter Manticore location (1 - 100): ");
            int.TryParse(Console.ReadLine(), out guess);

        } while (guess == 0 || guess < 0 || guess > 100);

        return guess;
    }

    private int GetCannonShotLocation()
    {
        int guess;
        do
        {
            Console.Write("Enter desired cannon range (1 - 100): ");
            int.TryParse(Console.ReadLine(), out guess);

        } while (guess == 0 || guess < 0 || guess > 100);

        return guess;

    }

    private int GetCannonDamage(int currentRound)
    {
        currentRound = currentRound switch
        {
            _ when currentRound % 3 == 0 && currentRound % 5 == 0 => 10,
            _ when currentRound % 3 == 0 || currentRound % 5 == 0 => 3,
            _ => 1
        };

        return currentRound;
    }

    private string GetShotDistanceFeedback(int manticoreLocation, int cannonShotLocation)
    {

        string feedback;
        feedback = cannonShotLocation switch
        {
            _ when cannonShotLocation < manticoreLocation => "That round FELL SHORT of the target.",
            _ when cannonShotLocation > manticoreLocation => "That round OVERSHOT the target.",
            _ => "That round was a DIRECT HIT!"

        };

        return feedback;

    }
}
