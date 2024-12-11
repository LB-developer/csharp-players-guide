namespace Challenges.PartOne;

public class ThingNamer3000
{
    public void Solution()
    {
        // Question dialogue
        Console.WriteLine("What kind of thing are we talking about?");
        Console.WriteLine("How would you describe it? Big? Azure? Tattered?");

        // Answer storage
        string title = "Thing Namer";
        string version = "3000";

        // Answer dialogue
        Console.WriteLine($"The {title} {version}");
    }

    private void ToFix()
    {
        // Console.WriteLine("What kind of thing are we talking about?");
        // string a = Console.ReadLine();
        // Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
        // string b = Console.ReadLine();
        // string c = "of Doom";
        // string d = "3000";
        // Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");
    }

}
