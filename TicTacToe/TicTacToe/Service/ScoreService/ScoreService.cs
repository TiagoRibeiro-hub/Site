using TicTacToe.Data;

namespace TicTacToe.Service;
public class ScoreService : IScoreService
{
    private readonly IScoreDbService _scoreDbService;

    public ScoreService(IScoreDbService scoreDbService)
    {
        _scoreDbService = scoreDbService;
    }

    public async Task SetScoresTableAsync(Human player)
    {
        try
        {
            ScoresTableModel model = new();
            model.PlayerName = player.Name;
            model.TotalGames = 1;
            model.Email = player.Email;
            model.TotalGamesVsHuman = 1;
            await _scoreDbService.InsertScoresTableAsync(model);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }

    }
    public async Task ScoresTableVsHumanAsync(string email)
    {
        try
        {
            await _scoreDbService.UpdateScoreTableAsync(email);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    public async Task ScoresTableVsComputerAsync(string email, string difficulty)
    {
        try
        {
            await _scoreDbService.UpdateScoreTableAsync(email, true, difficulty);
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}

