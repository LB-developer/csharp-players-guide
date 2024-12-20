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
            Console.WriteLine($"Current pack weight: {CurrentWeight}");
            Console.WriteLine($"Item weight: {item._weight}");
            Console.WriteLine($"Pack Limit: {WeightLimit}");
            return false;
        }

        if (CurrentVolume + item._volume > VolumeLimit)
        {
            Console.WriteLine("Adding the item would exceed the volume of the pack.");
            Console.WriteLine($"Current pack volume: {CurrentVolume}");
            Console.WriteLine($"Item volume: {item._volume}");
            Console.WriteLine($"Pack limit: {VolumeLimit}");
            return false;
        }


        Items.Add(item);
        return true;
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

}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4)
    {
    }

}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5)
    {
    }

}

public class Water : InventoryItem
{
    public Water() : base(2, 3)
    {
    }

}

public class Food : InventoryItem
{
    public Food() : base(1, 0.5)
    {
    }

}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3)
    {
    }

}
