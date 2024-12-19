namespace Challenges.RockPaperScissors;

public class Game
{
    public int PlayerOneScore { get; private set; } = 0;
    public int PlayerTwoScore { get; private set; } = 0;

    private int PlayerTurn = 1;
    private DecisionPasser _decisionPasser = new DecisionPasser();

    public void StartPlaying()
    {
        PlayRound(PlayerTurn);
    }

    private void PlayRound(int currentPlayerTurn)
    {
        Option playerDecision = _decisionPasser.GetDecision(PlayerTurn);

        if (currentPlayerTurn == 1)
            NewRound();


        if (PlayerTurn == 1)
        {
            PlayerTurn = 2;
        }
        else
        {
            PlayerTurn = 1;
        }
        this.PlayRound(PlayerTurn);
    }

    private void NewRound()
    {
        _lastDecision = null;
    }



}
