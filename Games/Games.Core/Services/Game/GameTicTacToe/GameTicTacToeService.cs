using Games.Data.Extensions;
using Games.Infrastructure.RepositoryService;

namespace Games.Core.Services;
public class GameTicTacToeService : IGameTicTacToeService
{
    private readonly IRepository _repository;
    private readonly IScoreTableService _scoreTableService;

    public GameTicTacToeService(IRepository repository, IScoreTableService scoreTableService)
    {
        _repository = repository;
        _scoreTableService = scoreTableService;
    }

    public async Task<GameVsComputerResponse> InitializeGameVsComputerAsync(RegisterVsComputer request)
    {
        GameEntity game = request.SetGameEntityVsComputer();
        ScoresTableEntity scoresTable = request.SetScoreTableVsComputer();
        int idGame = await _repository.InsertAndGetIdAsync(game);
        await _scoreTableService.TableScoreInitialize(scoresTable, game);
        return new GameVsComputerResponse(idGame: idGame);
    }

    public async Task<GameResponse> InitializeGameVsHumanAsync(RegisterVsHuman request)
    {
        GameEntity game = request.SetGameEntityVsHuman();
        HashSet<ScoresTableEntity> scoresTablesList = request.SetScoreTableVsHuman();
        int idGame = await _repository.InsertAndGetIdAsync(game);
        _ = _scoreTableService.TableScoreInitializeList(scoresTablesList, game);
        return new GameResponse(idGame: idGame);
    }
}

