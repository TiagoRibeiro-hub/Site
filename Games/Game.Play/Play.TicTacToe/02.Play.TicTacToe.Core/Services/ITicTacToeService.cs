using _01.Play.TicTacToe.Infrastructure;
using _02.Play.TicTacToe.Core.Repository;
using _02.Play.TicTacToe.Core.GameOptions;
using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Data.Enums;
using Data.Infrastructure.Data.Extensions;
using Data.Infrastructure.Data.Game.Player;
using Data.Infrastructure.Infrastructure.Api.PlayGame;
using System.Linq.Expressions;

namespace _02.Play.TicTacToe.Core.Services;
public interface ITicTacToeService
{
    Task<List<string>> PlayMoveHuman(PlayTicTacToeRecord playTicTacToe);
    Task<List<string>> PlayMoveComputer(PlayTicTacToeRecord playTicTacToe);
    Task<PlayTicTacToeResponse> GetWinner(PlayTicTacToeRecord playTicTacToe, List<string> playerMoves);
}

public class TicTacToeImplementation : ITicTacToeService
{
    private readonly ITicTacToeRepository _ticTacToeRepository;
    private readonly IComputerService _computerService;
    private readonly WinnerCheck _winnerCheck;
    public TicTacToeImplementation(
        ITicTacToeRepository ticTacToeRepository, 
        IComputerService computerService,
        WinnerCheck winnerCheck)
    {
        _ticTacToeRepository = ticTacToeRepository;
        _computerService = computerService;
        _winnerCheck = winnerCheck;
        
    }

    public async Task<List<string>> PlayMoveHuman(PlayTicTacToeRecord playTicTacToe)
    {
        MovesEntity movesEntity = playTicTacToe.SetMovesEntity();
        await _ticTacToeRepository.GetTicTacToeMovesWrite.InsertAsync(movesEntity);

        if(playTicTacToe.PossibleMoves.Remove(playTicTacToe.Movements.MoveTo) == false)
        {
            throw new Exception("PossibleMoves does't exist =>  PlayMoveHuman()");
        }
        Expression<Func<MovesEntity, bool>> predicate = x => x._GameId == playTicTacToe.IdGame && x.PlayerName == playTicTacToe.playerName;
        Expression<Func<MovesEntity, string>> selector = x => x.MoveTo;
        return await _ticTacToeRepository.GetTicTacToeMovesRead.GetToListAsync(predicate, selector);
    }
    public async Task<List<string>> PlayMoveComputer(PlayTicTacToeRecord playTicTacToe)
    {
        if (Difficulty.Easy.GetDifficulty(playTicTacToe.VsComputer.Difficulty))
        {
            playTicTacToe = await _computerService.SetEasyPlay(playTicTacToe);
        }
        if (Difficulty.Intermediate.GetDifficulty(playTicTacToe.VsComputer.Difficulty))
        {
            playTicTacToe = await _computerService.SetIntermediatePlay(playTicTacToe);
        }
        if (Difficulty.Hard.GetDifficulty(playTicTacToe.VsComputer.Difficulty))
        {
            playTicTacToe = await _computerService.SetHardPlay(playTicTacToe);
        }

        if (playTicTacToe.PossibleMoves.Remove(playTicTacToe.Movements.MoveTo) == false)
        {
            throw new Exception("PossibleMoves does't exist =>  PlayMoveComputer()");
        }
        Expression<Func<MovesEntity, bool>> predicate = x => x._GameId == playTicTacToe.IdGame && x.PlayerName == Computer.Name;
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