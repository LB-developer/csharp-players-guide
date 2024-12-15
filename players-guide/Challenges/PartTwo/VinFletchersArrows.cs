namespace Challenges.PartTwo;



public class VinFletchersArrows
{

    private Arrowhead _arrowheadType { get; init; }
    private Fletching _fletchingType { get; init; }
    private int _length { get; init; }

    public VinFletchersArrows(Arrowhead arrowheadType, Fletching fletchingType, int length)
    {
        _arrowheadType = arrowheadType;
        _fletchingType = fletchingType;
        _length = length;
    }

    public static VinFletchersArrows CreateEliteArrow()
    {
        return new VinFletchersArrows(Arrowhead.Steel, Fletching.Plastic, 95);
    }

    public static VinFletchersArrows CreateBeginnerArrow()
    {
        return new VinFletchersArrows(Arrowhead.Wood, Fletching.Goose_Feathers, 75);
    }

    public static VinFletchersArrows CreateMarksmanArrow()
    {
        return new VinFletchersArrows(Arrowhead.Steel, Fletching.Goose_Feathers, 65);
    }

    public float GetCost()
    {
        var arrowCost = this._arrowheadType switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Obsidian => 5,
            Arrowhead.Wood => 3,
            _ => 0
        };

        var fletchingCost = this._fletchingType switch
        {
            Fletching.Plastic => 10,
            Fletching.Turkey_Feathers => 5,
            Fletching.Goose_Feathers => 3,
            _ => 0
        };

        return arrowCost + fletchingCost;

    }


    public enum Arrowhead
    {
        Steel,
        Wood,
        Obsidian
    }

    public enum Fletching
    {
        Plastic,
        Turkey_Feathers,
        Goose_Feathers,
    }

}
