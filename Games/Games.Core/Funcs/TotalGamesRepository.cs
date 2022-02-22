namespace Games.Infrastructure;
internal class TotalGamesRepository
{
    private IUnitOfWorkTicTacToe<TotalGamesEasyEntity> _totalGamesEasy;
    private IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> _totalGamesIntermediate;
    private IUnitOfWorkTicTacToe<TotalGamesHardEntity> _totalGamesHard;
    private IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> _totalGamesVsHuman;

    public TotalGamesRepository(
        IUnitOfWorkTicTacToe<TotalGamesEasyEntity> totalGamesEasy, IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> totalGamesIntermediate, 
        IUnitOfWorkTicTacToe<TotalGamesHardEntity> totalGamesHard, IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> totalGamesVsHuman)
    {
        _totalGamesEasy = totalGamesEasy;
        _totalGamesIntermediate = totalGamesIntermediate;
        _totalGamesHard = totalGamesHard;
        _totalGamesVsHuman = totalGamesVsHuman;
    }

    internal async Task UpdateScoreTableTotalGamesAsync(GameEntity game, int scoreTableId, string playerName)
    {
        if (game.IsComputer)
        {
            if (Difficulty.Easy.GetDifficulty(game.Difficulty))
            {
                var vsComputerEasy = await _totalGamesEasy.TicTacToeRead.FindAsync(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
                vsComputerEasy.TotalGames += 1;
                await _totalGamesEasy.TicTacToeWrite.UpdateAsync(vsComputerEasy);
            }
            if (Difficulty.Easy.GetDifficulty(game.Difficulty))
            {
                var vsComputerIntermediate = await _totalGamesIntermediate.TicTacToeRead.FindAsync(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
                vsComputerIntermediate.TotalGames += 1;
                await _totalGamesIntermediate.TicTacToeWrite.UpdateAsync(vsComputerIntermediate);
            }
            if (Difficulty.Easy.GetDifficulty(game.Difficulty))
            {
                var vsComputerHard = await _totalGamesHard.TicTacToeRead.FindAsync(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerHard.StartFirst += 1 : vsComputerHard.StartSecond += 1;
                vsComputerHard.TotalGames += 1;
                await _totalGamesHard.TicTacToeWrite.UpdateAsync(vsComputerHard);
            }
        }
        else
        {
            var vsHumanModel = await _totalGamesVsHuman.TicTacToeRead.FindAsync(scoreTableId);
            _ = game.StartFirst == playerName ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
            await _totalGamesVsHuman.TicTacToeWrite.UpdateAsync(vsHumanModel);
        }
    }
}
