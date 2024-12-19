namespace Challenges.RockPaperScissors;

public class Game
{
    public int PlayerOneScore { get; private set; } = 0;
    public int PlayerTwoScore { get; private set; } = 0;
    public int GameDraws { get; private set; } = 0;


    private int PlayerTurn = 1;

    private DecisionPasser _decisionPasser = new DecisionPasser();
    private Option? _lastDecision;

    public void GetHistoryForPlayer(int player) => _decisionPasser.DisplayHistory(player);

    public void StartPlaying()
    {
        PlayRound(PlayerTurn);
    }

    private void PlayRound(int currentPlayerTurn)
    {
        if (currentPlayerTurn == 1)
            NewRound();

        Option playerDecision = _decisionPasser.GetDecision(PlayerTurn);

        if (_lastDecision is Option decision)
        {
            EvaluateWinner(decision, playerDecision);
        }

        _lastDecision = playerDecision;
        PlayerTurn = PlayerTurn switch
        {
            1 => 2,
            _ => 1
        };
        this.PlayRound(PlayerTurn);
    }

    private void NewRound()
    {
        _lastDecision = null;
    }

    private void EvaluateWinner(Option playerOneOption, Option playerTwoOption)
    {
        void announcePlayed() => Console.WriteLine($"Player 1 played {playerOneOption} -- Player 2 played {playerTwoOption}");


        switch (playerOneOption)
        {
            case Option.Rock:
                if (playerTwoOption == Option.Rock)
                {
                    announcePlayed();
                    GameDraws++;
                    Console.WriteLine("The match was a draw!");
                    break;
                }
                else if (playerTwoOption == Option.Paper)
                {
                    announcePlayed();
                    PlayerTwoScore++;
                    Console.WriteLine("Player Two Wins!");
                    break;
                }
                else
                {
                    announcePlayed();
                    PlayerOneScore++;
                    Console.WriteLine("Player One Wins!");
                    break;
                }
            case Option.Paper:
                if (playerTwoOption == Option.Rock)
                {
                    announcePlayed();
                    PlayerOneScore++;
                    Console.WriteLine("Player One Wins!");
                    break;
                }
                else if (playerTwoOption == Option.Scissors)
                {
                    announcePlayed();
                    PlayerTwoScore++;
                    Console.WriteLine("Player Two Wins!");
                    break;
                }
                else
                {
                    announcePlayed();
                    GameDraws++;
                    Console.WriteLine("The match was a draw!");
                    break;
                }
            case Option.Scissors:
                if (playerTwoOption == Option.Rock)
                {
                    announcePlayed();
                    PlayerTwoScore++;
                    Console.WriteLine("Player Two Wins!");
                    break;
                }
                else if (playerTwoOption == Option.Scissors)
                {
                    announcePlayed();
                    GameDraws++;
                    Console.WriteLine("The match was a draw!");
                    break;
                }
                else
                {
                    announcePlayed();
                    PlayerOneScore++;
                    Console.WriteLine("Player One Wins!");
                    break;
                }
        }
    }





}
