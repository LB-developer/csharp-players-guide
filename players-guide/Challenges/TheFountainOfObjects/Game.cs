namespace Challenges.TheFountainOfObjects;

public class Game
{
    private GameRoom[,] Rooms;
    private Player Player;
    private bool GameFinished = false;

    public Game()
    {

        int difficulty = GetDifficultyFromUser();

        this.Rooms = new GameRoom[difficulty, difficulty];

        (int, int) fountainLocation = this.InitializeBoard(difficulty);

        this.Player = new Player(0, 0, fountainLocation);

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

    private (int, int) InitializeBoard(int difficulty)
    {
        for (int i = 0; i < difficulty; i++)
        {
            for (int j = 0; j < difficulty; j++)
            {
                this.Rooms[i, j] = GameRoom.Normal;
            }
        }

        var random = new Random();

        int min = difficulty / 2;
        int max = difficulty;

        int row;
        int col;

        row = random.Next(min, max);
        col = random.Next(min, max);

        this.Rooms[row, col] = GameRoom.Fountain;
        return (row, col);
    }

    private void StartGame()
    {

        while (!GameFinished)
        {
            this.StartNewRound();
            Player.GetPlayerAction();
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
                    this.Player._ColLocation == this.Player._FountainCol
                    && this.Player._RowLocation == this.Player._FountainRow
                )
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
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

