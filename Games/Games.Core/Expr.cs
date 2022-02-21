namespace Games.Core;
public static class Expr
{
    public static Expression<Func<RegisteredPlayersEntity, bool>> IsExistByEmail(string email)
    {
        Expression<Func<RegisteredPlayersEntity, bool>> _expression = x => x.PlayerEmail == email;
        return _expression;
    }

    public static Expression<Func<RegisteredPlayersEntity, bool>> IsExistByPlayerName(string playerName)
    {
        Expression<Func<RegisteredPlayersEntity, bool>> _expression = x => x.PlayerName == playerName;
        return _expression;
    }
}


