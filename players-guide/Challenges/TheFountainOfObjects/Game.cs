namespace Challenges.TheFountainOfObjects;

public class Game
{
    private GameRoom[,] Rooms = new GameRoom[4, 4];
    private Player Player = new Player(0, 0);
    private bool GameFinished = false;

    public Game()
    {
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
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"You are the room at (Row={Player.YLocation}, Column={Player.XLocation})");

            if (Player.XLocation != 0 && Player.YLocation == 0)
                Console.WriteLine("You see light coming from the cavern entrance.");
            else if (Player.XLocation == 2 && Player.YLocation == 0)
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");

            Player.GetPlayerAction();
            if (this.Player.XLocation == 0 && this.Player.YLocation == 0 && this.Player.FountainEnabled)
            {
                this.GameFinished = true;
            }

        }

        Console.WriteLine("The Fountain of Objects has been reactivated, and, you have escaped with your life!");
        Console.WriteLine("You win!");
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
                if (!this.MovePlayer(-1, 0))
                {
                    Console.WriteLine("You are at the edge and cannot move west, choose another move");
                    return false;
                }
                else
                {
                    return true;
                }

            case "move east":
                if (!this.MovePlayer(1, 0))
                {
                    Console.WriteLine("You are at the edge and cannot move east, choose another move");
                    return false;
                }
                else
                {
                    return true;
                }

            case "move north":
                if (!this.MovePlayer(0, 1))
                {
                    Console.WriteLine("You are at the edge and cannot move north, choose another move");
                    return false;
                }
                else
                {
                    return true;
                }
            case "move south":
                if (!this.MovePlayer(0, -1))
                {
                    Console.WriteLine("You are at the edge and cannot move south, choose another move");
                    return false;
                }
                else
                {
                    return true;
                }
            case "enable fountain":
                if (this.XLocation == 2 && this.YLocation == 0)
                {
                    this.FountainEnabled = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("nothing happens.");
                }

                return true;
            default:
                this.PrintValidActions();
                return false;
        }
    }

    private bool MovePlayer(int x, int y)
    {
        // move x
        if (this.XLocation + x > 4 || this.XLocation + x < 0)
        {
            return false;
        }
        else
        {
            this.XLocation += x;
        }
        // move y
        if (this.YLocation + y > 4 || this.YLocation + y < 0)
        {
            Console.WriteLine($"current y{this.YLocation} -- to add {y}");
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
