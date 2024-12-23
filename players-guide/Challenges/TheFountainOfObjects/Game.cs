namespace Challenges.TheFountainOfObjects;

public class Game
{
    private GameRoom[,] Rooms;
    private Player Player;
    private bool GameFinished = false;

    public Game()
    {
        Rooms = new GameRoom[4, 4];
        Player = new Player(0, 0);

        this.InitializeBoard();
        this.StartGame();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                this.Rooms[i, j] = GameRoom.Normal;
            }
        }

        this.Rooms[0, 2] = GameRoom.Fountain;
    }

    public void StartGame()
    {

        while (!GameFinished)
        {
            this.StartNewRound();
            Player.GetPlayerAction();
            if (this.Player.XLocation == 0 && this.Player.YLocation == 0 && this.Player.FountainEnabled)
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
        Console.WriteLine($"You are the room at (Row={Player.YLocation}, Column={Player.XLocation})");

        if (this.Player.XLocation == 0 && this.Player.YLocation == 0)
            Console.WriteLine("You see light coming from the cavern entrance.");
        else if (this.Player.XLocation == 2 && this.Player.YLocation == 0)
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
    }

    enum GameRoom
    {
        Normal,
        Fountain
    }

}

internal class Player
{
    internal int XLocation { get; private set; }
    internal int YLocation { get; private set; }
    internal bool FountainEnabled { get; private set; }

    public Player(int x, int y)
    {
        XLocation = x;
        YLocation = y;
    }

    internal void GetPlayerAction()
    {
        bool validInstruction = false;
        do
        {
            Console.Write("What do you want to do?  ");
            string? option;
            do
            {
                option = Console.ReadLine();
            } while (option == null);

            validInstruction = ValidatePlayerAction(option!);

        } while (!validInstruction);
    }

    private bool ValidatePlayerAction(string option)
    {
        switch (option)
        {
            case "move west":
                return this.MovePlayer(-1, 0, "west");
            case "move east":
                return this.MovePlayer(1, 0, "east");
            case "move north":
                return this.MovePlayer(0, 1, "north");
            case "move south":
                return this.MovePlayer(0, -1, "south");
            case "enable fountain":
                if (this.XLocation == 2 && this.YLocation == 0)
                {
                    this.FountainEnabled = true;
                    Console.WriteLine("You have activated the Fountain of Objects!");
                    return true;
                }
                else
                {
                    Console.WriteLine("nothing happens.");
                    return false;
                }
            default:
                this.PrintValidActions();
                return false;
        }
    }

    private bool MovePlayer(int x, int y, string direction)
    {
        // move x
        if (this.XLocation + x > 4 || this.XLocation + x < 0)
        {
            Console.WriteLine($"You are at the edge and cannot move {direction}, choose another move");
            return false;
        }
        else
        {
            this.XLocation += x;
        }
        // move y
        if (this.YLocation + y > 4 || this.YLocation + y < 0)
        {
            Console.WriteLine($"You are at the edge and cannot move {direction}, choose another move");
            return false;
        }
        else
        {
            this.YLocation += y;
        }

        return true;
    }

    private void PrintValidActions()
    {
        Console.WriteLine("Valid actions ---");
        Console.WriteLine("move north");
        Console.WriteLine("move south");
        Console.WriteLine("move east");
        Console.WriteLine("move west");
        if (this.XLocation == 2 && this.YLocation == 0)
            Console.WriteLine("enable fountain");
    }


}
