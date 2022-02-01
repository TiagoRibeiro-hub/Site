namespace TicTacToe.Data;
#nullable disable
public class GameModel
{
    public int Id { get; set; }
    public Guid IdGame { get; set; }
    public string Player1_Name { get; set; }
    public string Player2_Name { get; set; }
    public ICollection<MovesModel> Moves { get; set; } = new List<MovesModel>();
}

