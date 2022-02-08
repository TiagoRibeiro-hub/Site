using TicTacToe.Data;

namespace TicTacToe.DbActionService;
public interface IHumanService
{
    Task SetScoresTableFinishedGame(Winner winner);
}

