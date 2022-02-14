namespace Games.Core.Services;
public interface IScoreTableService
{
    Task TableScoreInitialize(ScoresTableEntity scoresTable);
    Task TableScoreInitializeList(HashSet<ScoresTableEntity> scoresTable);
}

