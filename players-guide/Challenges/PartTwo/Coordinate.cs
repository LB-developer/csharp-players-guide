namespace Challenges.PartTwo;

public struct Coordinate
{
    private readonly int _row;
    private readonly int _col;

    public Coordinate(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public void Main()
    {
        for (int i = 0; i < 8; i++)
        {
            var nextCoordinate = new Coordinate(i, i);
            Adjacent(nextCoordinate);
        }

    }

    public bool Adjacent(Coordinate coordinate)
    {
        if (
            Math.Abs(coordinate._col - this._col) <= 1
            || Math.Abs(coordinate._row - this._row) <= 1
            )
        {
            Console.WriteLine("True");
            return true;
        }

        Console.WriteLine("False");
        return false;
    }
}
