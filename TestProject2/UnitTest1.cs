namespace TestProject2;
using TextGame;
public class TextQuestTests
{ 
    /// <summary>
    /// Тест функции IsCurrentVariant при несуществующем ответе
    /// </summary>
    [Fact]
    public void NextStepIsNotCurrentVariant()
    {
        var game = new Game();
        var boo = game.IsCurrentVariant(30);

        Assert.False(boo);
    }

    /// <summary>
    /// Тест функции IsCurrentVariant при существующем ответе
    /// </summary>
    [Fact]
    public void NextStepIsCurrentVariant()
    {
        var game = new Game();
        var boo = game.IsCurrentVariant(1);

        Assert.True(boo);
    }
}