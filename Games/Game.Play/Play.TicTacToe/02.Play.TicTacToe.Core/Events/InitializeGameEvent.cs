using _02.Play.TicTacToe.Core.Repository;
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

        var x = context;
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