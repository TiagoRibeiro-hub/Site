
namespace Games.Data.Extensions;

public static class MoveExtensions
{
    public static MovesEntity SetMovesEntityVsHuman(this PlayRequest x)
    {
        return new MovesEntity
        (
            playerName: x.PlayerName,
            moveTo: x.MoveTo,
            moveFrom: x.MoveFrom,
            moveNumber: x.MoveNumber,
            gameId: x.IdGame
        );
    }

}