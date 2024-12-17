namespace Challenges.PartTwo;

public class Door
{

    State _state { get; }
    Status _status { get; }
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
