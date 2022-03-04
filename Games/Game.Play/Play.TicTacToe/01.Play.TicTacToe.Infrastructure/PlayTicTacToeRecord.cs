using Data.Infrastructure.Data.Game.Moves;
using Data.Infrastructure.Data.Game.Player;

namespace _01.Play.TicTacToe.Infrastructure;

public record PlayTicTacToeRecord
    (
        int TicTacToeNumberColumns,
        Guid IdGame, string playerName,
        VsComputer VsComputer,
        Movement Movements,
        Dictionary<string, string> PossibleMoves
    );
