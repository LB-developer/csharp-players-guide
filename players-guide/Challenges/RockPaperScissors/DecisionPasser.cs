namespace Challenges.RockPaperScissors;

internal class DecisionPasser()
{
    List<Option> PlayerOneDecisions = new List<Option>();
    List<Option> PlayerTwoDecisions = new List<Option>();

    internal void DisplayHistory(int player)
    {
        List<Option> history;
        history = player switch
        {
            1 => PlayerOneDecisions,
            2 => PlayerTwoDecisions,
            _ => throw new ArgumentException("Player must be 1 or 2")
        };

        for (int turn = 0; turn < history.Count; turn++)
        {
            Option decision = history[turn];
            Console.WriteLine($"Turn #{turn} | Decision: {decision}");
        }
    }

    internal Option GetDecision(int playerTurn)
    {
        int i = 1;
        int userSelection = 0;

        Console.WriteLine("Choices: ");
        foreach (var item in Enum.GetValues<Option>())
        {
            Console.WriteLine($"{i}: {item}");
            i++;
        }

        do
        {
            Console.Write($"Player {playerTurn} - Please enter your choice (1-3): ");
            int.TryParse(Console.ReadLine(), out userSelection);

        } while (userSelection != 1 && userSelection != 2 && userSelection != 3);


        switch (userSelection)
        {
            case 1:
                this.NoteDecision(Option.Rock, playerTurn);
                return Option.Rock;
            case 2:
                this.NoteDecision(Option.Paper, playerTurn);
                return Option.Paper;
            case 3:
                this.NoteDecision(Option.Scissors, playerTurn);
                return Option.Scissors;
        }

        throw new Exception();
    }

    private void NoteDecision(Option decision, int player)
    {
        switch (player)
        {
            case 1:
                PlayerOneDecisions.Add(decision);
                break;
            case 2:
                PlayerTwoDecisions.Add(decision);
                break;
            default:
                return;

        };
    }


}
