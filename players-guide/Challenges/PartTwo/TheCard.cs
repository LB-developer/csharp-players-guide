namespace Challenges.PartTwo;

public class TheCard
{

    public CardColor _color { get; init; }
    public CardRank _rank { get; init; }

    public TheCard(
                    CardColor color,
                    CardRank rank)
    {
        _color = color;
        _rank = rank;
    }

    public static List<TheCard> CreateDeck()
    {
        List<TheCard> cards = new List<TheCard>();

        foreach (var color in Enum.GetValues<CardColor>())
        {

            foreach (var rank in Enum.GetValues<CardRank>())
            {

                cards.Add(new TheCard(color, rank));

            }

        }

        return cards;
    }

    public enum CardColor
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

}
