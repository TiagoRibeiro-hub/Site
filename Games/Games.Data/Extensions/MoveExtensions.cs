
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
            4 => 4,
            3 => 3,
            2 => 2,
            1 => 1,
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
        return new MovesEntity()
        {
            PlayerName = x.Player.Name,
            MoveTo = x.MoveTo,
            MoveNumber = moveNumber,
            GameId = x.IdGame
        };
    }

}