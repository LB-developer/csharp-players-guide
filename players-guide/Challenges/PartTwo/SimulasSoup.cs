namespace Challenges.PartTwo;

public class SimulasSoup
{
    public void Solution()
    {

        (Type Type, MainIngredient MainIngredient, Seasoning Seasoning) food;

        Console.WriteLine("What type would you like?");
        foreach (var option in Enum.GetValues<Type>())
        {
            Console.WriteLine($"> {option}");
        }

        var typeSelection = Console.ReadLine() switch
        {
            "1" => Type.Soup,
            "2" => Type.Stew,
            _ => Type.Gumbo,
        };

        food.Type = typeSelection;

        Console.WriteLine("What main ingredient would you like?");
        foreach (var option in Enum.GetValues<MainIngredient>())
        {
            Console.WriteLine($"> {option}");
        }

        var ingredientSelection = Console.ReadLine() switch
        {
            "1" => MainIngredient.Carrots,
            "2" => MainIngredient.Chicken,
            "3" => MainIngredient.Potatoes,
            _ => MainIngredient.Mushrooms,
        };

        food.MainIngredient = ingredientSelection;

        Console.WriteLine("What type would you like?");
        foreach (var option in Enum.GetValues<Seasoning>())
        {
            Console.WriteLine($"> {option}");
        }

        var SeasoningSelection = Console.ReadLine() switch
        {
            "1" => Seasoning.Spicy,
            "2" => Seasoning.Salty,
            _ => Seasoning.Sweet,
        };

        food.Seasoning = SeasoningSelection;

        Console.WriteLine($"{food.Seasoning} {food.MainIngredient} {food.Type} ");

    }

    enum Type
    {
        Soup,
        Stew,
        Gumbo
    }
    enum MainIngredient
    {
        Carrots,
        Chicken,
        Potatoes,
        Mushrooms
    }
    enum Seasoning
    {
        Spicy,
        Salty,
        Sweet
    }

}
