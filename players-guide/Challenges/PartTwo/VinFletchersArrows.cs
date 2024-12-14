namespace Challenges.PartTwo;

public class VinFletchersArrows
{

    Arrowhead _arrowheadType;
    Fletching _fletchingType;
    int _length;

    public VinFletchersArrows(Arrowhead arrowheadType, Fletching fletchingType, int length)
    {
        _arrowheadType = arrowheadType;
        _fletchingType = fletchingType;
        _length = length;
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
