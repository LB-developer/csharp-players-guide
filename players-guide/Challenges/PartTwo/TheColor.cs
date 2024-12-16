namespace Challenges.PartTwo;

public class TheColor
{
    public int _red { get; set; }
    public int _blue { get; set; }
    public int _green { get; set; }

    public TheColor(int red, int blue, int green)
    {
        _red = red;
        _blue = blue;
        _green = green;
    }

    public static TheColor White => new TheColor(255, 255, 255);
    public static TheColor Black => new TheColor(0, 0, 0);
    public static TheColor Red => new TheColor(255, 0, 0);
    public static TheColor Orange => new TheColor(255, 165, 0);
    public static TheColor Yellow => new TheColor(255, 255, 0);
    public static TheColor Green => new TheColor(0, 128, 0);
    public static TheColor Blue => new TheColor(0, 0, 255);
    public static TheColor Purple => new TheColor(128, 0, 128);


}
