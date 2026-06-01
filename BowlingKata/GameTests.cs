namespace Bowling;

public class GameTests
{
    [Fact]
    public void AllGutters_ScoresZero()
    {
        var game = new Game();
        for (var i = 0; i < 20; i++)
        {
            game.Roll(0);
        }
        Assert.Equal(0, game.Score());
    }
    [Fact]
    public void AllOnes_ScoresTwenty()
    {
        var game = new Game();
        for (var i = 0; i < 20; i++)
        {
            game.Roll(1);
        }
        Assert.Equal(20, game.Score());
    }
    [Fact]
    public void Spares_AddBonusEqualToNextRoll()
    {
        var game = new Game();
        game.Roll(5);
        game.Roll(5);
        game.Roll(3);
        for (var i = 0; i < 17; i++)
        {
            game.Roll(0);
        }
        Assert.Equal(16, game.Score());
    }
    [Fact]
    public void Strikes_AddBonusEqualToNextTwoRolls()
    {
        var game = new Game();
        game.Roll(10);
        game.Roll(5);
        game.Roll(3);
        for (var i = 0; i < 17; i++)
        {
            game.Roll(0);
        }
        Assert.Equal(26, game.Score());
    }
    [Fact]
    public void PerfectGame_ScoresThreeHundred()
    {
        var game = new Game();
        for (var i = 0; i < 12; i++)
        {
            game.Roll(10);
        }
        Assert.Equal(300, game.Score());
    }
}