using TicTacToe.Data;

namespace TicTacToe.Services;
public static class HumanServiceFuncs
{
    internal static void SetTotalGamesVsHuman(Winner winner, TotalGamesVsHumanModel player, ScoresTableModel item)
    {
        player.Id = item.TotalGamesVsHuman.Id;
        player.StartFirst = item.TotalGamesVsHuman.StartFirst;
        player.StartSecond = item.TotalGamesVsHuman.StartSecond;
        player.TotalGames = item.TotalGamesVsHuman.TotalGames;
        player.Victories = item.TotalGamesVsHuman.Victories;
        player.Losses = item.TotalGamesVsHuman.Losses;
        player.Ties = item.TotalGamesVsHuman.Ties;
        player.ScoreTableId = item.TotalGamesVsHuman.ScoreTableId;
        if (winner.State.ToLower() == GameState.Tie.ToString().ToLower())
        {
            player.Ties += 1;
        }
        else
        {
            if (winner.WinnerName == item.PlayerName)
            {
                player.Victories += 1;
            }
            if (winner.LoserName == item.PlayerName)
            {
                player.Losses += 1;
            }
        }
    }
}

