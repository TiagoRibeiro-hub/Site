namespace TicTacToe.Services;
public interface IScoresService
{
    Task TableScoreInitialize(Game game);
    Task SetScoresTableFinishedGame(Winner winner);
}

