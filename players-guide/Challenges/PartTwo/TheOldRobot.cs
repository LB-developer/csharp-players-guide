namespace Challenges.PartTwo;

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        // Get user input and set to command
        Commands[0] = new OnCommand();

        Console.WriteLine("Select 3 Commands from the list");
        foreach (var option in Enum.GetValues<Options>())
        {
            Console.WriteLine($" > {option}");
        }


        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter Option {i + 1}: ");
            var option = Console.ReadLine();

            Commands[i] = option switch
            {
                "on" => new OnCommand(),
                "off" => new OffCommand(),
                "north" => new NorthCommand(),
                "south" => new SouthCommand(),
                "east" => new EastCommand(),
                "west" => new WestCommand(),
                _ => null
            };
        }

        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }


    enum Options
    {
        on,
        off,
        north,
        south,
        east,
        west
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}


public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        Console.WriteLine("ON");
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        Console.WriteLine("OFF");
        robot.IsPowered = false;
    }
}


public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y++;
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y--;
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X++;
    }
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X--;
    }
}


