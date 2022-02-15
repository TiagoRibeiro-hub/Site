using Games.Infrastructure.RepositoryService;
using System.Linq.Expressions;

namespace Games.Core.Services;
internal class ScoreTableService : IScoreTableService
{
    private readonly IReadRepository _readRepository;

    public ScoreTableService(IReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    private Expression<Func<ScoresTableEntity, bool>> _expression;

    public async Task TableScoreInitialize(ScoresTableEntity scoresTable)
    {
        _expression = x => x.PlayerName == scoresTable.Email;
        bool isRegistered = await _readRepository.IsAnyAsync(_expression);
        if (!isRegistered)
        {

        }
        else
        {

        }
    }

    public async Task TableScoreInitializeList(HashSet<ScoresTableEntity> scoresTableList)
    {
        int count = 0;
        bool isRegistered = false;
        foreach (var item in scoresTableList)
        {
            _expression = x => x.PlayerName == item.Email;
            isRegistered = await _readRepository.IsAnyAsync(_expression);
            if (isRegistered)
            {

            }
            else
            {

            }

        }
    }
}

