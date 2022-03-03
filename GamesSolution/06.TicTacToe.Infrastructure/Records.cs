namespace _06.TicTacToe.Infrastructure;

public record InitializeGameRequestRecord
    (
        int TicTacToeNumberColumns, string PlayerName_1, string PlayerName_2, string StartFirst, 
        bool IsComputer, string Difficulty
    );

public record PlayTicTacToeRecord
    (
        int TicTacToeNumberColumns,
        int IdGame, bool IsComputer, string Difficulty,
        int MoveNumber, string MoveTo,
        Dictionary<string, string> PossibleMoves
    );

