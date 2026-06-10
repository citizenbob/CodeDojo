namespace BowlingTDD;

public class BowlingTests
{
    [Fact]
    public void BowlAllGutters_ScoreZero()
    {
        var game = new Game();
        BowlPins(game, 20, 0);
        Assert.Equal(0, game.Score());
    }
    
    [Fact]
    public void BowlAllOnes_ScoreTwenty()
    {
        var game = new Game();
        BowlPins(game, 20, 1);
        Assert.Equal(20, game.Score());
    }

    [Fact]
    public void BowlSpare_PickupBonus_BowlGutters_ScoreTwentySix()
    {
        var game = new Game();
        BowlPins(game, 1, 9);
        BowlPins(game, 1, 1);
        BowlPins(game, 1, 8);
        BowlPins(game, 17, 0);
        Assert.Equal(26, game.Score());
    }

    [Fact]
    public void BowlStrike_PickupBonus_BowlGutters_ScoreThirty()
    {
        var game = new Game();
        BowlPins(game, 1, 10);
        BowlPins(game, 1, 6);
        BowlPins(game, 1, 2);
        BowlPins(game, 17, 0);
        Assert.Equal(26, game.Score());
    }

    [Fact]
    public void BowlPerfectGame_Score300()
    {
        var game = new Game();
        BowlPins(game, 12, 10);
        Assert.Equal(300, game.Score());
    }

    private void BowlPins(Game game, int rolls, int pins)
    {
        for (int i = 0; i < rolls; i++) 
            game.Bowl(pins);
    }
}