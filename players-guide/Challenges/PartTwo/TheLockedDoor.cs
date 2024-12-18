namespace Challenges.PartTwo;

public class Door
{

    public State _state { get; private set; }
    public Status _status { get; private set; }
    private int _passcode;


    public Door(int passcode)
    {
        _state = State.Locked;
        _status = Status.Closed;
        _passcode = passcode;
    }

    public string UnlockDoor()
    {
        if (this._status == Status.Open)
        {
            return "The door is already unlocked and open";
        }
        string response;

        response = this._state switch
        {
            State.Unlocked => "The door is already unlocked.",
            State.Locked =>
                (GuessPasscode())
                ? "You have unlocked the door!"
                : "Incorrect passcode",
            _ => throw new Exception()
        };

        return response;
    }

    private bool GuessPasscode()
    {
        int guess;

        Console.Write("Enter the passcode: ");
        int.TryParse(Console.ReadLine(), out guess);

        return guess switch
        {
            _ when guess == this._passcode => true,
            _ => false
        };
    }

    private bool ChangePasscode()
    {
        if (this.GuessPasscode())
        {
            int guess;

            Console.Write("Enter new password: ");
            if (!int.TryParse(Console.ReadLine(), out guess))
            {
                throw new FormatException("User input was not a valid int");
            }

            this._passcode = guess;
            return true;
        }

        return false;
    }

    public bool OpenDoor()
    {

        if (this._state == State.Unlocked)
        {
            switch (this._status)
            {
                case Status.Open:
                    Console.WriteLine("The door is already open...");
                    return false;
                case Status.Closed:
                    this._status = Status.Open;
                    return true;
            }
        }


        Console.WriteLine("You need to unlock the door before you open it... (GuessPasscode)");
        return false;
    }


    public enum State
    {
        Locked,
        Unlocked
    }

    public enum Status
    {
        Open,
        Closed
    }
}
