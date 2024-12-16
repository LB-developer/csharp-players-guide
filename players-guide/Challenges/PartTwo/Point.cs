namespace Challenges.PartTwo;

public class Point
{
    public int _x { get; set; }
    public int _y { get; set; }

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public static Point ZeroPoint()
    {
        return new Point(0, 0);
    }

}
