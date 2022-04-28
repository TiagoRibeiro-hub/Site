using _01.Game.Initialize.Infrastructure;
using _02.Game.Initialize.Core.GameOptions;
using _02.Game.Initialize.Core.Repository;
using Data.Infrastructure.Events;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;
using MassTransit;

namespace _02.Game.Initialize.Core.Services;
public interface IInitializeGameOptionsService
{
    Task<InitializeGameResponse> SetTicTacToeGame(InitializeGameRecord game);
}
public class InitializeGameOptions : IInitializeGameOptionsService
{
    private readonly SetInitialPossibleMoves _setInitialPossibleMoves;
    private readonly IInitializeGameRepository _initializeGameRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    public InitializeGameOptions(
        SetInitialPossibleMoves setInitialPossibleMoves,
        IInitializeGameRepository initializeGameRepository, 
        IPublishEndpoint publishEndpoint)
    {
        _setInitialPossibleMoves = setInitialPossibleMoves;
        _initializeGameRepository = initializeGameRepository;
        _publishEndpoint = publishEndpoint;
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
            if (!insertGame.IsCompleted)
            {
                throw new Exception("insertGame Error");
            }

            Task publish = Publish(game, gameId);

            await _initializeGameRepository.Complete();
            await publish;

            return initializeGameResponse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    private Task Publish(InitializeGameRecord game, Guid gameId)
    {
        return _publishEndpoint.Publish<InitializeGameEvent>(new
        {
            IdGame = gameId,
            GameOptions = game.GameOptions,
            Player1_Name = game.Player1_Name,
            StartFirst = game.StartFirst,
            VsComputer = game.VsComputer,
            VsHuman = game.VsHuman
        });
    }
}

