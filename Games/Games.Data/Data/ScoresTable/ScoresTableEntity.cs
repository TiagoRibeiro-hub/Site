﻿namespace Games.Data.Data;
#nullable disable
public class ScoresTableEntity
{
    public ScoresTableEntity(string playerName)
    {
        PlayerName = playerName;
    }

    public int Id { get; private set; }
    public string PlayerName { get; set; }
    public TotalGamesVsHumanEntity TotalGamesVsHuman { get; set; } = new();
    public TotalGamesVsComputerEntity TotalGamesVsComputer { get; set; } = new();

}
