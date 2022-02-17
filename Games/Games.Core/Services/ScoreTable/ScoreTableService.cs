using System.Linq.Expressions;

namespace Games.Core.Services;
internal class ScoreTableService : IScoreTableService
{
    private readonly IReadRepository _readRepository;
    private readonly IRepository _repository;
    private readonly ScoreTableFuncs _scoreTableFuncs;
    public ScoreTableService(IReadRepository readRepository, IRepository repository, ScoreTableFuncs scoreTableFuncs)
    {
        _readRepository = readRepository;
        _repository = repository;
        _scoreTableFuncs = scoreTableFuncs;
    }

    private Expression<Func<ScoresTableEntity, bool>>? _expressionBool;
    private Expression<Func<ScoresTableEntity, int>>? _expressionInt;

    public async Task TableScoreInitialize(ScoresTableEntity scoresTable, GameEntity game)
    {
        try
        {
            _expressionBool = x => x.Email == scoresTable.Email;
            bool isRegistered = await _readRepository.IsAnyAsync(_expressionBool);
            if (!isRegistered)
            {
                scoresTable.SetScoreTableTotalGames(game);
                await _repository.InsertAsync(scoresTable);
            }
            else
            {
                _expressionInt = x => x.Id;
                int scoreTableId = await _readRepository.GetSelectedTableAsync(_expressionBool, _expressionInt);
                await _scoreTableFuncs.UpdateScoreTableTotalGamesAsync(game, scoreTableId, scoresTable.PlayerName);
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task TableScoreInitializeList(HashSet<ScoresTableEntity> scoresTableList, GameEntity game)
    {
        try
        {
            bool isRegistered = false;
            foreach (var item in scoresTableList)
            {
                _expressionBool = x => x.Email == item.Email;
                isRegistered = await _readRepository.IsAnyAsync(_expressionBool);
                if (!isRegistered)
                {
                    item.SetScoreTableTotalGames(game);
                    await _repository.InsertAsync(item);
                }
                else
                {
                    _expressionInt = x => x.Id;
                    int scoreTableId = await _readRepository.GetSelectedTableAsync(_expressionBool, _expressionInt);
                    await _scoreTableFuncs.UpdateScoreTableTotalGamesAsync(game, scoreTableId, item.PlayerName);
                }
            }
            Task.CompletedTask.Wait();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}



