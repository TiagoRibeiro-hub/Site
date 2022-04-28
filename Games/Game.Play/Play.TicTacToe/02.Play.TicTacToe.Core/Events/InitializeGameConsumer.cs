using _02.Play.TicTacToe.Core.Repository;
using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Data.Game.Player;
using Data.Infrastructure.Events;
using MassTransit;

namespace _02.Play.TicTacToe.Core.Events;

public class InitializeGameConsumer : IConsumer<InitializeGameEvent>
{
    private readonly ITicTacToeRepository _ticTacToeRepository;

    public InitializeGameConsumer(ITicTacToeRepository ticTacToeRepository)
    {
        _ticTacToeRepository = ticTacToeRepository;
    }

    public async Task Consume(ConsumeContext<InitializeGameEvent> context)
    {
        try
        {
            await _ticTacToeRepository.GetTicTacToeGameWrite.InsertAsync(new GameEntity
            (
                _gameId: context.Message.IdGame,
                player1_Name: context.Message.Player1_Name,
                player2_Name: context.Message.VsComputer.IsComputer == false ? context.Message.VsHuman.PlayerName_2 : Computer.Name,
                isComputer: context.Message.VsComputer.IsComputer,
                difficulty: context.Message.VsComputer.Difficulty,
                startFirst: context.Message.StartFirst
            ));
            await _ticTacToeRepository.Complete();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public class InitializeGameConsumerDefenition : ConsumerDefinition<InitializeGameConsumer>
{
    public InitializeGameConsumerDefenition()
    {

    }
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
    IConsumerConfigurator<InitializeGameConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));
    }

}