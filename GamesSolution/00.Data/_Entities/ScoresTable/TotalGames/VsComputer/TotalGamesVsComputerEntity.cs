﻿namespace _00.Data._Entities;

public class TotalGamesVsComputerEntity
{
    public int Id { get; private set; }
    public TotalGamesEasyEntity TotalGamesEasy { get; set; } = new();
    public TotalGamesIntermediateEntity TotalGamesIntermediate { get; set; } = new();
    public TotalGamesHardEntity TotalGamesHard { get; set; } = new();
    public ScoresTableEntity ScoresTable { get; set; }
    public int ScoreTableId { get; set; }

}