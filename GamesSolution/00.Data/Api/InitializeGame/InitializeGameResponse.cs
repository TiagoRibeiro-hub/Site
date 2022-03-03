using _00.Data.Api.TicTacToe;

namespace _00.Data.Api.InitializeGame;

public class InitializeGameResponse
{
    public InitializeGameResponse()
    {

    }

    public InitializeGameResponse(int idGame, bool startGame, Dictionary<string, string> possibleMoves)
    {
        IdGame = idGame;
        StartGame = startGame;
        PossibleMoves = possibleMoves;
    }
    public InitializeGameResponse(TicTacToeInitializeGameResponse ticTacToe)
    {
        IdGame = ticTacToe.IdGame;
        StartGame = ticTacToe.StartGame;
        PossibleMoves = ticTacToe.PossibleMoves;
    }

    public int IdGame { get; set; }
    public bool StartGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}
