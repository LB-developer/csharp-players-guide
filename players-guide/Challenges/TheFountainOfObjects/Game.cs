namespace Challenges.TheFountainOfObjects;

public class Game
{
    private GameRoom[,] Rooms;
    private Player Player;
    private bool GameFinished = false;
    private int _FountainRow { get; set; }
    private int _FountainCol { get; set; }
    private int _Difficulty { get; set; }

    public Game()
    {

        _Difficulty = GetDifficultyFromUser();

        this.Rooms = new GameRoom[_Difficulty, _Difficulty];

        (_FountainRow, _FountainCol) = this.InitializeBoard();

        this.Player = new Player(0, 0);

        this.StartGame();
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

    private (int, int) InitializeBoard()
    {
        for (int i = 0; i < _Difficulty; i++)
        {
            for (int j = 0; j < _Difficulty; j++)
            {
                this.Rooms[i, j] = GameRoom.Normal;
            }
        }

        var random = new Random();

        // Fountains spawn at least halfway to ensure players can't spawn too close for balanced gameplay.
        int min = _Difficulty / 2;
        int max = _Difficulty;

        int row;
        int col;

        row = random.Next(min, max);
        col = random.Next(min, max);

        this.Rooms[row, col] = GameRoom.Fountain;
        Console.WriteLine($"fountain r:{row}, c:{col}");
        return (row, col);
    }

    private void StartGame()
    {

        while (!GameFinished)
        {
            this.StartNewRound();

            bool validInstruction = false;
            string option;
            do
            {
                option = Player.GetPlayerAction();
                validInstruction = this.ValidatePlayerAction(option!);

            } while (!validInstruction);

            if (this.Player._ColLocation == 0 && this.Player._RowLocation == 0 && this.Player._FountainEnabled)
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
        Console.WriteLine($"You are the room at (Row={this.Player._RowLocation}, Column={this.Player._ColLocation})");

        if (
                this.Player._RowLocation == 0
                && this.Player._ColLocation == 0
            )
            Console.WriteLine("You see light coming from the cavern entrance.");
        else if (
                    this.Player._ColLocation == this._FountainCol
                    && this.Player._RowLocation == this._FountainRow
                )
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
    }

    private bool ValidatePlayerAction(string option)
    {
        switch (option)
        {
            case "move west":
                return Player.MovePlayer(-1, 0, "west", _Difficulty);
            case "move east":
                return Player.MovePlayer(1, 0, "east", _Difficulty);
            case "move north":
                return Player.MovePlayer(0, 1, "north", _Difficulty);
            case "move south":
                return Player.MovePlayer(0, -1, "south", _Difficulty);
            case "enable fountain":
                if (this.Player._RowLocation == this._FountainRow
                    && this.Player._ColLocation == this._FountainCol)
                {
                    this.Player._FountainEnabled = true;
                    Console.WriteLine("You have activated the Fountain of Objects!");
                    return true;
                }
                else
                {
                    Console.WriteLine("nothing happens.");
                    return false;
                }
            default:
                this.Player.PrintValidActions(this._FountainRow, this._FountainCol);
                return false;
        }
    }

    enum GameRoom
    {
        Normal,
        Fountain
    }

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

}

