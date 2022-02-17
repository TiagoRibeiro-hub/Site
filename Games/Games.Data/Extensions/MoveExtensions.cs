
namespace Games.Data.Extensions;

public static class MoveExtensions
{
    private static int GetMoveNumber(int v)
    {
        return v switch
        {
            9 => 1,
            8 => 2,
            7 => 3,
            6 => 4,
            5 => 5,
            4 => 6,
            3 => 7,
            2 => 8,
            1 => 9,
            _ => 0,
        };
    }
    public static MovesEntity SetMovesEntityVsHuman(this GameVsHumanRequest x)
    {
        int moveNumber = GetMoveNumber(x.PossibleMoves.Count);
        if(moveNumber == 0)
        {
            throw new Exception();
        }
        return new MovesEntity
        (
            playerName: x.Player.Name,
            moveTo: x.MoveTo,
            moveFrom: x.MoveFrom,
            moveNumber: moveNumber,
            gameId: x.IdGame
        );
    }

}