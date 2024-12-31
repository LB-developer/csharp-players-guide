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
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
    public void Run()
    {
        // Get user input and set to command
        Commands.Add(new OnCommand());

        Console.WriteLine("Select Commands from the list");
        foreach (var option in Enum.GetValues<Options>())
        {
            Console.WriteLine($" > {option}");
        }

        bool enteringCommands = true;
        do
        {
            Console.Write($"Enter next option: ");
            var option = Console.ReadLine();

            if (option == "stop")
            {
                enteringCommands = false;
                continue;
            }
            else
            {
                Commands.Add(option switch
                {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east" => new EastCommand(),
                    "west" => new WestCommand(),
                    _ => null
                });
            }
        } while (enteringCommands);

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


