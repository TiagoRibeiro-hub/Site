namespace Games.Infrastructure;
public class TicTacToeWriteRepository : ITicTacToeWriteRepository, ITotalGamesRepository
{
    private readonly IUnitOfWorkTicTacToe<GameEntity> _unitOfWorkGame;
    private readonly IUnitOfWorkTicTacToe<ScoresTableEntity> _unitOfWorkScoresTable;
    private readonly IUnitOfWorkTicTacToe<TotalGamesEasyEntity> _totalGamesEasy;
    private readonly IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> _totalGamesIntermediate;
    private readonly IUnitOfWorkTicTacToe<TotalGamesHardEntity> _totalGamesHard;
    private readonly IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> _totalGamesVsHuman;

    public TicTacToeWriteRepository(
        IUnitOfWorkTicTacToe<GameEntity> unitOfWorkGameEntity, IUnitOfWorkTicTacToe<ScoresTableEntity> unitOfWorkScoresTableEntity, 
        IUnitOfWorkTicTacToe<TotalGamesEasyEntity> totalGamesEasy, IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> totalGamesIntermediate, 
        IUnitOfWorkTicTacToe<TotalGamesHardEntity> totalGamesHard, IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> totalGamesVsHuman)
    {
        _unitOfWorkGame = unitOfWorkGameEntity;
        _unitOfWorkScoresTable = unitOfWorkScoresTableEntity;
        _totalGamesEasy = totalGamesEasy;
        _totalGamesIntermediate = totalGamesIntermediate;
        _totalGamesHard = totalGamesHard;
        _totalGamesVsHuman = totalGamesVsHuman;
    }


    // Game
    #region Game
    public async Task<int> InsertAndGetIdGameAsync(GameEntity game)
    {
        return await _unitOfWorkGame.TicTacToeWrite.InsertAndGetIdAsync(game);
    }
    #endregion

    // ScoresTable
    #region ScoresTable
    public async Task InsertScoresTableAsync(ScoresTableEntity scoresTableEntity)
    {
        await _unitOfWorkScoresTable.TicTacToeWrite.InsertAsync(scoresTableEntity);
        await _unitOfWorkScoresTable.Complete();
    }
    #endregion

    // Total Games
    #region TotalGames
    public async Task UpdateScoreTableTotalGamesAsync(TotalGamesUpdate game)
    {
        if (game.VsComputer.IsComputer)
        {
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
            {
                await UpdateTotalGamesEasyAsync(game);
            }
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
            {
                await UpdateTotalGamesIntermediateAsync(game);
            }
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
            {
                await UpdateTotalGamesHardAsync(game);
            }
        }
        else
        {
                await UpdateTotalGamesVsHumanAsync(game);
        }
    }
    public async Task UpdateTotalGamesEasyAsync(TotalGamesUpdate game)
    {
        var vsComputerEasy = await _totalGamesEasy.TicTacToeRead.FindAsync(game.ScoreTableId);
        _ = game.StartFirst == game.PlayerName ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
        vsComputerEasy.TotalGames += 1;
        await _totalGamesEasy.TicTacToeWrite.UpdateAsync(vsComputerEasy);
        await _totalGamesEasy.Complete();
    }
    public async Task UpdateTotalGamesIntermediateAsync(TotalGamesUpdate game)
    {
        var vsComputerIntermediate = await _totalGamesIntermediate.TicTacToeRead.FindAsync(game.ScoreTableId);
        _ = game.StartFirst == game.PlayerName ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
        vsComputerIntermediate.TotalGames += 1;
        await _totalGamesIntermediate.TicTacToeWrite.UpdateAsync(vsComputerIntermediate);
        await _totalGamesIntermediate.Complete();
    }
    public async Task UpdateTotalGamesHardAsync(TotalGamesUpdate game)
    {
        var vsComputerHard = await _totalGamesHard.TicTacToeRead.FindAsync(game.ScoreTableId);
        _ = game.StartFirst == game.PlayerName ? vsComputerHard.StartFirst += 1 : vsComputerHard.StartSecond += 1;
        vsComputerHard.TotalGames += 1;
        await _totalGamesHard.TicTacToeWrite.UpdateAsync(vsComputerHard);
        await _totalGamesHard.Complete();
    }
    public async Task UpdateTotalGamesVsHumanAsync(TotalGamesUpdate game)
    {
        var vsHumanModel = await _totalGamesVsHuman.TicTacToeRead.FindAsync(game.ScoreTableId);
        _ = game.StartFirst == game.PlayerName ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
        await _totalGamesVsHuman.TicTacToeWrite.UpdateAsync(vsHumanModel);
        await _totalGamesVsHuman.Complete();
    }
    #endregion
}
