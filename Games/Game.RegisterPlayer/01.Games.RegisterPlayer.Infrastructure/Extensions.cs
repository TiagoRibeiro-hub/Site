using Data.Infrastructure.Data._Entities;

namespace _01.Games.RegisterPlayer.Infrastructure;
public static class Extensions
{
    public static RegisteredPlayersEntity SetRegisteredPlayersEntity(this RegisterPlayerRecord x)
    {
        return new RegisteredPlayersEntity
            (
                playerName: x.Player.Name,
                playerEmail: x.Player.Email
            );
    }
}
