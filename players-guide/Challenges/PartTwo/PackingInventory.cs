namespace Challenges.PartTwo;

public class Pack
{

    public readonly double WeightLimit = 7.00;
    public readonly double VolumeLimit = 4.00;

    public double CurrentWeight { get; private set; }
    public double CurrentVolume { get; private set; }

    List<InventoryItem> Items { get; set; } = new List<InventoryItem>();

    public bool Add(InventoryItem item)
    {
        if (CurrentWeight + item._weight > WeightLimit)
        {
            Console.WriteLine("Adding the item would exceed the weight capacity of the pack.");
            Console.WriteLine($"Pack Limit: {WeightLimit}");
            Console.WriteLine($"Current pack weight: {CurrentWeight}");
            Console.WriteLine($"Item weight: {item._weight}");
            return false;
        }

        if (CurrentVolume + item._volume > VolumeLimit)
        {
            Console.WriteLine("Adding the item would exceed the volume of the pack.");
            Console.WriteLine($"Pack limit: {VolumeLimit}");
            Console.WriteLine($"Current pack volume: {CurrentVolume}");
            Console.WriteLine($"Item volume: {item._volume}");
            return false;
        }


        CurrentWeight += item._weight;
        CurrentVolume += item._volume;
        Items.Add(item);
        return true;
    }

    public override string ToString()
    {
        string packContents = "Pack contains: ";
        foreach (var item in Items)
        {
            packContents += item.ToString() + " ";
        }

        return packContents;
    }

}

public class InventoryItem
{
    public double _weight { get; init; }
    public double _volume { get; init; }

    public InventoryItem(double weight, double volume)
    {
        _weight = weight;
        _volume = volume;
    }


}


public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05)
    {
    }

    public override string ToString()
    {

        return "Arrow";

    }
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4)
    {
    }
    public override string ToString()
    {

        return "Bow";

    }

}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5)
    {
    }

    public override string ToString()
    {

        return "Rope";

    }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3)
    {
    }

    public override string ToString()
    {

        return "Water";

    }
}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5)
    {
    }
    public override string ToString()
    {

        return "Food";

    }

}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3)
    {
    }
    public override string ToString()
    {

        return "Sword";

    }

}
