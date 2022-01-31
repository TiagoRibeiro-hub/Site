﻿namespace TicTacToe.Data;
#nullable disable
public class GameModel
{
    public int Id { get; set; }
    public string Player1_Name { get; set; }
    public string Player2_Name { get; set; }
    public string Winner { get; set; }
    public ICollection<MovesModels> Moves { get; set; } = new List<MovesModels>();
}
