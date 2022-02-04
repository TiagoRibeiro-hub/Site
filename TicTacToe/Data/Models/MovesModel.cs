﻿namespace TicTacToe.Data;
#nullable disable
public class MovesModel
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Move { get; set; }
    public int MoveNumber { get; set; }
    public DateTime DateTimeMove { get; set; } = DateTime.Now;
    public GameModel Game { get; set; }
    public int GameId { get; set; }
    
}
