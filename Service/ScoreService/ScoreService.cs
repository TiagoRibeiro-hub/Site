using TicTacToe.Data;

namespace TicTacToe.Service;
public class ScoreService : IScoreService
{
    private readonly IScoreDbService _scoreDbService;

    public ScoreService(IScoreDbService scoreDbService)
    {
        _scoreDbService = scoreDbService;
    }

    public async Task SetScoresTableHumanAsync(Human player)
    {
        try
        {
            ScoresTableModel model = new();
            model.PlayerName = player.Name;
            model.TotalGames = 1;
            model.Email = player.Email;
            model.TotalGamesVsHuman = 1;
            if (player.StartFirst)
            {
                model.StartFirst = 1;
            }
            await _scoreDbService.InsertScoresTableAsync(model);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    public async Task ScoresTableVsHumanAsync(string email, bool startFirst)
    {
        try
        {
            await _scoreDbService.UpdateScoreTableAsync(email, startFirst);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task ScoresTableVsComputerAsync(string email, bool startFirst, string difficulty)
    {
        try
        {
            await _scoreDbService.UpdateScoreTableAsync(email, startFirst, true, difficulty);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

