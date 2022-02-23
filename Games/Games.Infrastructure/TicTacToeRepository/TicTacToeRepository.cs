using Games.Data.Api;
using Games.Data.Data;
using Games.Data.Game;
using System.Linq.Expressions;

namespace Games.Infrastructure;
public class TicTacToeRepository : ITicTacToeRepository
{
    private readonly IUnitOfWorkTicTacToe<GameEntity> _unitOfWorkGameEntity;
    private readonly IUnitOfWorkTicTacToe<ScoresTableEntity> _unitOfWorkScoresTableEntity;
    private readonly ITotalGamesTicTacToeRepository _totalGamesTicTacToeRepository;

    public TicTacToeRepository(
        IUnitOfWorkTicTacToe<GameEntity> unitOfWorkGameEntity, IUnitOfWorkTicTacToe<ScoresTableEntity> unitOfWorkScoresTableEntity, 
        ITotalGamesTicTacToeRepository totalGamesTicTacToeRepository)
    {
        _unitOfWorkGameEntity = unitOfWorkGameEntity;
        _unitOfWorkScoresTableEntity = unitOfWorkScoresTableEntity;
        _totalGamesTicTacToeRepository = totalGamesTicTacToeRepository;
    }

    // Game
    public async Task<int> InsertAndGetIdGameAsync(GameEntity game)
    {
        return await _unitOfWorkGameEntity.TicTacToeWrite.InsertAndGetIdAsync(game);
    }

    // ScoresTable
    public async Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity)
    {
        await _unitOfWorkScoresTableEntity.TicTacToeWrite.InsertAsync(scoresTableEntity);
        await _unitOfWorkScoresTableEntity.Complete();
    }

    // Total Games
    public async Task UpdateScoreTableTotalGamesAsync(TotalGamesUpdate game)
    {
        Expression<Func<ScoresTableEntity, int>> selector = x => x.Id;
        //await UpdateTotalGames(game, selector, game.PlayerName_1);
        //if (game.VsComputer.IsComputer == false)
        //{
        //    await UpdateTotalGames(game, selector, game.VsHuman.PlayerName_2);
        //}     
    }
    private async Task UpdateTotalGames(InitializeGameRequest game, Expression<Func<ScoresTableEntity, int>> selector, string playerName)
    {
        Expression<Func<ScoresTableEntity, bool>> predicate = x => x.PlayerName == playerName;
        int scoreTableId = await _unitOfWorkScoresTableEntity.TicTacToeRead.GetFirstOrDefaultAsync(predicate, selector);
        await _totalGamesTicTacToeRepository.UpdateTotalGamesAsync(game, scoreTableId, playerName);
    }
}
