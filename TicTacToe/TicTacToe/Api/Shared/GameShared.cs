namespace TicTacToe;
#nullable disable
public class GameShared
{
    public HumanShared Player { get; set; }
    public ComputerShared Computer { get; set; }
    public string Shift { get; set; }
    public WinnerShared Winner { get; set; }
}
