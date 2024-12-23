namespace Challenges.TheFountainOfObjects;

internal class Player
{
    internal int _RowLocation { get; private set; }
    internal int _ColLocation { get; private set; }
    internal int _FountainRow { get; private set; }
    internal int _FountainCol { get; private set; }
    internal bool _FountainEnabled { get; private set; }

    public Player(int y, int x, (int, int) fountainLocation)
    {
        _RowLocation = y;
        _ColLocation = x;
        (_FountainRow, _FountainCol) = fountainLocation;
    }

    internal void GetPlayerAction()
    {
        bool validInstruction = false;
        do
        {
            Console.Write("What do you want to do? ");
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
                if (this._RowLocation == this._FountainRow && this._ColLocation == this._FountainCol)
                {
                    this._FountainEnabled = true;
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
        // TODO: use the boundary
        if (this._ColLocation + x > 4 || this._ColLocation + x < 0)
        {
            Console.WriteLine($"You are at the edge and cannot move {direction}, choose another move");
            return false;
        }
        else
        {
            this._ColLocation += x;
        }

        // move y
        if (this._RowLocation + y > 4 || this._RowLocation + y < 0)
        {
            Console.WriteLine($"You are at the edge and cannot move {direction}, choose another move");
            return false;
        }
        else
        {
            this._RowLocation += y;
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
        if (this._RowLocation == this._FountainRow && this._ColLocation == this._FountainCol)
            Console.WriteLine("enable fountain");
    }


}
