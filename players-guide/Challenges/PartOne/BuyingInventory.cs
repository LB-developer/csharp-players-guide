namespace Challenges.PartOne;

public class BuyingInventory
{
    public void Solution()
    {

        Console.Write("What is your name?: ");
        var customerName = Console.ReadLine();
        // Prices
        var menu = new Dictionary<string, Tuple<string, int>>
        {
            { "1", new Tuple<string, int>
                    ("Rope", 10)
            },
            { "2", new Tuple<string, int>
                    ("Torches", 15)
            },
            { "3", new Tuple<string, int>
                    ("Climbing Equipment", 25)
            },
            { "4", new Tuple<string, int>
                    ("Clean Water", 1)
            },
            { "5", new Tuple<string, int>
                    ("Machete", 20)
            },
            { "6", new Tuple<string, int>
                    ("Canoe", 200)
            },
            { "7", new Tuple<string, int>
                    ("Food Supplies", 1)
        }
        };

        Console.WriteLine($"The following items are available for you {customerName}: ");
        foreach (var item in menu)
        {
            string index = item.Key;
            (string itemName, int itemCost) = item.Value;

            Console.WriteLine($"{index} - {itemName}");
        }

        Console.Write("What number do you want to see the price of: ");
        var wantedItem = Console.ReadLine() ?? "";

        if (customerName == "Logan")
        {
            Console.WriteLine($"{menu[wantedItem].Item1} costs {menu[wantedItem].Item2 / 2} gold which has a 50% discount!");
        }
        else
        {
            Console.WriteLine($"{menu[wantedItem].Item1} costs {menu[wantedItem].Item2} gold");
        }

    }
}
