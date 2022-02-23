using Games.Data.Game;
using Games.Infrastructure;

namespace Games.Core.Services;

public class TicTacToeService : ITicTacToeService
{
    private readonly ITicTacToeWriteRepository _ticTacToeRepository;
    public TicTacToeService(
        ITicTacToeWriteRepository ticTacToeRepository)
    {
        _ticTacToeRepository = ticTacToeRepository;
    }
    public async Task<int> InsertAndGetIdGameAsync(GameEntity entity)
    {
        return await _ticTacToeRepository.InsertAndGetIdGameAsync(entity);
    }

    public async Task UpdateScoreTableTotalGamesAsync(InitializeGameRequest initializeGame)
    {
        await ScoreTableUpdate(initializeGame, initializeGame.PlayerName_1);
        if (initializeGame.VsComputer.IsComputer == false)
        {
            await ScoreTableUpdate(initializeGame, initializeGame.VsHuman.PlayerName_2);
        }
    }
    private async Task ScoreTableUpdate(InitializeGameRequest initializeGame, string playerName)
    {
        Expression<Func<ScoresTableEntity, int>> selector = x => x.Id;
        Expression<Func<ScoresTableEntity, bool>> predicate = x => x.PlayerName == playerName;
        int scoreTableId = 1;
        await _ticTacToeRepository.UpdateScoreTableTotalGamesAsync(initializeGame.SetTotalGamesUpdate(playerName, scoreTableId));
    }

    public Dictionary<string, string> SetInitialPossibleMovesTicTacToe(int TicTacToeNumberColumns)
    {
        int max = TicTacToeNumberColumns * TicTacToeNumberColumns + 1;
        Dictionary<string, string> result = new();
        for (int i = 1; i < max; i++)
        {
            result.Add(i.ToString(), i.ToString());
        }
        return result;
    }

}