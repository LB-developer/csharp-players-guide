namespace Challenges.TheFountainOfObjects;

public class Game
{
    private Player _Player;
    private bool GameFinished = false;
    private int _Difficulty { get; set; }
    private Rooms _Rooms { get; }

    public Game()
    {
        _Difficulty = GetDifficultyFromUser();
        _Rooms = new Rooms(_Difficulty);
        _Player = new Player(0, 0);
    }

    private int GetDifficultyFromUser()
    {
        int selection;
        do
        {
            int i = 1;
            Console.WriteLine("Select game difficulty (1-3): ");
            foreach (var difficultyOption in Enum.GetValues<Difficulty>())
            {
                Console.WriteLine(i + ". " + difficultyOption);
                i++;
            }
        }
        while (!int.TryParse(Console.ReadLine(), out selection) && selection < 1 && selection > 3);

        return 2 + 2 * selection;
    }


    public void StartGame()
    {

        while (!GameFinished)
        {
            this.StartNewRound();

            bool validInstruction = false;
            string option;
            do
            {
                option = _Player.GetPlayerAction();
                validInstruction = this.ValidatePlayerAction(option!);

            } while (!validInstruction);

            if (this._Player._ColLocation == 0 && this._Player._RowLocation == 0 && this._Player._FountainEnabled)
            {
                this.GameFinished = true;
            }

        }


        Console.WriteLine("The Fountain of Objects has been reactivated, and, you have escaped with your life!");
        Console.WriteLine("You win!");
    }

    private void StartNewRound()
    {
        Console.WriteLine($"---------------------------");
        Console.WriteLine($"You are the room at (Row={this._Player._RowLocation}, Column={this._Player._ColLocation})");

        if (
                this._Player._RowLocation == 0
                && this._Player._ColLocation == 0
            )
            Console.WriteLine("You see light coming from the cavern entrance.");
        else if (
                    this._Player._ColLocation == this._Rooms._FountainCol
                    && this._Player._RowLocation == this._Rooms._FountainRow
                )
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
    }

    private bool ValidatePlayerAction(string option)
    {
        switch (option)
        {
            case "move west":
                return _Player.MovePlayer(-1, 0, "west", _Difficulty);
            case "move east":
                return _Player.MovePlayer(1, 0, "east", _Difficulty);
            case "move north":
                return _Player.MovePlayer(0, 1, "north", _Difficulty);
            case "move south":
                return _Player.MovePlayer(0, -1, "south", _Difficulty);
            case "enable fountain":
                if (this._Player._RowLocation == this._Rooms._FountainRow
                    && this._Player._ColLocation == this._Rooms._FountainCol)
                {
                    this._Player._FountainEnabled = true;
                    Console.WriteLine("You have activated the Fountain of Objects!");
                    return true;
                }
                else
                {
                    Console.WriteLine("nothing happens.");
                    return false;
                }
            default:
                this._Player.PrintValidActions(this._Rooms._FountainRow, this._Rooms._FountainCol);
                return false;
        }
    }

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
