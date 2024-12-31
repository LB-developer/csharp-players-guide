namespace Challenges.TheFountainOfObjects;

internal class Player
{
    internal int _RowLocation { get; private set; }
    internal int _ColLocation { get; private set; }
    internal bool _FountainEnabled { get; set; }

    public Player(int y, int x)
    {
        _RowLocation = y;
        _ColLocation = x;
    }

    internal string GetPlayerAction()
    {
        Console.Write("What do you want to do? ");
        string? option;
        do
        {
            option = Console.ReadLine();
        } while (option == null);

        return option;
    }



    internal bool MovePlayer(int x, int y, string direction, int boundary)
    {
        // move x
        // TODO: use the boundary
        if (this._ColLocation + x > boundary || this._ColLocation + x < 0)
        {
            Console.WriteLine($"You are at the edge and cannot move {direction}, choose another move");
            return false;
        }
        else
        {
            this._ColLocation += x;
        }

        // move y
        if (this._RowLocation + y > boundary || this._RowLocation + y < 0)
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

    internal void PrintValidActions(int fountainRow, int fountainCol)
    {
        Console.WriteLine("Valid actions ---");
        Console.WriteLine("move north");
        Console.WriteLine("move south");
        Console.WriteLine("move east");
        Console.WriteLine("move west");
        if (this._RowLocation == fountainRow && this._ColLocation == fountainCol)
            Console.WriteLine("enable fountain");
    }


}
