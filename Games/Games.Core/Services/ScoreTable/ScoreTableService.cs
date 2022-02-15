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
        bool isRegistered_1 = false, isRegistered_2 = false;
        foreach (var item in scoresTableList)
        {
            _expression = x => x.PlayerName == item.Email;
            if (count == 0)
            {
                count += 1;
                isRegistered_1 = await _readRepository.IsAnyAsync(_expression);
            }
            else
            {
                isRegistered_2 = await _readRepository.IsAnyAsync(_expression);
            }
        }
        if (isRegistered_1)
        {

        }
        else
        {

        }
        if (isRegistered_2)
        {

        }
        else
        {

        }
    }
}

