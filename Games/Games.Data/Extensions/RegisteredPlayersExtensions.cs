namespace Games.Data.Extensions;

public static class RegisteredPlayersExtensions
{
    public static RegisteredPlayersEntity SetRegisteredPlayers(this RegisterPlayerRequest x)
    {
        return new RegisteredPlayersEntity
        (
            playerName: x.Player.Name,
            playerEmail: x.Player.Email
        );
    }
}