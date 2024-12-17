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
