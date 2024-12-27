namespace players_guide_tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var sol = new Challenges.PartTwo.Sword();

        var expected = 5;

        var actual = sol._weight;

        Assert.True(actual == expected);

    }
}
