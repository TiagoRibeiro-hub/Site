namespace TicTacToe.Data;
#nullable disable
public class MovesModel
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Move { get; set; } = 0;
    public int MoveNumber { get; set; }= 0;
    public DateTime DateTimeMove { get; set; } = DateTime.Now.ToUniversalTime();
    public GameModel Game { get; set; }
    public int GameId { get; set; }
    
}

