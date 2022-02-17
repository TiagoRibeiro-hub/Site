
namespace Games.Data.Extensions;

public static class MoveExtensions
{
    public static MovesEntity SetMovesEntityVsHuman(this GameVsHumanRequest x)
    {
        return new MovesEntity
        (
            playerName: x.Player.Name,
            moveTo: x.MoveTo,
            moveFrom: x.MoveFrom,
            moveNumber: x.MoveNumber,
            gameId: x.IdGame
        );
    }

}