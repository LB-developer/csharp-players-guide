namespace Challenges.PartTwo;

public class ColoredItem<T>
{
    public ConsoleColor Color;
    public T Weapon;

    public ColoredItem(T weapon, ConsoleColor color)
    {
        Weapon = weapon;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = this.Color;
        Console.WriteLine(this.ToString());
    }

}
