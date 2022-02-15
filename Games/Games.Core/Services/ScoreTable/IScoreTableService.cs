namespace Games.Core.Services;
public interface IScoreTableService
{
    Task TableScoreInitialize(ScoresTableEntity scoresTable, GameEntity game);
    Task TableScoreInitializeList(HashSet<ScoresTableEntity> scoresTableList, GameEntity game);
}

