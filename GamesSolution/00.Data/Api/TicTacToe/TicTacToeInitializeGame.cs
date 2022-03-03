using _00.Data.Api.InitializeGame;
using _00.Data.Game.Player;

namespace _00.Data.Api.TicTacToe;
public class TicTacToeInitializeGame
{
    public TicTacToeInitializeGame(InitializeGameRequest initializeGameRequest)
    {
        
        TicTacToeNumberColumns = initializeGameRequest.GetGameOptions.GetGameTypeOptions.TicTacToeNumberColumns;
        PlayerName_1 = initializeGameRequest.PlayerName_1;
        PlayerName_2 = GetPlayerName_2(initializeGameRequest);
        StartFirst = initializeGameRequest.StartFirst;
        IsComputer = initializeGameRequest.VsComputer.IsComputer;
        Difficulty = initializeGameRequest.VsComputer.Difficulty;
    }

    public int TicTacToeNumberColumns { get; set; }
    public string PlayerName_1 { get; set; }
    public string PlayerName_2 { get; set; }
    public string StartFirst { get; set; }
    public bool IsComputer { get; set; }
    public string Difficulty { get; set; }

    private string GetPlayerName_2(InitializeGameRequest initializeGameRequest)
    {
        if (initializeGameRequest.VsComputer.IsComputer == false)
        {
            return initializeGameRequest.VsHuman.PlayerName_2;
        }
        else
        {
            return Computer.Name;
        }
    }
}
