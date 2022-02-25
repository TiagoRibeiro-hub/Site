
namespace Games.Data.Extensions;

public static class MoveExtensions
{
    public static MovesEntity SetMovesEntity(this PlayRequest x)
    {
        return new MovesEntity
            (
                playerName: x.PlayerName,
                moveTo: x.Movements.MoveTo,
                moveFrom: x.Movements.MoveFrom,
                moveNumber: x.Movements.MoveNumber,
                gameId: x.IdGame
            );
    }

}