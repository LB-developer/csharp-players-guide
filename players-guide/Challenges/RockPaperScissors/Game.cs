namespace Challenges.RockPaperScissors;

public class Game
{
    public int PlayerOneScore { get; private set; } = 0;
    public int PlayerTwoScore { get; private set; } = 0;
    private int PlayerTurn = 1;
    private DecisionPasser _decisionPasser = new DecisionPasser();

    public void StartPlaying(int currentPlayerTurn)
    {

        Option playerDecision = _decisionPasser.GetDecision(PlayerTurn);



        PlayerTurn++;
        this.StartPlaying(PlayerTurn);
    }




}
