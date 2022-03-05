using _01.Play.TicTacToe.Infrastructure;
using _02.Play.TicTacToe.Core.Repository;
using _02.Play.TicTacToe.Core.WinnerOptions;
using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Data.Enums;
using Data.Infrastructure.Data.Extensions;
using Data.Infrastructure.Infrastructure.Api.PlayGame;
using System.Linq.Expressions;

namespace _02.Play.TicTacToe.Core.Services;
public interface ITicTacToeService
{
    Task<List<string>> PlayMove(PlayTicTacToeRecord playTicTacToe);
    Task<PlayTicTacToeResponse> GetWinner(PlayTicTacToeRecord playTicTacToe, List<string> playerMoves);
}

public class TicTacToeImplementation : ITicTacToeService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;
    private readonly WinnerCheck _winnerCheck;
    public TicTacToeImplementation(ITicTacToeRepository ticTacToeRepository, WinnerCheck winnerCheck)
    {
        _ticTacToeRepository = ticTacToeRepository;
        _winnerCheck = winnerCheck;
    }

    public async Task<List<string>> PlayMove(PlayTicTacToeRecord playTicTacToe)
    {

        playTicTacToe.PossibleMoves.Remove(playTicTacToe.Movements.MoveTo);
        MovesEntity movesEntity = playTicTacToe.SetMovesEntity();
        await _ticTacToeRepository.GetTicTacToeMovesWrite.InsertAsync(movesEntity);

        Expression<Func<MovesEntity, bool>> predicate = x => x._GameId == playTicTacToe.IdGame && x.PlayerName == playTicTacToe.playerName;
        Expression<Func<MovesEntity, string>> selector = x => x.MoveTo;
        return await _ticTacToeRepository.GetTicTacToeMovesRead.GetToListAsync(predicate, selector);
    }
    public async Task<PlayTicTacToeResponse> GetWinner(PlayTicTacToeRecord playTicTacToe, List<string> playerMoves)
    {
        var haveWinner = _winnerCheck.HaveWinner(playerMoves, playTicTacToe.TicTacToeNumberColumns);
        PlayTicTacToeResponse playResponse = playTicTacToe.SetPlayResponse();
        if (await haveWinner)
        {
            playResponse.GameState = GameState.Finished.GameStateToStringUpper();
            playResponse.GameResult = GameResult.Winner.GameResultToStringUpper();
        }
        else
        {
            (playResponse.GameState, playResponse.GameResult) = await _winnerCheck.IsFinished(playTicTacToe.PossibleMoves.Count);
        }
        return playResponse;
    }
}