using Games.Data.Api;
using Games.Data.Data;
using Games.Data.Enums;
using Games.Data.Extensions;

namespace Games.Infrastructure;
public class TotalGamesTicTacToeRepository : ITotalGamesTicTacToeRepository
{
    private readonly IUnitOfWorkTicTacToe<TotalGamesEasyEntity> _totalGamesEasy;
    private readonly IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> _totalGamesIntermediate;
    private readonly IUnitOfWorkTicTacToe<TotalGamesHardEntity> _totalGamesHard;
    private readonly IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> _totalGamesVsHuman;

    public TotalGamesTicTacToeRepository(
        IUnitOfWorkTicTacToe<TotalGamesEasyEntity> totalGamesEasy, IUnitOfWorkTicTacToe<TotalGamesIntermediateEntity> totalGamesIntermediate, 
        IUnitOfWorkTicTacToe<TotalGamesHardEntity> totalGamesHard, IUnitOfWorkTicTacToe<TotalGamesVsHumanEntity> totalGamesVsHuman)
    {
        _totalGamesEasy = totalGamesEasy;
        _totalGamesIntermediate = totalGamesIntermediate;
        _totalGamesHard = totalGamesHard;
        _totalGamesVsHuman = totalGamesVsHuman;
    }

    public async Task UpdateTotalGamesAsync(InitializeGameRequest game, int scoreTableId, string playerName)
    {
        if (game.VsComputer.IsComputer)
        {
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
            {
                var vsComputerEasy = await _totalGamesEasy.TicTacToeRead.FindAsync(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
                vsComputerEasy.TotalGames += 1;
                await _totalGamesEasy.TicTacToeWrite.UpdateAsync(vsComputerEasy);
            }
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
            {
                var vsComputerIntermediate = await _totalGamesIntermediate.TicTacToeRead.FindAsync(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
                vsComputerIntermediate.TotalGames += 1;
                await _totalGamesIntermediate.TicTacToeWrite.UpdateAsync(vsComputerIntermediate);
            }
            if (Difficulty.Easy.GetDifficulty(game.VsComputer.Difficulty))
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
