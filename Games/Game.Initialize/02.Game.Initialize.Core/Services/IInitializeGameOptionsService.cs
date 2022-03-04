using _01.Game.Initialize.Infrastructure;
using _02.Game.Initialize.Core.GameOptions;
using _02.Game.Initialize.Core.Repository;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;

namespace _02.Game.Initialize.Core.Services;
public interface IInitializeGameOptionsService
{
    Task<InitializeGameResponse> SetTicTacToeGame(InitializeGameRecord game);
}
public class InitializeGameOptions : IInitializeGameOptionsService
{
    private readonly SetInitialPossibleMoves _setInitialPossibleMoves;
    private readonly IInitializeGameRepository _initializeGameRepository;
    public InitializeGameOptions(
        SetInitialPossibleMoves setInitialPossibleMoves, 
        IInitializeGameRepository initializeGameRepository)
    {
        _setInitialPossibleMoves = setInitialPossibleMoves;
        _initializeGameRepository = initializeGameRepository;
    }

    private readonly Guid _gameId = Guid.NewGuid();
    public async Task<InitializeGameResponse> SetTicTacToeGame(InitializeGameRecord game)
    {
        try
        {
            Guid gameId = _gameId;
            var insertGame = _initializeGameRepository.InitializeGameWrite.InsertAsync(game.SetGameEntity(gameId));
            InitializeGameResponse initializeGameResponse = new
                (
                    idGame: gameId,
                    possibleMoves: _setInitialPossibleMoves.SetInitialPossibleMovesTicTacToe(game.GameOptions.GetGameTypeOptions.TicTacToeNumberColumns),
                    startGame: true
                );
            await insertGame;
            await _initializeGameRepository.Complete();
            return initializeGameResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

}

